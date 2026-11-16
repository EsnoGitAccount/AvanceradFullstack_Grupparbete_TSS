import { useEffect, useRef, useState, useSyncExternalStore } from "react";
import type { Clue } from '../../../models/City.ts'
import placeholderImg from '../../../assets/images/photo-example.jpg'
import { SWEDISH_CITIES } from '../../../constants/swedishCities'

import { Input } from '@/components/ui/Input'
import { Button } from '@/components/ui/Button'
import GameImage from '@/components/game-image/GameImage'

import './whereAreWe.css'

const mobileQuery = "(max-width: 64rem)";
const subscribeToMobile = (onChange: () => void) => {
  const query = window.matchMedia(mobileQuery);
  query.addEventListener("change", onChange);
  return () => query.removeEventListener("change", onChange);
};
const getMobileSnapshot = () => window.matchMedia(mobileQuery).matches;
const getServerMobileSnapshot = () => false;

type WhereAreWeProps = {
  onComplete: (score: number) => void
  clues: Clue[]
  correctCity: string
  imageUrl: string | undefined
  imageSrc?: string
  imageAlt?: string
  title?: string
  guessLabel?: string
  suggestionLabel?: string
  emptySuggestionText?: string
  suggestions?: readonly string[]
  showSuggestions?: boolean
  requireCorrectAnswer?: boolean
}

export default function WhereAreWe({
  onComplete,
  clues,
  correctCity,
  imageUrl,
  imageSrc,
  imageAlt = "Bild från destinationen",
  title = "Vart är vi?",
  guessLabel = "Gissa vilken svensk stad vi är i",
  suggestionLabel = "Stadsförslag",
  emptySuggestionText = "Ingen stad hittades.",
  suggestions = SWEDISH_CITIES,
  showSuggestions = true,
  requireCorrectAnswer = false,
}: WhereAreWeProps){

  const isMobile = useSyncExternalStore(
    subscribeToMobile, getMobileSnapshot, getServerMobileSnapshot
  );
  const [currentScore, setCurrentScore] = useState(10)
  const [cityGuess, setCityGuess] = useState("");
  const [isCitySuggestionsOpen, setIsCitySuggestionsOpen] = useState(false);
  const [isWrongGuess, setIsWrongGuess] = useState(false);
  const feedbackTimer = useRef<ReturnType<typeof setTimeout> | null>(null);

  useEffect(() => () => {
    if (feedbackTimer.current !== null) clearTimeout(feedbackTimer.current);
  }, []);

  const filteredCities = suggestions.filter((city) =>
    city.toLocaleLowerCase('sv-SE').includes(
      cityGuess.trim().toLocaleLowerCase('sv-SE')
    )
  );

  const handleWhereAreWeSubmit = (event: React.SubmitEvent) => {
    event.preventDefault();

    if (isWrongGuess || feedbackTimer.current !== null || !cityGuess.trim()) {
      return;
    }

    const isCorrect =
      cityGuess.trim().toLocaleLowerCase('sv-SE') ===
      correctCity.toLocaleLowerCase('sv-SE');

    setIsCitySuggestionsOpen(false);

    if (isCorrect) {
      onComplete(currentScore);
      return;
    }

    setIsWrongGuess(true);

    feedbackTimer.current = setTimeout(() => {
      feedbackTimer.current = null;
      setIsWrongGuess(false);
      setCityGuess("");

      const nextScore = handleNextClue();

      if (nextScore <= 0 && !requireCorrectAnswer) {
        onComplete(0);
      }
    }, 750);
  };

  const handleNextClue = () => {
    const nextScore = Math.max(currentScore - 2, 0)
    setCurrentScore(nextScore);
    return nextScore;
  }

  const displayedClues = isMobile
    ? clues.filter((clue) => clue.pointValue >= currentScore).reverse()
    : clues;

  const nextClueButton = (
    <Button
      className="where-are-we__show-clue-button"
      onClick={handleNextClue}
      disabled={currentScore <= 2 || isWrongGuess}
      variant="secondary"
    >
      {currentScore <= 2 ? "Inga fler ledtrådar!" : "Visa nästa ledtråd"}
    </Button>
  );

  const answerForm = (
    <form className="where-are-we__form" onSubmit={handleWhereAreWeSubmit}>
      <div className="where-are-we__city-field">
        <Input
          className={isWrongGuess ? "where-are-we__input--wrong" : ""}
          readOnly={isWrongGuess}
          aria-invalid={isWrongGuess}
          value={cityGuess}
          onChange={(event) => {
            const value = event.target.value;
            setCityGuess(value);
            setIsCitySuggestionsOpen(value.trim().length > 0);
          }}
          onFocus={() => {
            if (cityGuess.trim().length > 0) {
              setIsCitySuggestionsOpen(true);
            }
          }}
          placeholder={title}
          aria-label={guessLabel}
          autoComplete="off"
        />

        {showSuggestions && isCitySuggestionsOpen && cityGuess.trim().length > 0 && (
          <div
            className="where-are-we__city-suggestions"
            role="listbox"
            aria-label={suggestionLabel}
          >
            {filteredCities.length > 0 ? (
              filteredCities.map((city) => (
                <button
                  className="where-are-we__city-suggestion"
                  key={city}
                  type="button"
                  role="option"
                  onMouseDown={(event) => event.preventDefault()}
                  onClick={() => {
                    setCityGuess(city);
                    setIsCitySuggestionsOpen(false);
                  }}
                >
                  {city}
                </button>
              ))
            ) : (
              <p className="where-are-we__city-empty">
                {emptySuggestionText}
              </p>
            )}
          </div>
        )}
      </div>
      <Button className="where-are-we__submit-button
      "type="submit"
      disabled={isWrongGuess || !cityGuess.trim()}
      >
        Svara
        </Button>
    </form>
  );

  return (
    <div className="where-are-we__page">
      <section className="where-are-we__main">
        <div className="where-are-we__left-side">
          <h1 className="page-title where-are-we__title">{title}</h1>
          <GameImage className="where-are-we__image" src={
                  imageSrc ?? (imageUrl
                    ? `/api/Image/${imageUrl}`
                    : placeholderImg)
                } alt={imageAlt} />
        </div>
        <div className="where-are-we__right-side">

          {isMobile && answerForm}

          <div className="where-are-we__clues">
            {isMobile && nextClueButton}
            {displayedClues.map((clue) => {
              const isVisible = clue.pointValue >= currentScore;

              return (
                <div
                  key={clue.pointValue}
                  className={`where-are-we__clue ${isVisible ? "" : "where-are-we__clue--hidden"
                    }`}
                >
                  <p className="where-are-we__clue-label">{clue.pointValue}</p>
                  <p className="where-are-we__clue-text">{clue.clueText}</p>
                </div>
              );
            })}

            {!isMobile && nextClueButton}
          </div>

          {!isMobile && answerForm}
        </div>
      </section>
    </div>
  )
}
