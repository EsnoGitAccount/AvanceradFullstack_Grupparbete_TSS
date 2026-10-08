import { useState } from "react";
import WhereAreWe from "../components/WhereAreWe";
import DestinationQuestion from "../components/DestinationQuestion";

export default function TestGame({city} : {city: string}) {
    const [gameProgress, setGameProgress] = useState(0);
    const [currentScore, setCurrentScore] = useState(0);

    const handleGameComplete = (score: number) => {
        setCurrentScore(currentScore + score);
        setGameProgress(gameProgress + 1);
    };

    return(
        <>
            {gameProgress === 0 && (
                <button onClick={() => setGameProgress(1)}> Starta spelet </button>
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
                <div>
                    <h2>Spelet är klart!</h2>
                </div>
            )}
            <div>Din poäng: {currentScore}</div>
        </>
    )
}