import { Button } from "@/components/ui/Button";
import { Label } from "@/components/ui/Label";
import { Input } from "@/components/ui/Input";
import { useState, type SubmitEvent } from 'react';
import type { CityQuestionsUpdate } from '@/models/AdminModels';
import {
  updateCityQuestions,
} from '@/services/AdminService';

type UpdateCityQuestionsProps = {
  cityId: number | null;
  cityName?: string;
  busy: boolean;
  dirty: boolean;
  onLoadingChange: (loading: boolean) => void;
  questions: CityQuestionsUpdate | null;
  onQuestionsChange: (
    questions: CityQuestionsUpdate,
  ) => void;
  onQuestionsSaved: (
    cityId: number,
    questions: CityQuestionsUpdate,
  ) => void;
};

export default function UpdateCityQuestions({
  cityId,
  cityName,
  busy,
  dirty,
  onLoadingChange,
  questions,
  onQuestionsChange,
  onQuestionsSaved,
}: UpdateCityQuestionsProps) {
  const [loading, setLoading] = useState(false);
  const [saved, setSaved] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleQuestionTextChange = (
    questionId: number,
    questionText: string,
  ) => {
    if (!questions) {
      return;
    }

    onQuestionsChange({
      ...questions,
      questions: questions.questions.map((question) =>
        question.questionId === questionId
          ? { ...question, questionText }
          : question,
      ),
    });

    setSaved(false);
    setError(null);
  };

  const handleOptionTextChange = (
    questionId: number,
    optionId: number,
    optionText: string,
  ) => {
    if (!questions) {
      return;
    }

    onQuestionsChange({
      ...questions,
      questions: questions.questions.map((question) =>
        question.questionId === questionId
          ? {
            ...question,
            options: question.options.map((option) =>
              option.optionId === optionId
                ? { ...option, optionText }
                : option,
            ),
          }
          : question,
      ),
    });

    setSaved(false);
    setError(null);
  };

  const handleCorrectOptionChange = (
    questionId: number,
    correctOptionId: number,
  ) => {
    if (!questions) {
      return;
    }

    onQuestionsChange({
      ...questions,
      questions: questions.questions.map((question) =>
        question.questionId === questionId
          ? {
            ...question,
            options: question.options.map((option) => ({
              ...option,
              isCorrect:
                option.optionId === correctOptionId,
            })),
          }
          : question,
      ),
    });

    setSaved(false);
    setError(null);
  };

  const handleSubmit = async (
    event: SubmitEvent<HTMLFormElement>,
  ) => {
    event.preventDefault();
    if (busy || loading || !dirty) return;

    setError(null);
    setSaved(false);

    if (cityId === null || !questions) {
      setError('Hämta en stads frågor först.');
      return;
    }

    const hasBlankText = questions.questions.some(
      (question) =>
        !question.questionText.trim() ||
        question.options.some(
          (option) => !option.optionText.trim(),
        ),
    );

    if (hasBlankText) {
      setError('Frågor och svarsalternativ får inte vara tomma.');
      return;
    }

    const hasInvalidCorrectAnswer = questions.questions.some(
      (question) =>
        question.options.filter(
          (option) => option.isCorrect,
        ).length !== 1,
    );

    if (hasInvalidCorrectAnswer) {
      setError(
        'Varje fråga måste ha exakt ett rätt svar.',
      );
      return;
    }

    if (questions.clues?.some((clue) => !clue.clueText.trim())) {
      setError('Ledtrådar får inte vara tomma.');
      return;
    }

    const payload: CityQuestionsUpdate = {
      ...questions,
      clues: questions.clues?.map((clue) => ({ ...clue, clueText: clue.clueText.trim() })),
      questions: questions.questions.map((question) => ({
        ...question,
        questionText: question.questionText.trim(),
        options: question.options.map((option) => ({
          ...option,
          optionText: option.optionText.trim(),
        })),
      })),
    };

    setLoading(true);
    onLoadingChange(true);

    try {
      await updateCityQuestions(cityId, payload);
      onQuestionsSaved(cityId, payload);
      setSaved(true);
    } catch (error) {
      const message =
        error instanceof Error
          ? error.message
          : 'Kunde inte uppdatera frågorna.';

      setError(message);
    } finally {
      setLoading(false);
      onLoadingChange(false);
    }
  };

  if (cityId === null || !questions) {
    return (
      <div>
        <h3>Uppdatera frågor & ledtrådar</h3>
        <p>Hämta en stads frågor först.</p>
      </div>
    );
  }

  return (
    <div>
      <h3>Uppdatera frågor & ledtrådar</h3>

      <p>{cityName ?? `Stad ${cityId}`}</p>
      {questions.questions.length === 0 && <p>Staden har inga frågor.</p>}
      {dirty && <p>Osparade ändringar. Hämtar du frågor igen ersätts dina osparade ändringar.</p>}
      <form onSubmit={handleSubmit}>
        {questions.questions.map((question) => (
          <fieldset key={question.questionId} disabled={busy || loading}>
            <legend>
              Fråga {question.questionId}
            </legend>

            <div>
              <Label
                htmlFor={`question-${question.questionId}`}
              >
                Frågetext
              </Label>

              <Input
                id={`question-${question.questionId}`}
                type="text"
                value={question.questionText}
                onChange={(event) => {
                  handleQuestionTextChange(
                    question.questionId,
                    event.target.value,
                  );
                }}
                required
              />
            </div>

            {question.options.map((option) => (
              <div key={option.optionId}>
                <input
                  type="radio"
                  name={`correct-answer-${question.questionId}`}
                  checked={option.isCorrect}
                  onChange={() => {
                    handleCorrectOptionChange(
                      question.questionId,
                      option.optionId,
                    );
                  }}
                  aria-label={`Markera svar ${option.optionId} som rätt`}
                />

                <Label
                  htmlFor={`option-${option.optionId}`}
                >
                  Svar {option.optionId}
                </Label>

                <Input
                  id={`option-${option.optionId}`}
                  type="text"
                  value={option.optionText}
                  onChange={(event) => {
                    handleOptionTextChange(
                      question.questionId,
                      option.optionId,
                      event.target.value,
                    );
                  }}
                  required
                />
              </div>
            ))}
          </fieldset>
        ))}

        {questions.clues && (
          <div className="admin-page__clues">
            <h4>Ledtrådar</h4>
            {questions.clues.map((clue) => (
              <div key={clue.clueId}>
                <Label htmlFor={`edit-clue-${clue.clueId}`}>Ledtråd för {clue.point} poäng</Label>
                <Input id={`edit-clue-${clue.clueId}`} value={clue.clueText} required disabled={busy || loading}
                  onChange={(event) => {
                    onQuestionsChange({ ...questions, clues: questions.clues?.map((item) =>
                      item.clueId === clue.clueId ? { ...item, clueText: event.target.value } : item) });
                    setSaved(false);
                    setError(null);
                  }} />
              </div>
            ))}
            {questions.clues.length === 0 && <p>Staden har inga ledtrådar.</p>}
          </div>
        )}

        <Button type="submit" disabled={busy || loading || !dirty || questions.questions.length === 0}>
          {loading ? 'Sparar...' : 'Spara frågor & ledtrådar'}
        </Button>
      </form>

      {error && <p role="alert">{error}</p>}

      {saved && (
        <p role="status">Frågor och ledtrådar har sparats.</p>
      )}
    </div>
  );
}
