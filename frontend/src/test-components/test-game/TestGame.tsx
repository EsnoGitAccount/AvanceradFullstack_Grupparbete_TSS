import { useState } from 'react'
import type { GameResult } from '@/models/GameResult'
import { submitGameResult } from '@/services/GameService'
import { getDailyChallenge } from '@/services/GameService'

import { Badge } from '@/components/ui/Badge'
import { Button } from '@/components/ui/Button'
import {
  Card,
  CardAction,
  CardContent,
  CardHeader,
  CardTitle,
} from '@/components/ui/Card'
import { Input } from '@/components/ui/Input'

import './TestGame.css'

type QuestionProps = {
  onComplete: (score: number) => void
}

function WhereAreWe({ onComplete }: QuestionProps) {
  return (
    <Button variant="outline" onClick={() => onComplete(10)}>
      Var är vi?
    </Button>
  )
}

function DestinationQuestion({ onComplete }: QuestionProps) {
  return (
    <Button variant="outline" onClick={() => onComplete(10)}>
      Svara på destinationsfrågan
    </Button>
  )
}

function TestGame({ city }: { city: string }) {
  const [gameProgress, setGameProgress] = useState(0)
  const [currentScore, setCurrentScore] = useState(0)
  const [dailyChallenge, setDailyChallenge] = useState(null)

  // Update this to check if user is authenticated and if so, 
  // get the username from the token and set it to name. 
  // If not, set name to empty string.
  // This is a placeholder for now, as authentication is not implemented yet.
  const [isAuthenticated] = useState(false);
  const [playerName, setPlayerName] = useState(""); 
  const [resultSubmitted, setResultSubmitted] = useState(false);

  const handleGameStart = async () => {
    const response = await getDailyChallenge(); 
    setDailyChallenge(response);
    console.log("Daily challenge fetched:", response)
    setGameProgress(1)
  }

  const handleGameComplete = (score: number) => {
    setCurrentScore((previousScore) => previousScore + score)
    setGameProgress((previousProgress) => previousProgress + 1)
  }

  const handleSubmitName = async (e: React.ChangeEvent<HTMLFormElement>) => {
      e.preventDefault();
      setPlayerName(e.currentTarget.playerName.value);
  }

  const handleSubmitResult = async (name: string, score: number, id: number | null) => {
      
    console.log("Submitting result for:", name, "with score:", score, "and id:", id);
    const currentResult: GameResult = {
      UserName: name,
      UserID: id, // This should be set to the actual user ID if authenticated
      IsGuest: !isAuthenticated,
      FinalScore: score,
      CompletedAt: new Date().toISOString().split('T')[0], // Format the date as YYYY-MM-DD
    };

    await submitGameResult(currentResult);
    setResultSubmitted(true);
      // if (!isAuthenticated) {
      //     console.log("User is not authenticated. Result will be saved as a guest.");
      //     setPlayerResult({UserName: name, IsGuest: !isAuthenticated, FinalScore: score, CompletedAt: new Date().toISOString().split('T')[0]});
      // }
      // logic for submitting with an id if the user is logged in
  };

  return (
    <Card className="test-game">
      <CardHeader className="test-game__header">
        <CardTitle>
          <h2 className="test-game__title">Dagens testresa</h2>
        </CardTitle>
        <CardAction>
          <Badge>{currentScore} poäng</Badge>
        </CardAction>
      </CardHeader>

      <CardContent className="test-game__content">
        {gameProgress === 0 && (
          <>
            {playerName === "" && (
                <form onSubmit={handleSubmitName}>
                    <label htmlFor="playerName">Namn:</label>
                    <Input type="text" id="playerName" name="playerName" required />
                    <Button className="test-game__submit-name-button" variant="outline" type="submit">Spara namn</Button>
                </form>
            )}
            <Button onClick={() => handleGameStart()} disabled={playerName === ""}>
                Starta spelet
            </Button>
          </>
        )}
        {gameProgress === 1 && (
          <WhereAreWe onComplete={handleGameComplete} />
        )}
        {gameProgress === 2 && (
          <DestinationQuestion onComplete={handleGameComplete} />
        )}
        {gameProgress === 3 && (
          <DestinationQuestion onComplete={handleGameComplete} />
        )}
        {gameProgress === 4 && (
          <div className="test-game__complete">
            <h3>Spelet är klart, {playerName}!</h3>
            <p>Destination: {city}</p>
            <Button onClick={() => handleSubmitResult(playerName, currentScore, null)} disabled={resultSubmitted}>{resultSubmitted ? "Resultat sparat" : "Spara resultat"}</Button>
            <Button onClick={() => setGameProgress(0)}> Starta om spelet </Button>
          </div>
        )}
      </CardContent>
    </Card>
  )
}

export default TestGame
