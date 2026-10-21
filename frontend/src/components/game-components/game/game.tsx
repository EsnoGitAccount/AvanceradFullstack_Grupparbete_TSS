// React + Axios
import { useState, useEffect } from "react"
import axios from "axios";

// Components
import QuestionDestination from "../question-destination/questionDestination"
import WhereAreWe from "../where-are-we/whereAreWe"
import { Button } from "../../ui/Button"
import { Input } from "../../ui/Input"

// Services
import { getDailyChallenge } from "@/services/GameService";

// Types
import { testCity } from "@/models/City";
import type { DailyChallenge } from "@/models/DailyChallenge";
import type { GameResult } from "@/models/GameResult";

export default function Game() {
    const [dailyChallenge, setDailyChallenge] = useState<DailyChallenge | null>(null)
    const [gameResult, setGameResult] = useState<GameResult>({
        UserName: null,
        UserID: null,
        FinalScore: 0,
        CompletedAt: "",
        IsGuest: true
    })
    const [currentScore, setCurrentScore] = useState<number>(0)
    const [gameState, setGameState] = useState<GameState>({
        phase: {type: "notStarted"},
        score: 0,
        playerName: ""
    });

    
    type GamePhase =
        | { type: 'notStarted' }
        | { type: 'whereAreWe' }
        | { type: 'destinationQuestion'; questionIndex: number }
        | { type: 'finished' }

    type GameState = {
        phase: GamePhase
        score: number
        playerName: string
    }

    // TO DO: Implement loading dailyChallenge for logic and gamestate
    // useEffect (() => {
    //     async function loadChallenge(){
    //         try{
    //             const responseData = await getDailyChallenge()
    //             setDailyChallenge(responseData)
    //         }
    //         catch(error: unknown){
    //             const message = axios.isAxiosError(error)
    //             ? error.message
    //             : "Något gick fel men meddelandet kunde inte läsas"
    //         }
    //     }
        
    //     // TO DO: Check if the user is authenticated
    //     loadChallenge();
    // }, [])

    function handleStart(guestUserName: string){
                setGameState((previousGameState) => ({
            ...previousGameState,
            phase: {
                type: "whereAreWe"
            },
            playerName: guestUserName
        }))
    }

    function handleWhereAreWeComplete(score: number){
        setCurrentScore((currentScore) => ( currentScore + score))
        setGameState((previousGameState) => ({
            ...previousGameState,
            phase: {
                type: "destinationQuestion",
                questionIndex: 0
            }
        }))
    }

    function handleQuestionDestination(score: number){
        // Store final score in a variable to avoid set functions being async to give a wrong value
        const finalScore = currentScore + score;
        
        setCurrentScore(finalScore)        
        
        setGameState((previousGameState) => ({
            ...previousGameState,
            score: finalScore,
            phase: {
                type: "finished",
                questionIndex: null
            }
        }))
    }

    switch(gameState.phase.type){
        case "notStarted":
            let userName: string = "";
            return <form onSubmit={(event) => {
                        event.preventDefault
                        handleStart(userName)
                        }
                    }>
                        <Input type="text" required={true} placeholder="Username" onChange={(e) => userName = e.target.value}></Input>
                        <Button type="submit">Start</Button>
                    </form>
        
        case "whereAreWe":
            return(
                <WhereAreWe
                    onComplete={handleWhereAreWeComplete}
                    clues={testCity.clues}
                    correctCity={testCity.name}
                />
            )
        
        case "destinationQuestion":
            return(
                <QuestionDestination
                    onComplete={handleQuestionDestination}
                    questions={testCity.questions}
                />
            )

        case "finished":
            return(
                <div>Klar. Grattis {gameState.playerName}! Du fick {gameState.score} poäng</div>
            )
        }
}