// React + Axios
import { useState, useEffect } from "react"
import axios from "axios";
import { LoaderCircle } from "lucide-react"

// Components
import QuestionDestination from "../question-destination/QuestionDestination";
import WhereAreWe from "../where-are-we/whereAreWe"
import { Button } from "../../ui/Button"
import { Input } from "../../ui/Input"

// Services
import { submitGameResult, getDailyChallenge } from "@/services/GameService";

// Types
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
    const [isLoading, setIsloading] = useState<boolean>(true)
    const [loadingMessage, setLoadingMessage] = useState<string>("")
    const [isAuthenticated, setIsAuthenticated] = useState<boolean>(false)
    const [fakeUser] = useState<FakeUser>({
        userName: "AdamTest",
        userId: 1
    })
    const [guestUserName, setGuestUserName] = useState<string>("")

    type GamePhase =
        | { type: 'notStarted' }
        | { type: 'whereAreWe' }
        | { type: 'destinationQuestion'; questionIndex: number }
        | { type: 'gameCompleted' }
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
        setCurrentScore((currentScore) => ( currentScore + score))
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
        
        setGameState((previousGameState) => ({
            ...previousGameState,
            score: finalScore,
            phase: {
                type: "gameCompleted",
                questionIndex: null
            }
        }))
    }

    async function handleGoToLeaderBoard(){
        setLoadingMessage("Sparar resultat...")
        setIsloading(true)

        // Creates a gameresult. Uses userdata if authenticated, guest info if unauthenticated
        // TO DO: Use authenticated user instead of fakeUser
        if(isAuthenticated){
            setGameResult((previousGameResult =>({
                ...previousGameResult,
                UserID: fakeUser.userId,
                UserName: fakeUser.userName,
                FinalScore: gameState.score,
                IsGuest: false
            })))
        }
        else{
            setGameResult((previousGameResult =>({
                ...previousGameResult,
                UserID: null,
                UserName: gameState.playerName,
                FinalScore: gameState.score,
                IsGuest: true
            })))
        }
        try{
            await submitGameResult(gameResult)
        }
        catch(error){
            const message = axios.isAxiosError(error)
            ? error.message
            : "Något gick fel men meddelandet kunde inte läsas"

            console.log(message)
        }
        finally{
            setGameState((previousGameState) => ({
                ...previousGameState,
                phase: {
                    type: "leaderboard",
                    questionIndex: null
                }
            }))

            setIsloading(false)
        }
    }

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
                    <label>
                        <input type="checkbox" checked={isAuthenticated} onChange={(e) => setIsAuthenticated(e.target.checked)}/>
                        Authenticated
                    </label>

                    {!isAuthenticated ? (
                        <form onSubmit={(event) => {
                            event.preventDefault()
                            handleStart(guestUserName)
                        }}>
                            <Input type="text" required={true} placeholder="Username" onChange={(e) => setGuestUserName(e.target.value)}></Input>
                            <Button type="submit">Start</Button>
                        </form>
                    ): (
                        <Button type="button" onClick={() => handleStart(fakeUser.userName)}> Start!</Button>
                    )}
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
                    questions={dailyChallenge.cityDetails.questions}
                />
            )

        case "gameCompleted":
            return(
                <>
                    <p>Klar. Grattis {gameState.playerName}! Du fick {gameState.score} poäng</p>
                    <Button onClick={handleGoToLeaderBoard}>Spara resultat</Button>
                </>
            )
        
        case "leaderboard":

            // TO DO: Render leaderboard instead
            return(
                <div>Leaderboard!</div>
            )
        }
}