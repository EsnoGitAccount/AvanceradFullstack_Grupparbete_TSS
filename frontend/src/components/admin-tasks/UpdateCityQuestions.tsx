import { useState, type SubmitEvent } from 'react';
import type { CityQuestionsUpdate } from '@/models/AdminModels';
import {
  getCityQuestions,
  updateCityQuestions,
} from '@/services/AdminService';

type UpdateCityQuestionsProps = {
  cityId: number | null;
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
      questions: questions.questions.map((question) =>
        question.questionId === questionId
          ? { ...question, questionText }
          : question,
      ),
    });

    setSaved(false);
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
  };

  const handleCorrectOptionChange = (
    questionId: number,
    correctOptionId: number,
  ) => {
    if (!questions) {
      return;
    }

    onQuestionsChange({
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
  };

  const handleSubmit = async (
    event: SubmitEvent<HTMLFormElement>,
  ) => {
    event.preventDefault();

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

    setLoading(true);

    try {
      await updateCityQuestions(cityId, questions);

      const refreshedQuestions =
        await getCityQuestions(cityId);

      onQuestionsSaved(cityId, refreshedQuestions);
      setSaved(true);
    } catch (error) {
      const message =
        error instanceof Error
          ? error.message
          : 'Kunde inte uppdatera frågorna.';

      setError(message);
    } finally {
      setLoading(false);
    }
  };

  if (cityId === null || !questions) {
    return (
      <div>
        <h3>Uppdatera frågor</h3>
        <p>Hämta en stads frågor först.</p>
      </div>
    );
  }

  return (
    <div>
      <h3>Uppdatera frågor</h3>

      <form onSubmit={handleSubmit}>
        {questions.questions.map((question) => (
          <fieldset key={question.questionId}>
            <legend>
              Fråga {question.questionId}
            </legend>

            <div>
              <label
                htmlFor={`question-${question.questionId}`}
              >
                Frågetext
              </label>

              <input
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

                <label
                  htmlFor={`option-${option.optionId}`}
                >
                  Svar {option.optionId}
                </label>

                <input
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

        <button type="submit" disabled={loading}>
          {loading ? 'Sparar...' : 'Spara frågor'}
        </button>
      </form>

      {error && <p role="alert">{error}</p>}

      {saved && (
        <p role="status">Frågorna har sparats.</p>
      )}
    </div>
  );
}
