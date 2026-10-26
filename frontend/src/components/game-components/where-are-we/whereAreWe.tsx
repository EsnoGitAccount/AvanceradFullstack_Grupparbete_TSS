import { useState } from "react";
import type { Clue } from '../../../models/City.ts'

import { Input } from '@/components/ui/Input'
import { Button } from '@/components/ui/Button'

type WhereAreWeProps = {
  onComplete: (score: number) => void
  clues: Clue[]
  correctCity: string
}

export default function WhereAreWe({ onComplete, clues, correctCity }: WhereAreWeProps){

  const [currentScore, setCurrentScore] = useState(10)
  const [cityGuess, setCityGuess] = useState("");

  const handleWhereAreWeSubmit = (event: React.SubmitEvent) =>{
    event.preventDefault();

    // Checks if the guess and the correct city are the same, ignoring empty spaces and casing
    if(cityGuess.trim().toLocaleLowerCase('sv-SE') === correctCity.trim().toLocaleLowerCase('sv-SE')){
      onComplete(currentScore)
    }

    const nextScore = Math.max(currentScore - 2, 0)
    setCurrentScore(nextScore);

    if(nextScore === 0){
      onComplete(0)
    }
    setCityGuess("");
   }

  return (
    <div>
      {clues.map((clue) => (
        clue.pointValue >= currentScore &&
        <div key={clue.pointValue}>
          <p>För {clue.pointValue} poäng:</p>
          <p>{clue.clueText}</p>
        </div>
        )
      )}

      <form onSubmit={handleWhereAreWeSubmit}>
        <Input value={cityGuess} onChange={(e) => setCityGuess(e.target.value)} placeholder=''/>
        <Button type="submit">Svara</Button>
      </form>
    </div>
  )
}