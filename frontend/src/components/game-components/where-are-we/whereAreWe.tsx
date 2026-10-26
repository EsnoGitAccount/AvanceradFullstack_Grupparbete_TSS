import { useState } from "react";
import type { Clue } from '../../../models/City.ts'
import placeholderImg from '../../../assets/images/photo-example.jpg'

import { Input } from '@/components/ui/Input'
import { Button } from '@/components/ui/Button'

import './whereAreWe.css'

type WhereAreWeProps = {
  onComplete: (score: number) => void
  clues: Clue[]
  correctCity: string
  imageUrl?: string
}

export default function WhereAreWe({
  onComplete,
  clues,
  correctCity,
  imageUrl = placeholderImg,
}: WhereAreWeProps){

  const [currentScore, setCurrentScore] = useState(10)
  const [cityGuess, setCityGuess] = useState("");

  const handleWhereAreWeSubmit = (event: React.SubmitEvent) =>{
    event.preventDefault();

    // Checks if the guess and the correct city are the same, ignoring empty spaces and casing
    if(cityGuess.trim().toLocaleLowerCase('sv-SE') === correctCity.trim().toLocaleLowerCase('sv-SE')){
      onComplete(currentScore)
    }

    const nextScore = handleNextClue();

    if(nextScore === 0){
      onComplete(0)
    }
    setCityGuess("");
   }

   const handleNextClue = () => {
    const nextScore = Math.max(currentScore - 2, 0)
    setCurrentScore(nextScore);
    return nextScore;
   }

  return (
    <div className="where-are-we__page">
      <section className="where-are-we__main">
        <div className="where-are-we__left-side">
          <h1 className="where-are-we__title">Vart är vi?</h1>
          <img className="where-are-we__image" src={imageUrl} alt="Bild från destinationen" />
        </div>
        <div className="where-are-we__right-side">

        <div className="where-are-we__clues">
          {clues.map((clue) => (
            clue.pointValue >= currentScore &&
            <div key={clue.pointValue} className="clue-entry">
              <p className="clue-entry__points">{clue.pointValue}</p>
              <p>{clue.clueText}</p>
            </div>
            )
          )}

          <Button className="where-are-we__show-clue-button" onClick={handleNextClue} disabled={currentScore <= 2} variant="secondary">
            {currentScore <= 2 ? 'Inga fler ledtrådar!' : 'Visa nästa ledtråd'}
          </Button>
        </div>
  
        <form className="where-are-we__form" onSubmit={handleWhereAreWeSubmit}>
          <Input value={cityGuess} onChange={(e) => setCityGuess(e.target.value)} placeholder='Vart är vi?'/>
          <Button className="where-are-we__submit-button" type="submit">Svara</Button>
        </form>
        </div>
      </section>
    </div>
  )
}