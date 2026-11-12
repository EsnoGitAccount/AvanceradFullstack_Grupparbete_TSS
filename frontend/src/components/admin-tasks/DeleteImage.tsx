import { Button } from "@/components/ui/Button";
import { Label } from "@/components/ui/Label";
import { Input } from "@/components/ui/Input";
import { useState, type SubmitEvent } from "react";
import { deleteImage } from "@/services/AdminService";

type DeleteImageProps = {
  busy: boolean;
  onLoadingChange: (loading: boolean) => void;
  blobName: string;
  onBlobNameChange: (blobName: string) => void;
  onImageDeleted: () => void;
};

export default function DeleteImage({
  busy,
  onLoadingChange,
  blobName,
  onBlobNameChange,
  onImageDeleted,
}: DeleteImageProps) {
  const [deletedBlobName, setDeletedBlobName] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleSubmit = async (event: SubmitEvent<HTMLFormElement>) => {
    event.preventDefault();
    if (loading || busy) return;

    const trimmedBlobName = blobName.trim();

    setError(null);
    setDeletedBlobName(null);

    if (!trimmedBlobName) {
      setError("Ange ett blobnamn.");
      return;
    }

    setLoading(true);
    onLoadingChange(true);

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
      onLoadingChange(false);
    }
  };

  return (
    <div>
      <h3>Radera bild</h3>

      <form onSubmit={handleSubmit}>
        <div>
          <Label htmlFor="delete-image-name">Blobnamn</Label>

          <Input
            disabled={busy || loading}
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

        <Button variant="destructive" type="submit" disabled={busy || loading || !blobName.trim()}>
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
