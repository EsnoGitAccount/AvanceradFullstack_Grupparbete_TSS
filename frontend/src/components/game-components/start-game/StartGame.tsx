import {
  Card,
  CardContent,
  CardHeader,
  CardTitle,
  CardFooter,
} from "@/components/ui/Card";
import { Button } from "@/components/ui/Button";
import { Ticket } from "lucide-react";
import "./StartGame.css";
import { Input } from "@/components/ui/Input";
import { TrainTrackAnimation } from "@/assets/illustrations/TrainTrackAnimation";

const gameInstructions = [
  { id: 1, text: "Försök hitta dagens stad. Du har 5 försök." },
  { id: 2, text: "Varje felaktig gissning visar en ny ledtråd." },
  { id: 3, text: "Du får poäng baserat på hur tidigt du hittar rätt stad." },
  { id: 4, text: "Efter du har hittad staden får du svara på ett antal frågor om staden.", },
  { id: 5, text: "När du spelat klart får du ett resultat och hur du rankade mot andra spelare." },
];

type StartGameProps = {
  handleStart: (userName: string) => void;
  isAuthenticated: boolean;
  guestUserName: string;
  setGuestUserName: (name: string) => void;
  authenticatedUserName: string;
};
function StartGameTest({
  handleStart,
  isAuthenticated,
  guestUserName,
  setGuestUserName,
  authenticatedUserName,

}: StartGameProps) {
  const currentDate = new Date().toLocaleDateString("sv-SE", {
    day: "numeric",
    month: "long",
    year: "numeric",
  });

  return (
    <div className="start-game-page">
      <div className="start-game">
        <header className="start-game__header">
          <span className="start-game__date">
            DAGENS SPEL · {currentDate}
          </span>
          <h1 className="start-game__title">Alla ombord!</h1>

          <p className="start-game__description">
            Tre stopp, tre chanser att visa hur väl du känner Sverige.
          </p>
        </header>

        <div className="start-game__layout">
          <div className="start-game__left-column">
            <Card className="start-game__card">
              <CardHeader>
                <div className="start-game__ticket">
                  <span className="start-game__ticket-number">
                    DIN BILJETT · NR 281
                  </span>
                  <span className="start-game__points">Max 30 poäng</span>
                </div>
                <CardTitle>Så går dagens resa till:</CardTitle>
              </CardHeader>

              <CardContent>
                <div className="start-game__instructions">
                  {gameInstructions.map((instruction) => (
                    <div
                      key={instruction.id}
                      className="start-game__instruction"
                    >
                      <div className="flex h-10 w-10 items-center justify-center rounded-full bg-neutral-200 text-teal-700 font-bold">
                        {String(instruction.id).padStart(2, "0")}
                      </div>
                      <p className="flex-1 text-sm text-cyan">
                        {instruction.text}
                      </p>
                    </div>
                  ))}
                </div>
              </CardContent>

              <CardFooter className="start-game__footer">
                <form
                  onSubmit={(e) => {
                    e.preventDefault();

                    handleStart(
                      isAuthenticated
                        ? authenticatedUserName
                        : guestUserName.trim(),
                    );
                  }}
                >
                  {!isAuthenticated && (
                    <Input
                      type="text"
                      placeholder="Ange ditt namn"
                      value={guestUserName}
                      onChange={(e) => setGuestUserName(e.target.value)}
                      required
                    />
                  )}

                  <Button type="submit" size="lg" className="h-10 w-full mt-3.5">
                    Starta resan
                  </Button>
                  <p className="text-xs text-muted-foreground text-center mt-2">
                    Ingen tidspress. Din första gissning räknas.
                  </p>
                </form>
              </CardFooter>
            </Card>
          </div>

          <div className="start-game__sidebar">
            <div className="start-game__animation-container w-full overflow-visible">
              <TrainTrackAnimation />

            </div>
            <Card className="start-game__info-card">
              <CardHeader className="start-game__info-header">
                <Ticket size={20} className="start-game__info-icon" />
                <CardTitle className="start-game__info-title">
                  Res lätt. Tänk stort.
                </CardTitle>
              </CardHeader>

              <div className="start-game__ticket-divider" />

              <CardContent>
                <p className="start-game__info-description">
                  Du behöver bara din nyfikenhet. Stor bokstav spelar
                  ingen roll, och vanliga stavningsvarianter godkänns.
                </p>
              </CardContent>
            </Card>
          </div>
        </div>
      </div>
    </div>
  );
}

export default StartGameTest;