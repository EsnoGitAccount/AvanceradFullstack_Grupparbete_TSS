import { useState } from "react";
import type { AdminCity, CityQuestionsUpdate } from "@/models/AdminModels";
import { getCityQuestions } from "@/services/AdminService";

type GetCityQuestionsProps = {
  cities: AdminCity[];
  loadedCityId: number | null;
  questions: CityQuestionsUpdate | null;
  onQuestionsLoaded: (cityId: number, questions: CityQuestionsUpdate) => void;
};

export default function GetCityQuestions({
  cities,
  loadedCityId,
  questions,
  onQuestionsLoaded,
}: GetCityQuestionsProps) {
  const [selectedCityId, setSelectedCityId] = useState("");
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleLoadQuestions = async () => {
    setError(null);

    if (!selectedCityId) {
      setError("Välj en stad.");
      return;
    }

    const cityId = Number(selectedCityId);

    setLoading(true);

    try {
      const loadedQuestions = await getCityQuestions(cityId);

      onQuestionsLoaded(cityId, loadedQuestions);
    } catch (error) {
      const message =
        error instanceof Error
          ? error.message
          : "Kunde inte hämta stadens frågor.";

      setError(message);
    } finally {
      setLoading(false);
    }
  };

  const loadedCity = cities.find((city) => city.cityId === loadedCityId);

  return (
    <div>
      <h3>Visa stadens frågor</h3>

      <div>
        <label htmlFor="questions-city-select">Stad</label>

        <select
          id="questions-city-select"
          value={selectedCityId}
          onChange={(event) => {
            setSelectedCityId(event.target.value);
            setError(null);
          }}
        >
          <option value="">Välj en stad</option>

          {cities.map((city) => (
            <option key={city.cityId} value={city.cityId}>
              {city.name}
              {city.isArchived ? " (arkiverad)" : ""}
            </option>
          ))}
        </select>
      </div>

      <button
        type="button"
        onClick={handleLoadQuestions}
        disabled={loading || !selectedCityId}
      >
        {loading ? "Hämtar..." : "Hämta frågor"}
      </button>

      {cities.length === 0 && <p>Hämta stadslistan först.</p>}

      {error && <p role="alert">{error}</p>}

      {questions && loadedCityId !== null && (
        <div>
          <h4>Frågor för {loadedCity?.name ?? `stad ${loadedCityId}`}</h4>

          {questions.questions.length === 0 ? (
            <p>Staden har inga frågor.</p>
          ) : (
            <ol>
              {questions.questions.map((question) => (
                <li key={question.questionId}>
                  <p>Fråga-ID: {question.questionId}</p>

                  <p>{question.questionText}</p>

                  <ul>
                    {question.options.map((option) => (
                      <li key={option.optionId}>
                        ID: {option.optionId} - {option.optionText} -{" "}
                        {option.isCorrect ? "Rätt svar" : "Fel svar"}
                      </li>
                    ))}
                  </ul>
                </li>
              ))}
            </ol>
          )}
        </div>
      )}
    </div>
  );
}
