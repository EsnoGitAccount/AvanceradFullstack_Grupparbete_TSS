import { useState } from "react";
import type { AdminUser } from "@/models/AdminModels";
import { getAdminUsers } from "@/services/AdminService";

type ListAdminUsersProps = {
  users: AdminUser[];
  onUsersLoaded: (users: AdminUser[]) => void;
};

export default function ListAdminUsers({
  users,
  onUsersLoaded,
}: ListAdminUsersProps) {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleLoadUsers = async () => {
    setLoading(true);
    setError(null);

    try {
      const loadedUsers = await getAdminUsers();
      onUsersLoaded(loadedUsers);
    } catch (error) {
      const message =
        error instanceof Error ? error.message : "Kunde inte hämta användare.";

      setError(message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <h3>Alla användare</h3>

      <button type="button" onClick={handleLoadUsers} disabled={loading}>
        {loading ? "Hämtar..." : "Hämta användare"}
      </button>

      {error && <p role="alert">{error}</p>}

      <ul>
        {users.map((user) => (
          <li key={user.userId}>
            ID: {user.userId} – {user.username} – {user.email} –{" "}
            {user.isArchived ? "Arkiverad" : "Aktiv"}
          </li>
        ))}
      </ul>
    </div>
  );
}
