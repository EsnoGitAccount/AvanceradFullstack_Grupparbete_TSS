import { useState } from "react";
import { Link } from "react-router";
import { Button } from "@/components/ui/Button";
import { ProgressStepper } from "@/components/ui/Progressbar";
import WhereAreWe from "@/components/game-components/where-are-we/whereAreWe";
import QuestionDestination from "@/components/game-components/question-destination/QuestionDestination";
import type { DailyChallenge } from "@/models/DailyChallenge";
import { GAME_RULES } from "@/constants/gameConstants";
import "./TeacherBonusGame.css";

type TeacherPhase =
  | { type: "guess" }
  | { type: "questions"; questionIndex: number }
  | { type: "result"; score: number };

type TeacherBonusGameProps = {
  name: string;
  description: string;
  challenge: DailyChallenge;
  portrait: string;
};

export default function TeacherBonusGame({
  name,
  description,
  challenge,
  portrait,
}: TeacherBonusGameProps) {
  const [phase, setPhase] = useState<TeacherPhase>({ type: "guess" });
  const [guessScore, setGuessScore] = useState(0);
  const [attempt, setAttempt] = useState(0);
  const questionCount = challenge.cityDetails.questions.length;
  const maxScore =
    10 * GAME_RULES.whereAreWeScoreMultiplier +
    questionCount * GAME_RULES.destinationQuestionScore;
  const currentStep =
    phase.type === "guess"
      ? 1
      : phase.type === "questions"
        ? phase.questionIndex + 2
        : questionCount + 2;

  function restart() {
    setGuessScore(0);
    setAttempt((previous) => previous + 1);
    setPhase({ type: "guess" });
  }

  return (
    <div className="teacher-bonus-game">
      <header className="teacher-bonus-game__header">
        <div>
          <p className="teacher-bonus-game__eyebrow">BONUSLÄGE</p>
          <h1>{phase.type === "guess" ? "Vem är läraren?" : name}</h1>
          <p>{description}</p>
          <p className="teacher-bonus-game__note">
            Spela hur många gånger du vill. Poängen gäller bara den här
            bonusrundan.
          </p>
        </div>
        <Link to="/" className="teacher-bonus-game__home">
          Till startsidan
        </Link>
      </header>

      <ProgressStepper
        currentStep={currentStep}
        totalSteps={questionCount + 2}
      />

      {phase.type === "guess" && (
        <WhereAreWe
          key={attempt}
          clues={challenge.cityDetails.clues}
          correctCity={challenge.cityDetails.cityName}
          imageUrl={undefined}
          imageSrc={portrait}
          imageAlt="Porträtt av den hemliga läraren"
          title="Vem är vi hos?"
          guessLabel="Gissa lärarens namn"
          suggestionLabel="Namnförslag"
          emptySuggestionText="Inget namn hittades. Du kan ändå skriva din gissning."
          showSuggestions={false}
          requireCorrectAnswer
          onComplete={(score) => {
            setGuessScore(score * GAME_RULES.whereAreWeScoreMultiplier);
            setPhase({ type: "questions", questionIndex: 0 });
          }}
        />
      )}

      {phase.type === "questions" && (
        <>
          <img
            className="teacher-bonus-game__portrait"
            src={portrait}
            alt={name}
          />
          <QuestionDestination
            key={attempt}
            dailyChallange={challenge}
            previousScore={guessScore}
            onStepChange={(questionIndex) =>
              setPhase({ type: "questions", questionIndex })
            }
            onComplete={(score) =>
              setPhase({ type: "result", score: guessScore + score })
            }
          />
        </>
      )}

      {phase.type === "result" && (
        <section
          className="teacher-bonus-game__result"
          aria-labelledby="teacher-result-title"
        >
          <img
            className="teacher-bonus-game__portrait"
            src={portrait}
            alt={name}
          />
          <h2 id="teacher-result-title">{name}-rundan är klar!</h2>
          <p className="teacher-bonus-game__score">
            {phase.score} / {maxScore} poäng
          </p>
          <p>Tack för att du spelade!</p>
          <Button onClick={restart}>Spela {name} igen</Button>
          <Link to="/" className="teacher-bonus-game__home">
            Till startsidan
          </Link>
        </section>
      )}
    </div>
  );
}
