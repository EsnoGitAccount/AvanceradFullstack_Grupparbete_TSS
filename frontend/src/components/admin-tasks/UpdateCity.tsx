import { allowedImageTypes, maxImageSize } from "@/constants/imageValidation";
import { Button } from "@/components/ui/Button";
import { Label } from "@/components/ui/Label";
import { Input } from "@/components/ui/Input";
import { useRef, useState, type SubmitEvent } from "react";
import type { AdminCity } from "@/models/AdminModels";
import { updateCity } from "@/services/AdminService";

type UpdateCityProps = {
  cities: AdminCity[];
  onCityUpdated: (city: AdminCity) => void;
};

export default function UpdateCity({ cities, onCityUpdated }: UpdateCityProps) {
  const fileInputRef = useRef<HTMLInputElement>(null);

  const [selectedCityId, setSelectedCityId] = useState("");
  const [name, setName] = useState("");
  const [cityPicture, setCityPicture] = useState<File | null>(null);
  const [updatedCity, setUpdatedCity] = useState<AdminCity | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleCityChange = (cityIdValue: string) => {
    setSelectedCityId(cityIdValue);
    setError(null);
    setUpdatedCity(null);
    setCityPicture(null);

    if (fileInputRef.current) {
      fileInputRef.current.value = "";
    }

    const selectedCity = cities.find(
      (city) => city.cityId === Number(cityIdValue),
    );

    setName(selectedCity?.name ?? "");
  };

  const handleSubmit = async (event: SubmitEvent<HTMLFormElement>) => {
    event.preventDefault();
    if (loading) return;

    const trimmedName = name.trim();

    setError(null);
    setUpdatedCity(null);

    if (!selectedCityId) {
      setError("Välj en stad.");
      return;
    }

    if (!trimmedName) {
      setError("Stadens namn måste anges.");
      return;
    }

    if (trimmedName.length > 100) {
      setError("Stadens namn får vara högst 100 tecken.");
      return;
    }

    if (cityPicture && !allowedImageTypes.includes(cityPicture.type)) {
      setError("Bilden måste vara JPEG, PNG eller WEBP.");
      return;
    }

    if (cityPicture && cityPicture.size > maxImageSize) {
      setError("Bilden får vara högst 5 MB.");
      return;
    }

    setLoading(true);

    try {
      const city = await updateCity(
        Number(selectedCityId),
        trimmedName,
        cityPicture ?? undefined,
      );

      setUpdatedCity(city);
      onCityUpdated(city);

      setName(city.name);
      setCityPicture(null);

      if (fileInputRef.current) {
        fileInputRef.current.value = "";
      }
    } catch (error) {
      const message =
        error instanceof Error ? error.message : "Kunde inte uppdatera staden.";

      setError(message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <h3>Uppdatera stad</h3>

      <form onSubmit={handleSubmit}>
        <div>
          <Label htmlFor="update-city-select">Stad</Label>

          <select
            disabled={loading}
            id="update-city-select"
            value={selectedCityId}
            onChange={(event) => {
              handleCityChange(event.target.value);
            }}
            required
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

        <div>
          <Label htmlFor="update-city-name">Namn</Label>

          <Input
            id="update-city-name"
            type="text"
            value={name}
            maxLength={100}
            onChange={(event) => {
              setName(event.target.value);
            }}
            disabled={loading || !selectedCityId}
            required
          />
        </div>

        <div>
          <Label htmlFor="update-city-picture">Ny bild (valfri)</Label>

          <Input
            ref={fileInputRef}
            id="update-city-picture"
            type="file"
            accept="image/jpeg,image/png,image/webp"
            disabled={loading || !selectedCityId}
            onChange={(event) => {
              setCityPicture(event.target.files?.[0] ?? null);
            }}
          />
        </div>

        <Button type="submit" disabled={loading || !selectedCityId}>
          {loading ? "Uppdaterar..." : "Uppdatera stad"}
        </Button>
      </form>

      {cities.length === 0 && <p>Det finns inga städer.</p>}

      {error && <p role="alert">{error}</p>}

      {updatedCity && (
        <p role="status">Staden {updatedCity.name} uppdaterades.</p>
      )}
    </div>
  );
}
