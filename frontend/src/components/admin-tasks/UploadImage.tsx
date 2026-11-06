import { useRef, useState, type SubmitEvent } from "react";
import { uploadImage } from "@/services/AdminService";

type UploadImageProps = {
  onImageUploaded: (blobName: string) => void;
};

const allowedImageTypes = ["image/jpeg", "image/png", "image/webp"];

const maxImageSize = 5 * 1024 * 1024;

export default function UploadImage({ onImageUploaded }: UploadImageProps) {
  const fileInputRef = useRef<HTMLInputElement>(null);

  const [file, setFile] = useState<File | null>(null);
  const [uploadedBlobName, setUploadedBlobName] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleSubmit = async (event: SubmitEvent<HTMLFormElement>) => {
    event.preventDefault();

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
    }
  };

  return (
    <div>
      <h3>Ladda upp bild</h3>

      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="upload-image-file">Bild</label>

          <input
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

        <button type="submit" disabled={loading}>
          {loading ? "Laddar upp..." : "Ladda upp bild"}
        </button>
      </form>

      {error && <p role="alert">{error}</p>}

      {uploadedBlobName && (
        <p role="status">Bilden laddades upp. Blobnamn: {uploadedBlobName}</p>
      )}
    </div>
  );
}
