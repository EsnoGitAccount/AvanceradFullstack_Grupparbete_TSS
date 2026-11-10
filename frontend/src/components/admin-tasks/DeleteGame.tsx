import { Button } from "@/components/ui/Button";
import { Label } from "@/components/ui/Label";
import { useState, type SubmitEvent } from "react";
import type { AdminGameResult } from "@/models/AdminModels";
import { deleteGame } from "@/services/AdminService";
import StaticMessage from "@/components/message/StaticMessage";

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
    if (loading) return;

    setError(null);
    setDeletedGameId(null);

    const selectedGame = games.find(
      (game) => game.gameId === Number(selectedGameId),
    );

    if (!selectedGame) {
      setError("Välj ett spelresultat.");
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
          <Label htmlFor="delete-game-select">Spelresultat</Label>

          <select
            disabled={loading}
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

        <Button variant="destructive" type="submit" disabled={loading || !selectedGameId}>
          {loading ? "Raderar..." : "Radera spelresultat"}
        </Button>
      </form>

      {games.length === 0 && <p>Det finns inga spelresultat.</p>}

      {error && <StaticMessage type="error" message={error} />}

      {deletedGameId !== null && (
        <p role="status">Spelresultat med ID {deletedGameId} raderades.</p>
      )}
    </div>
  );
}
