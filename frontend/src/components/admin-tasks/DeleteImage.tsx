import { Button } from "@/components/ui/Button";
import { Label } from "@/components/ui/Label";
import { Input } from "@/components/ui/Input";
import { useState, type SubmitEvent } from "react";
import { deleteImage } from "@/services/AdminService";

type DeleteImageProps = {
  blobName: string;
  onBlobNameChange: (blobName: string) => void;
  onImageDeleted: () => void;
};

export default function DeleteImage({
  blobName,
  onBlobNameChange,
  onImageDeleted,
}: DeleteImageProps) {
  const [deletedBlobName, setDeletedBlobName] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleSubmit = async (event: SubmitEvent<HTMLFormElement>) => {
    event.preventDefault();

    const trimmedBlobName = blobName.trim();

    setError(null);
    setDeletedBlobName(null);

    if (!trimmedBlobName) {
      setError("Ange ett blobnamn.");
      return;
    }

    setLoading(true);

    try {
      await deleteImage(trimmedBlobName);

      setDeletedBlobName(trimmedBlobName);
      onImageDeleted();
    } catch (error) {
      const message =
        error instanceof Error ? error.message : "Kunde inte radera bilden.";

      setError(message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <h3>Radera bild</h3>

      <form onSubmit={handleSubmit}>
        <div>
          <Label htmlFor="delete-image-name">Blobnamn</Label>

          <Input
            id="delete-image-name"
            type="text"
            value={blobName}
            onChange={(event) => {
              onBlobNameChange(event.target.value);
              setError(null);
              setDeletedBlobName(null);
            }}
            required
          />
        </div>

        <Button variant="destructive" type="submit" disabled={loading || !blobName.trim()}>
          {loading ? "Raderar..." : "Radera bild"}
        </Button>
      </form>

      {error && <p role="alert">{error}</p>}

      {deletedBlobName && (
        <p role="status">Bilden {deletedBlobName} raderades.</p>
      )}
    </div>
  );
}
