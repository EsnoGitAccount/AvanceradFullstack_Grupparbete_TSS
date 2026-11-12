import { allowedImageTypes, maxImageSize } from "@/constants/imageValidation";
import { Button } from "@/components/ui/Button";
import { Label } from "@/components/ui/Label";
import { Input } from "@/components/ui/Input";
import { useState, type SubmitEvent } from "react";
import type { AdminCity } from "@/models/AdminModels";
import { createCity } from "@/services/AdminService";

type CreateCityProps = {
  onCityCreated: (city: AdminCity) => void;
};

export default function CreateCity({ onCityCreated }: CreateCityProps) {
  const [name, setName] = useState("");
  const [cityPicture, setCityPicture] = useState<File | null>(null);
  const [createdCity, setCreatedCity] = useState<AdminCity | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleSubmit = async (event: SubmitEvent<HTMLFormElement>) => {
    event.preventDefault();
    if (loading) return;

    const form = event.currentTarget;
    const trimmedName = name.trim();

    setError(null);
    setCreatedCity(null);

    if (!trimmedName) {
      setError("Stadens namn måste anges.");
      return;
    }

    if (trimmedName.length > 100) {
      setError("Stadens namn får vara högst 100 tecken.");
      return;
    }

    if (!cityPicture) {
      setError("En bild måste väljas.");
      return;
    }

    if (!allowedImageTypes.includes(cityPicture.type)) {
      setError("Bilden måste vara JPEG, PNG eller WEBP.");
      return;
    }

    if (cityPicture.size > maxImageSize) {
      setError("Bilden får vara högst 5 MB.");
      return;
    }

    setLoading(true);

    try {
      const newCity = await createCity(trimmedName, cityPicture);

      setCreatedCity(newCity);
      onCityCreated(newCity);

      setName("");
      setCityPicture(null);
      form.reset();
    } catch (error) {
      const message =
        error instanceof Error ? error.message : "Kunde inte skapa staden.";

      setError(message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <h3>Skapa stad</h3>

      <form onSubmit={handleSubmit}>
        <div>
          <Label htmlFor="create-city-name">Namn</Label>

          <Input
            disabled={loading}
            id="create-city-name"
            type="text"
            value={name}
            maxLength={100}
            onChange={(event) => {
              setName(event.target.value);
            }}
            required
          />
        </div>

        <div>
          <Label htmlFor="create-city-picture">Bild</Label>

          <Input
            disabled={loading}
            id="create-city-picture"
            type="file"
            accept="image/jpeg,image/png,image/webp"
            onChange={(event) => {
              setCityPicture(event.target.files?.[0] ?? null);
            }}
            required
          />
        </div>

        <Button type="submit" disabled={loading}>
          {loading ? "Skapar..." : "Skapa stad"}
        </Button>
      </form>

      {error && <p role="alert">{error}</p>}

      {createdCity && (
        <p role="status">
          Staden {createdCity.name} skapades med ID {createdCity.cityId}.
        </p>
      )}
    </div>
  );
}
