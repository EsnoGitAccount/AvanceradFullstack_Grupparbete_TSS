import { useState } from "react";
import type { AdminCity } from "@/models/AdminModels";
import { getAdminCities } from "@/services/AdminService";

type ListAdminCitiesProps = {
  cities: AdminCity[];
  onCitiesLoaded: (cities: AdminCity[]) => void;
};

export default function ListAdminCities({
  cities,
  onCitiesLoaded,
}: ListAdminCitiesProps) {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleLoadCities = async () => {
    setLoading(true);
    setError(null);

    try {
      const loadedCities = await getAdminCities();
      onCitiesLoaded(loadedCities);
    } catch (error) {
      const message =
        error instanceof Error ? error.message : "Kunde inte hämta städer.";

      setError(message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <h3>Alla städer</h3>

      <button type="button" onClick={handleLoadCities} disabled={loading}>
        {loading ? "Hämtar..." : "Hämta städer"}
      </button>

      {error && <p role="alert">{error}</p>}

      <ul>
        {cities.map((city) => (
          <li key={city.cityId}>
            ID: {city.cityId} – {city.name} –{" "}
            {city.isArchived ? "Arkiverad" : "Aktiv"} – Bild: {city.cityPicture}
          </li>
        ))}
      </ul>
    </div>
  );
}
