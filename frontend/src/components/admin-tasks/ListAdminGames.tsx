import { useState } from "react";
import type { AdminGameResult } from "@/models/AdminModels";
import { getAdminGames } from "@/services/AdminService";

type ListAdminGamesProps = {
  games: AdminGameResult[];
  onGamesLoaded: (games: AdminGameResult[]) => void;
};

export default function ListAdminGames({
  games,
  onGamesLoaded,
}: ListAdminGamesProps) {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleLoadGames = async () => {
    setLoading(true);
    setError(null);

    try {
      const loadedGames = await getAdminGames();
      onGamesLoaded(loadedGames);
    } catch (error) {
      const message =
        error instanceof Error
          ? error.message
          : "Kunde inte hämta spelresultat.";

      setError(message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <h3>Alla spelresultat</h3>

      <button type="button" onClick={handleLoadGames} disabled={loading}>
        {loading ? "Hämtar..." : "Hämta spelresultat"}
      </button>

      {error && <p role="alert">{error}</p>}

      <ul>
        {games.map((game) => (
          <li key={game.gameId}>
            Spel-ID: {game.gameId} – Spelare: {game.userName || "Gäst"} –
            Användar-ID: {game.userId ?? "Gäst"} – Poäng: {game.totalScore} –
            Datum: {game.completedAt} – Stad: {game.cityName}
          </li>
        ))}
      </ul>
    </div>
  );
}
