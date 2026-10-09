import { useState } from 'react'
import axios from 'axios'

import { Badge } from '@/components/ui/Badge'
import { Button } from '@/components/ui/Button'
import {
  Card,
  CardAction,
  CardContent,
  CardHeader,
  CardTitle,
} from '@/components/ui/Card'
import { Input } from '@/components/ui/input'

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

  //Update this to check if user is authenticated and if so, 
  // get the username from the token and set it to name. 
  // If not, set name to empty string.
  // This is a placeholder for now, as authentication is not implemented yet.
  const [isAuthenticated] = useState(false);
  const [playerName, setPlayerName] = useState(""); 
  const [playerResult, setPlayerResult] = useState({UserName: "", IsGuest: !isAuthenticated, FinalScore: 0, CompletedAt: ""});

  const handleGameComplete = (score: number) => {
    setCurrentScore((previousScore) => previousScore + score)
    setGameProgress((previousProgress) => previousProgress + 1)
  }

  const handleSubmitName = async (e: React.ChangeEvent<HTMLFormElement>) => {
      e.preventDefault();
      setPlayerName(e.currentTarget.playerName.value);
  }

  const handleSubmitResult = async (name: string, score: number) => {
      setPlayerResult({UserName: name, IsGuest: !isAuthenticated, FinalScore: score, CompletedAt: new Date().toISOString().split('T')[0]});
      try {
          const response = await axios.post('/api/games', JSON.stringify(playerResult), {
              headers: {
                  'Content-Type': 'application/json'
              }
          });
          console.log(response.data.message, response.data.data);
      } catch (error) {
          console.error('Error submitting result:', error);
      }
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
            <Button onClick={() => setGameProgress(1)} disabled={playerName === ""}>
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
            <Button onClick={() => handleSubmitResult(playerName, currentScore)}>Spara resultat</Button>
            <Button onClick={() => setGameProgress(0)}> Starta om spelet </Button>
          </div>
        )}
      </CardContent>
    </Card>
  )
}

export default TestGame
