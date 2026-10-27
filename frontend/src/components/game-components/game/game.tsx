// React + Axios
import { useState, useEffect, useRef } from "react"
import axios from "axios";
import { LoaderCircle } from "lucide-react"

// Components
import QuestionDestination from "../question-destination/QuestionDestination";
import WhereAreWe from "../where-are-we/whereAreWe"
import StartGameTest  from "@/test-components/start-game-test/StartGameTest";
import Leaderboard from "../leaderboard/Leaderboard";   

// Constants
import { GAME_RULES } from "@/constants/gameConstants";

// Services
import { submitGameResult, getDailyChallenge } from "@/services/GameService";

// Types
import type { DailyChallenge } from "@/models/DailyChallenge";
import type { GameResult } from "@/models/GameResult";

export default function Game() {
    const [dailyChallenge, setDailyChallenge] = useState<DailyChallenge | null>(null)
    const [currentScore, setCurrentScore] = useState<number>(0)
    const [gameState, setGameState] = useState<GameState>({
        phase: {type: "notStarted"},
        score: 0,
        playerName: ""
    });
    const [isLoading, setIsloading] = useState<boolean>(true)
    const [loadingMessage, setLoadingMessage] = useState<string>("")
    const [isSavingResult, setIsSavingResult] = useState<boolean>(false)
    const [isAuthenticated, setIsAuthenticated] = useState<boolean>(false)
    const [fakeUser] = useState<FakeUser>({
        userName: "AdamTest",
        userId: 1
    })
    const [guestUserName, setGuestUserName] = useState<string>("")
    const hasSubmittedResult = useRef(false)

    type GamePhase =
        | { type: 'notStarted' }
        | { type: 'whereAreWe' }
        | { type: 'destinationQuestion'; questionIndex: number }
        | { type: 'leaderboard'}

    type GameState = {
        phase: GamePhase
        score: number
        playerName: string
    }

    type FakeUser = {
        userName: string
        userId: number
    }

    useEffect (() => {
        async function loadChallenge(){
            try{
                setLoadingMessage("Laddar dagsutmaningen...")
                const responseData = await getDailyChallenge()
                setDailyChallenge(responseData)
            }
            catch(error: unknown){
                const message = axios.isAxiosError(error)
                ? error.message
                : "Något gick fel men meddelandet kunde inte läsas"

                console.log(message)
            }
            finally{
                setIsloading(false)
            }
        }
        
        // TO DO: Check if the user is authenticated
        // If authenticated change gameState.playerName to user
        loadChallenge();
    }, [])

    function handleStart(userName: string){
        setGameState((previousGameState) => ({
            ...previousGameState,
            phase: {
                type: "whereAreWe"
            },
            playerName: userName
        }))
    }

    function handleWhereAreWeComplete(score: number){
        setCurrentScore((currentScore) => ( currentScore + (score * GAME_RULES.whereAreWeScoreMultiplier)))
        setGameState((previousGameState) => ({
            ...previousGameState,
            phase: {
                type: "destinationQuestion",
                questionIndex: 0
            }
        }))
    }

    function handleQuestionDestinationComplete(score: number){
        // Store final score in a variable to avoid set functions being async and giving not updating value in time
        const finalScore = currentScore + score;
        
        setCurrentScore(finalScore)
        setLoadingMessage("Sparar resultat...")
        setIsSavingResult(true)
        
        setGameState((previousGameState) => ({
            ...previousGameState,
            score: finalScore,
            phase: {
                type: "leaderboard"
            }
        }))
    }

    useEffect(() => {
        if (gameState.phase.type !== "leaderboard" || hasSubmittedResult.current) {
            return
        }

        hasSubmittedResult.current = true

        async function saveResult() {
            // Save the result after the phase changes, rather than during render.
            const result: GameResult = isAuthenticated
                ? {
                    UserID: fakeUser.userId,
                    UserName: fakeUser.userName,
                    FinalScore: gameState.score,
                    IsGuest: false,
                    CompletedAt: new Date().toISOString().slice(0, 10)
                }
                : {
                    UserID: null,
                    UserName: gameState.playerName,
                    FinalScore: gameState.score,
                    CompletedAt: new Date().toISOString().slice(0, 10),
                    IsGuest: true
                }

            try {
                await submitGameResult(result)
            } finally {
                setIsSavingResult(false)
            }
        }

        void saveResult()
    }, [fakeUser.userId, fakeUser.userName, gameState.phase.type, gameState.playerName, gameState.score, isAuthenticated])

    if(isLoading){
        return (
            <div className="question-page">
                <div className="flex flex-col items-center justify-center min-h-[50vh] gap-3">
                    <LoaderCircle className="w-8 h-8 animate-spin text-[var(--primary)]" />
                    <p className="text-sm font-medium text-[var(--muted-foreground)]">
                        {loadingMessage}
                    </p>
                </div>
            </div>
        )
    }

    if(dailyChallenge === null){
        return(
            <div>Kunde inte ladda spelet. Vänligen prova igen senare</div>
        )
    }

    switch(gameState.phase.type){
        case "notStarted":
            return (
                <>
                    <StartGameTest handleStart={handleStart} 
                    isAuthenticated={isAuthenticated}
                     guestUserName={guestUserName} 
                     setGuestUserName={setGuestUserName}
                     authenticatedUserName={fakeUser.userName}
                     dailyChallenge={dailyChallenge}
                     />

                    <label>
                        <input type="checkbox" checked={isAuthenticated} onChange={(e) => setIsAuthenticated(e.target.checked)}/>
                        Authenticated
                    </label>

                </>
            )
        
        case "whereAreWe":
            return(
                <WhereAreWe
                    onComplete={handleWhereAreWeComplete}
                    clues={dailyChallenge.cityDetails.clues}
                    correctCity={dailyChallenge.cityDetails.cityName}
                    // imageUrl={dailyChallenge.cityDetails.imageUrl}
                />
            )
        
        case "destinationQuestion":
            return(
                <QuestionDestination
                    onComplete={handleQuestionDestinationComplete}
                    dailyChallange={dailyChallenge}
                    previousScore={currentScore}
                />
            )

        case "leaderboard":
            if (isSavingResult) {
                return (
                    <div className="question-page">
                        <div className="flex flex-col items-center justify-center min-h-[50vh] gap-3">
                            <LoaderCircle className="w-8 h-8 animate-spin text-[var(--primary)]" />
                            <p className="text-sm font-medium text-[var(--muted-foreground)]">
                                {loadingMessage}
                            </p>
                        </div>
                    </div>
                )
            }

            return(
                <Leaderboard />
            )
        }
}