import { useState, type SubmitEvent } from "react";
import type { AdminGameResult } from "@/models/AdminModels";
import { deleteGame } from "@/services/AdminService";

type DeleteGameProps = {
  games: AdminGameResult[];
  onGameDeleted: (gameId: number) => void;
};

export default function DeleteGame({ games, onGameDeleted }: DeleteGameProps) {
  const [selectedGameId, setSelectedGameId] = useState("");
  const [deletedGameId, setDeletedGameId] = useState<number | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleSubmit = async (event: SubmitEvent<HTMLFormElement>) => {
    event.preventDefault();

    setError(null);
    setDeletedGameId(null);

    const selectedGame = games.find(
      (game) => game.gameId === Number(selectedGameId),
    );

    if (!selectedGame) {
      setError("Välj ett spelresultat.");
      return;
    }

    const confirmed = window.confirm(
      `Vill du radera spelresultat med ID ${selectedGame.gameId}? ` +
        `${selectedGame.userName || "Gäst"}, ` +
        `${selectedGame.cityName}, ${selectedGame.completedAt}.`,
    );

    if (!confirmed) {
      return;
    }

    setLoading(true);

    try {
      await deleteGame(selectedGame.gameId);

      onGameDeleted(selectedGame.gameId);
      setDeletedGameId(selectedGame.gameId);
      setSelectedGameId("");
    } catch (error) {
      const message =
        error instanceof Error
          ? error.message
          : "Kunde inte radera spelresultatet.";

      setError(message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <h3>Radera spelresultat</h3>

      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="delete-game-select">Spelresultat</label>

          <select
            id="delete-game-select"
            value={selectedGameId}
            onChange={(event) => {
              setSelectedGameId(event.target.value);
              setError(null);
              setDeletedGameId(null);
            }}
            required
          >
            <option value="">Välj ett spelresultat</option>

            {games.map((game) => (
              <option key={game.gameId} value={game.gameId}>
                ID {game.gameId} - {game.userName || "Gäst"} - {game.cityName} -{" "}
                {game.completedAt} - {game.totalScore} poäng
              </option>
            ))}
          </select>
        </div>

        <button type="submit" disabled={loading || !selectedGameId}>
          {loading ? "Raderar..." : "Radera spelresultat"}
        </button>
      </form>

      {games.length === 0 && <p>Hämta spelresultaten först.</p>}

      {error && <p role="alert">{error}</p>}

      {deletedGameId !== null && (
        <p role="status">Spelresultat med ID {deletedGameId} raderades.</p>
      )}
    </div>
  );
}
