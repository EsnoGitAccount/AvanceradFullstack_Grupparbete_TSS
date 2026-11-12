import { Button } from "@/components/ui/Button";
import { Label } from "@/components/ui/Label";
import { useState } from "react";
import type { AdminCity, CityQuestionsUpdate } from "@/models/AdminModels";
import { getCityQuestions } from "@/services/AdminService";

type GetCityQuestionsProps = {
  cities: AdminCity[];
  disabled: boolean;
  onLoadingChange: (loading: boolean) => void;
  onQuestionsLoaded: (cityId: number, questions: CityQuestionsUpdate) => void;
};

export default function GetCityQuestions({
  cities,
  disabled,
  onLoadingChange,
  onQuestionsLoaded,
}: GetCityQuestionsProps) {
  const [selectedCityId, setSelectedCityId] = useState("");
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleLoadQuestions = async () => {
    if (disabled || loading) return;
    setError(null);

    if (!selectedCityId) {
      setError("Välj en stad.");
      return;
    }

    const cityId = Number(selectedCityId);

    setLoading(true);
    onLoadingChange(true);

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
      onLoadingChange(false);
    }
  };

  return (
    <div>
      <h3>Hämta stadens frågor & ledtrådar</h3>

      <div>
        <Label htmlFor="questions-city-select">Stad</Label>

        <select
          disabled={disabled || loading}
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

      <Button
        type="button"
        onClick={handleLoadQuestions}
        disabled={disabled || loading || !selectedCityId}
      >
        {loading ? "Hämtar..." : "Hämta frågor & ledtrådar"}
      </Button>

      {cities.length === 0 && <p>Det finns inga städer.</p>}

      {error && <p role="alert">{error}</p>}
    </div>
  );
}
