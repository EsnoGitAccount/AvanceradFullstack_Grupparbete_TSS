import { useState } from "react";
import type { Clue } from '../../../models/City.ts'
import placeholderImg from '../../../assets/images/photo-example.jpg'
import { SWEDISH_CITIES } from '../../../constants/swedishCities'

import { Input } from '@/components/ui/Input'
import { Button } from '@/components/ui/Button'
import GameImage from '@/components/game-image/GameImage'

import './whereAreWe.css'

type WhereAreWeProps = {
  onComplete: (score: number) => void
  clues: Clue[]
  correctCity: string
  imageUrl: string | undefined
}

export default function WhereAreWe({
  onComplete,
  clues,
  correctCity,
  imageUrl,
}: WhereAreWeProps){

  const [currentScore, setCurrentScore] = useState(10)
  const [cityGuess, setCityGuess] = useState("");
  const [isCitySuggestionsOpen, setIsCitySuggestionsOpen] = useState(false);
  const [isWrongGuess, setIsWrongGuess] = useState(false);

  const filteredCities = SWEDISH_CITIES.filter((city) =>
    city.toLocaleLowerCase('sv-SE').includes(
      cityGuess.trim().toLocaleLowerCase('sv-SE')
    )
  );

  const handleWhereAreWeSubmit = (event: React.SubmitEvent) => {
    event.preventDefault();

    if (isWrongGuess || !cityGuess.trim()) {
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

    setTimeout(() => {
      setIsWrongGuess(false);
      setCityGuess("");

      const nextScore = handleNextClue();

      if (nextScore <= 0) {
        onComplete(0);
      }
    }, 1500);
  };

  const handleNextClue = () => {
    const nextScore = Math.max(currentScore - 2, 0)
    setCurrentScore(nextScore);
    return nextScore;
  }

  return (
    <div className="where-are-we__page">
      <section className="where-are-we__main">
        <div className="where-are-we__left-side">
          <h1 className="where-are-we__title">Vart är vi?</h1>
          <GameImage className="where-are-we__image" src={
                  imageUrl
                    ? `/api/Image/${imageUrl}`
                    : placeholderImg
                } alt="Bild från destinationen" />
        </div>
        <div className="where-are-we__right-side">

          <div className="where-are-we__clues">
            {clues.map((clue) => {
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

            <Button
              className="where-are-we__show-clue-button"
              onClick={handleNextClue}
              disabled={currentScore <= 2 || isWrongGuess}
              variant="secondary"
            >
              {currentScore <= 2 ? "Inga fler ledtrådar!" : "Visa nästa ledtråd"}
            </Button>
          </div>

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
                placeholder="Vart är vi?"
                aria-label="Gissa vilken svensk stad vi är i"
                autoComplete="off"
              />

              {isCitySuggestionsOpen && cityGuess.trim().length > 0 && (
                <div
                  className="where-are-we__city-suggestions"
                  role="listbox"
                  aria-label="Stadsförslag"
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
                      Ingen stad hittades.
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
        </div>
      </section>
    </div>
  )
}
