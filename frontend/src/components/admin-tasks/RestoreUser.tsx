import { Button } from "@/components/ui/Button";
import { Label } from "@/components/ui/Label";
import { useState, type SubmitEvent } from "react";
import type { AdminUser } from "@/models/AdminModels";
import { restoreUser } from "@/services/AdminService";

type RestoreUserProps = {
  users: AdminUser[];
  onUserRestored: (userId: number) => void;
};

export default function RestoreUser({
  users,
  onUserRestored,
}: RestoreUserProps) {
  const [selectedUserId, setSelectedUserId] = useState("");
  const [restoredUsername, setRestoredUsername] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const archivedUsers = users.filter((user) => user.isArchived);

  const handleSubmit = async (event: SubmitEvent<HTMLFormElement>) => {
    event.preventDefault();
    if (loading) return;

    setError(null);
    setRestoredUsername(null);

    const selectedUser = archivedUsers.find(
      (user) => user.userId === Number(selectedUserId),
    );

    if (!selectedUser) {
      setError("Välj en arkiverad användare.");
      return;
    }

    setLoading(true);

    try {
      await restoreUser(selectedUser.userId);

      onUserRestored(selectedUser.userId);
      setRestoredUsername(selectedUser.username);
      setSelectedUserId("");
    } catch (error) {
      const message =
        error instanceof Error
          ? error.message
          : "Kunde inte återställa användaren.";

      setError(message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <h3>Återställ användare</h3>

      <form onSubmit={handleSubmit}>
        <div>
          <Label htmlFor="restore-user-select">Arkiverad användare</Label>

          <select
            disabled={loading}
            id="restore-user-select"
            value={selectedUserId}
            onChange={(event) => {
              setSelectedUserId(event.target.value);
              setError(null);
              setRestoredUsername(null);
            }}
            required
          >
            <option value="">Välj en användare</option>

            {archivedUsers.map((user) => (
              <option key={user.userId} value={user.userId}>
                {user.username} - {user.email}
              </option>
            ))}
          </select>
        </div>

        <Button type="submit" disabled={loading || !selectedUserId}>
          {loading ? "Återställer..." : "Återställ användare"}
        </Button>
      </form>

      {users.length === 0 && <p>Det finns inga användare.</p>}

      {users.length > 0 && archivedUsers.length === 0 && (
        <p>Det finns inga arkiverade användare att återställa.</p>
      )}

      {error && <p role="alert">{error}</p>}

      {restoredUsername && (
        <p role="status">Användaren {restoredUsername} återställdes.</p>
      )}
    </div>
  );
}
