import { useState, type SubmitEvent } from "react";
import { Button } from "@/components/ui/Button";
import { Input } from "@/components/ui/Input";
import { Label } from "@/components/ui/Label";
import { GAME_RULES } from "@/constants/gameConstants";
import type { CityContentCreate, CityQuestionsUpdate } from "@/models/AdminModels";
import { createCityContent } from "@/services/AdminService";

type CreateCityContentProps = {
  cityId: number;
  cityName?: string;
  initialContent: CityQuestionsUpdate;
  busy: boolean;
  onLoadingChange: (loading: boolean) => void;
  onContentCreated: (cityId: number, questions: CityQuestionsUpdate) => void;
};

export default function CreateCityContent({
  cityId,
  cityName,
  initialContent,
  busy,
  onLoadingChange,
  onContentCreated,
}: CreateCityContentProps) {
  const [content, setContent] = useState<CityContentCreate>(() => ({
    questions: Array.from({ length: GAME_RULES.questionsPerCity }, (_, questionIndex) => {
      const question = initialContent.questions[questionIndex];
      return {
        questionText: question?.questionText ?? "",
        options: Array.from({ length: GAME_RULES.optionsPerQuestion }, (_, optionIndex) => ({
          optionText: question?.options[optionIndex]?.optionText ?? "",
          isCorrect: question?.options[optionIndex]?.isCorrect ?? false,
        })),
      };
    }),
    clues: Array.from({ length: GAME_RULES.cluesPerCity }, (_, index) => initialContent.clues[index]?.clueText ?? ""),
  }));
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleSubmit = async (event: SubmitEvent<HTMLFormElement>) => {
    event.preventDefault();
    if (busy || loading) return;
    setError(null);

    if (initialContent.questions.length > GAME_RULES.questionsPerCity ||
      initialContent.clues.length > GAME_RULES.cluesPerCity ||
      initialContent.questions.some((question) => question.options.length > GAME_RULES.optionsPerQuestion)) {
      setError("Staden har för många frågor, svar eller ledtrådar. Befintliga poster behöver korrigeras först.");
      return;
    }

    if (content.questions.some((question) => !question.questionText.trim() ||
      question.options.some((option) => !option.optionText.trim())) ||
      content.clues.some((clue) => !clue.trim())) {
      setError("Fyll i båda frågorna, alla svar och alla fem ledtrådar.");
      return;
    }
    if (content.questions.some((question) => question.options.filter((option) => option.isCorrect).length !== 1)) {
      setError("Välj exakt ett rätt svar per fråga.");
      return;
    }

    setLoading(true);
    onLoadingChange(true);
    try {
      const questions = await createCityContent(cityId, content);
      onContentCreated(cityId, questions);
    } catch (error) {
      setError(error instanceof Error ? error.message : "Kunde inte skapa frågor och ledtrådar.");
    } finally {
      setLoading(false);
      onLoadingChange(false);
    }
  };

  return (
    <div>
      <h3>Skapa frågor &amp; ledtrådar</h3>
      <p>{cityName ?? `Stad ${cityId}`}</p>
      <form onSubmit={handleSubmit}>
        {content.questions.map((question, questionIndex) => (
          <fieldset key={questionIndex} disabled={busy || loading}>
            <legend>Fråga {questionIndex + 1}</legend>
            <div>
              <Label htmlFor={`create-question-${questionIndex}`}>Frågetext</Label>
              <Input id={`create-question-${questionIndex}`} value={question.questionText} required
                onChange={(event) => setContent((current) => ({ ...current,
                  questions: current.questions.map((item, index) => index === questionIndex
                    ? { ...item, questionText: event.target.value } : item),
                }))} />
            </div>
            {question.options.map((option, optionIndex) => (
              <div key={optionIndex}>
                <input type="radio" name={`create-correct-answer-${questionIndex}`} checked={option.isCorrect}
                  aria-label={`Markera svar ${optionIndex + 1} som rätt`}
                  onChange={() => setContent((current) => ({ ...current,
                    questions: current.questions.map((item, index) => index === questionIndex
                      ? { ...item, options: item.options.map((answer, answerIndex) => ({
                        ...answer, isCorrect: answerIndex === optionIndex,
                      })) } : item),
                  }))} />
                <Label htmlFor={`create-option-${questionIndex}-${optionIndex}`}>Svar {optionIndex + 1}</Label>
                <Input id={`create-option-${questionIndex}-${optionIndex}`} value={option.optionText} required
                  onChange={(event) => setContent((current) => ({ ...current,
                    questions: current.questions.map((item, index) => index === questionIndex
                      ? { ...item, options: item.options.map((answer, answerIndex) => answerIndex === optionIndex
                        ? { ...answer, optionText: event.target.value } : answer) } : item),
                  }))} />
              </div>
            ))}
          </fieldset>
        ))}
        <div className="admin-page__clues">
          {content.clues.map((clue, clueIndex) => (
            <div key={clueIndex}>
              <Label htmlFor={`create-clue-${clueIndex}`}>Ledtråd {clueIndex + 1} ({GAME_RULES.initialCluePoints - clueIndex * GAME_RULES.cluePointsStep} poäng)</Label>
              <Input id={`create-clue-${clueIndex}`} value={clue} required disabled={busy || loading}
                onChange={(event) => setContent((current) => ({ ...current,
                  clues: current.clues.map((text, index) => index === clueIndex ? event.target.value : text),
                }))} />
            </div>
          ))}
        </div>
        <Button type="submit" disabled={busy || loading}>
          {loading ? "Sparar..." : "Spara frågor & ledtrådar"}
        </Button>
      </form>
      {error && <p role="alert">{error}</p>}
    </div>
  );
}
