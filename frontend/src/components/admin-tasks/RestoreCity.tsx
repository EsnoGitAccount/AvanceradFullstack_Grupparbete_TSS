import { Button } from "@/components/ui/Button";
import { Label } from "@/components/ui/Label";
import { useState, type SubmitEvent } from "react";
import type { AdminCity } from "@/models/AdminModels";
import { restoreCity } from "@/services/AdminService";

type RestoreCityProps = {
  cities: AdminCity[];
  onCityRestored: (cityId: number) => void;
};

export default function RestoreCity({
  cities,
  onCityRestored,
}: RestoreCityProps) {
  const [selectedCityId, setSelectedCityId] = useState("");
  const [restoredCityName, setRestoredCityName] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const archivedCities = cities.filter((city) => city.isArchived);

  const handleSubmit = async (event: SubmitEvent<HTMLFormElement>) => {
    event.preventDefault();
    if (loading) return;

    setError(null);
    setRestoredCityName(null);

    const selectedCity = archivedCities.find(
      (city) => city.cityId === Number(selectedCityId),
    );

    if (!selectedCity) {
      setError("Välj en arkiverad stad.");
      return;
    }

    setLoading(true);

    try {
      await restoreCity(selectedCity.cityId);

      onCityRestored(selectedCity.cityId);
      setRestoredCityName(selectedCity.name);
      setSelectedCityId("");
    } catch (error) {
      const message =
        error instanceof Error
          ? error.message
          : "Kunde inte återställa staden.";

      setError(message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <h3>Återställ stad</h3>

      <form onSubmit={handleSubmit}>
        <div>
          <Label htmlFor="restore-city-select">Arkiverad stad</Label>

          <select
            disabled={loading}
            id="restore-city-select"
            value={selectedCityId}
            onChange={(event) => {
              setSelectedCityId(event.target.value);
              setError(null);
              setRestoredCityName(null);
            }}
            required
          >
            <option value="">Välj en stad</option>

            {archivedCities.map((city) => (
              <option key={city.cityId} value={city.cityId}>
                {city.name}
              </option>
            ))}
          </select>
        </div>

        <Button type="submit" disabled={loading || !selectedCityId}>
          {loading ? "Återställer..." : "Återställ stad"}
        </Button>
      </form>

      {cities.length === 0 && <p>Det finns inga städer.</p>}

      {cities.length > 0 && archivedCities.length === 0 && (
        <p>Det finns inga arkiverade städer att återställa.</p>
      )}

      {error && <p role="alert">{error}</p>}

      {restoredCityName && (
        <p role="status">Staden {restoredCityName} återställdes.</p>
      )}
    </div>
  );
}
