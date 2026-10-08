import { useState } from 'react'

import { Badge } from '@/components/ui/Badge'
import { Button } from '@/components/ui/Button'
import {
  Card,
  CardAction,
  CardContent,
  CardHeader,
  CardTitle,
} from '@/components/ui/Card'

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

  const handleGameComplete = (score: number) => {
    setCurrentScore((previousScore) => previousScore + score)
    setGameProgress((previousProgress) => previousProgress + 1)
  }

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
          <Button onClick={() => setGameProgress(1)}>Starta spelet</Button>
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
            <h3>Spelet är klart!</h3>
            <p>Destination: {city}</p>
          </div>
        )}
      </CardContent>
    </Card>
  )
}

export default TestGame
