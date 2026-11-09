import { Button } from "@/components/ui/Button";
import { Label } from "@/components/ui/Label";
import { useState, type SubmitEvent } from "react";
import type { AdminUser } from "@/models/AdminModels";
import { archiveUser } from "@/services/AdminService";

type ArchiveUserProps = {
  users: AdminUser[];
  onUserArchived: (userId: number) => void;
};

export default function ArchiveUser({
  users,
  onUserArchived,
}: ArchiveUserProps) {
  const [selectedUserId, setSelectedUserId] = useState("");
  const [archivedUsername, setArchivedUsername] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const activeUsers = users.filter((user) => !user.isArchived);

  const handleSubmit = async (event: SubmitEvent<HTMLFormElement>) => {
    event.preventDefault();
    if (loading) return;

    setError(null);
    setArchivedUsername(null);

    const selectedUser = activeUsers.find(
      (user) => user.userId === Number(selectedUserId),
    );

    if (!selectedUser) {
      setError("Välj en aktiv användare.");
      return;
    }

    setLoading(true);

    try {
      await archiveUser(selectedUser.userId);

      onUserArchived(selectedUser.userId);
      setArchivedUsername(selectedUser.username);
      setSelectedUserId("");
    } catch (error) {
      const message =
        error instanceof Error
          ? error.message
          : "Kunde inte arkivera användaren.";

      setError(message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <h3>Arkivera användare</h3>

      <form onSubmit={handleSubmit}>
        <div>
          <Label htmlFor="archive-user-select">Aktiv användare</Label>

          <select
            disabled={loading}
            id="archive-user-select"
            value={selectedUserId}
            onChange={(event) => {
              setSelectedUserId(event.target.value);
              setError(null);
              setArchivedUsername(null);
            }}
            required
          >
            <option value="">Välj en användare</option>

            {activeUsers.map((user) => (
              <option key={user.userId} value={user.userId}>
                {user.username} - {user.email}
              </option>
            ))}
          </select>
        </div>

        <Button variant="destructive" type="submit" disabled={loading || !selectedUserId}>
          {loading ? "Arkiverar..." : "Arkivera användare"}
        </Button>
      </form>

      {users.length === 0 && <p>Det finns inga användare.</p>}

      {users.length > 0 && activeUsers.length === 0 && (
        <p>Det finns inga aktiva användare att arkivera.</p>
      )}

      {error && <p role="alert">{error}</p>}

      {archivedUsername && (
        <p role="status">Användaren {archivedUsername} arkiverades.</p>
      )}
    </div>
  );
}
