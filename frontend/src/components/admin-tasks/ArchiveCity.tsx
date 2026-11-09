import { Button } from "@/components/ui/Button";
import { Label } from "@/components/ui/Label";
import { useState, type SubmitEvent } from "react";
import type { AdminCity } from "@/models/AdminModels";
import { archiveCity } from "@/services/AdminService";

type ArchiveCityProps = {
  cities: AdminCity[];
  onCityArchived: (cityId: number) => void;
};

export default function ArchiveCity({
  cities,
  onCityArchived,
}: ArchiveCityProps) {
  const [selectedCityId, setSelectedCityId] = useState("");
  const [archivedCityName, setArchivedCityName] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const activeCities = cities.filter((city) => !city.isArchived);

  const handleSubmit = async (event: SubmitEvent<HTMLFormElement>) => {
    event.preventDefault();

    setError(null);
    setArchivedCityName(null);

    const selectedCity = activeCities.find(
      (city) => city.cityId === Number(selectedCityId),
    );

    if (!selectedCity) {
      setError("Välj en aktiv stad.");
      return;
    }

    setLoading(true);

    try {
      await archiveCity(selectedCity.cityId);

      onCityArchived(selectedCity.cityId);
      setArchivedCityName(selectedCity.name);
      setSelectedCityId("");
    } catch (error) {
      const message =
        error instanceof Error ? error.message : "Kunde inte arkivera staden.";

      setError(message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <h3>Arkivera stad</h3>

      <form onSubmit={handleSubmit}>
        <div>
          <Label htmlFor="archive-city-select">Aktiv stad</Label>

          <select
            id="archive-city-select"
            value={selectedCityId}
            onChange={(event) => {
              setSelectedCityId(event.target.value);
              setError(null);
              setArchivedCityName(null);
            }}
            required
          >
            <option value="">Välj en stad</option>

            {activeCities.map((city) => (
              <option key={city.cityId} value={city.cityId}>
                {city.name}
              </option>
            ))}
          </select>
        </div>

        <Button variant="destructive" type="submit" disabled={loading || !selectedCityId}>
          {loading ? "Arkiverar..." : "Arkivera stad"}
        </Button>
      </form>

      {cities.length === 0 && <p>Det finns inga städer.</p>}

      {cities.length > 0 && activeCities.length === 0 && (
        <p>Det finns inga aktiva städer att arkivera.</p>
      )}

      {error && <p role="alert">{error}</p>}

      {archivedCityName && (
        <p role="status">Staden {archivedCityName} arkiverades.</p>
      )}
    </div>
  );
}
