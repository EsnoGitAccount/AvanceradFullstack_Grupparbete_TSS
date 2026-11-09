import { allowedImageTypes, maxImageSize } from "@/constants/imageValidation";
import { Button } from "@/components/ui/Button";
import { Label } from "@/components/ui/Label";
import { Input } from "@/components/ui/Input";
import { useRef, useState, type SubmitEvent } from "react";
import { uploadImage } from "@/services/AdminService";

type UploadImageProps = {
  busy: boolean;
  onLoadingChange: (loading: boolean) => void;
  onImageUploaded: (blobName: string) => void;
};

export default function UploadImage({ onImageUploaded, busy, onLoadingChange }: UploadImageProps) {
  const fileInputRef = useRef<HTMLInputElement>(null);

  const [file, setFile] = useState<File | null>(null);
  const [uploadedBlobName, setUploadedBlobName] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleSubmit = async (event: SubmitEvent<HTMLFormElement>) => {
    event.preventDefault();
    if (loading || busy) return;

    setError(null);
    setUploadedBlobName(null);

    if (!file) {
      setError("Välj en bild.");
      return;
    }

    if (!allowedImageTypes.includes(file.type)) {
      setError("Bilden måste vara JPEG, PNG eller WEBP.");
      return;
    }

    if (file.size > maxImageSize) {
      setError("Bilden får vara högst 5 MB.");
      return;
    }

    setLoading(true);
    onLoadingChange(true);

    try {
      const result = await uploadImage(file);

      setUploadedBlobName(result.blobName);
      onImageUploaded(result.blobName);
      setFile(null);

      if (fileInputRef.current) {
        fileInputRef.current.value = "";
      }
    } catch (error) {
      const message =
        error instanceof Error ? error.message : "Kunde inte ladda upp bilden.";

      setError(message);
    } finally {
      setLoading(false);
      onLoadingChange(false);
    }
  };

  return (
    <div>
      <h3>Ladda upp bild</h3>

      <form onSubmit={handleSubmit}>
        <div>
          <Label htmlFor="upload-image-file">Bild</Label>

          <Input
            disabled={busy || loading}
            ref={fileInputRef}
            id="upload-image-file"
            type="file"
            accept="image/jpeg,image/png,image/webp"
            onChange={(event) => {
              setFile(event.target.files?.[0] ?? null);
              setError(null);
              setUploadedBlobName(null);
            }}
            required
          />
        </div>

        <Button type="submit" disabled={busy || loading}>
          {loading ? "Laddar upp..." : "Ladda upp bild"}
        </Button>
      </form>

      {error && <p role="alert">{error}</p>}

      {uploadedBlobName && (
        <p role="status">Bilden laddades upp. Blobnamn: {uploadedBlobName}</p>
      )}
    </div>
  );
}
