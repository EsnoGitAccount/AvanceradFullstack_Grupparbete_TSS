import { useState } from 'react'
import { Button } from '@/components/ui/Button'
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/Card'
import './QuestionDestination.css'
import { ProgressStepper } from '@/components/ui/Progressbar'

/*
 * TODO (Game Flow):
 * 1. Connect this page with the initial phase of the game 
 * 2. Receive starting score from previous steps and carry it over
 * 3. Update ProgressStepper to reflect overall game progress instead of resetting to 0 on this page.
 */

import type { Question } from '@/models/City'

type QuestionDestinationProps = {
    onComplete: (score: number) => void
    questions: Question[]
}

export default function QuestionDestination({ onComplete, questions }: QuestionDestinationProps) {
    const [currentQuestionIndex, setCurrentQuestionIndex] = useState<number>(0)
    const [selectedOption, setSelectedOption] = useState<string | null>(null)
    const [score, setScore] = useState<number>(0)

    const [challengeQuestions] = useState<Question[]>(questions)

    // Get the active question based on the current index
    const currentQuestion = challengeQuestions[currentQuestionIndex]

    const handleSelectOption = (optionText: string, isCorrect: boolean) => {
        setSelectedOption(optionText)

        // Calculate new score based on whether the selected option is correct
        const newScore = isCorrect ? score + 10 : score
        if (isCorrect) {
            setScore(newScore)
        }

        setTimeout(() => {
            if (currentQuestionIndex < challengeQuestions.length - 1) {
                setCurrentQuestionIndex((prev) => prev + 1)
                setSelectedOption(null)
            } else {
                console.log("Alla frågor besvarade! Slutgiltig poäng:", newScore)
                onComplete(newScore);
            }
        }, 400)
    }

    return (
        <div className="question-page">
            <ProgressStepper currentStep={currentQuestionIndex} totalSteps={4} />
            <div className="question-page__main">
                <section className="question-page__hero">
                    <div className="question-page__grid">

                        <div className="question-page__left-column">
                            <Card className="question-card">
                                <CardHeader>
                                    <p className="question-card__eyebrow">
                                        {/*TO DO: Dynamically write city name instead of hardcoding "Stockholm"*/}
                                        STOPP 0{currentQuestionIndex + 1} · {"Stockholm"}
                                    </p>
                                    <CardTitle className="question-card__title">
                                        {currentQuestion.questionText}
                                    </CardTitle>
                                    <CardDescription>
                                        Tänk efter och välj ditt svar, du har ett försök på den här frågan.
                                    </CardDescription>
                                </CardHeader>

                                <CardContent>
                                    <div className="question-card__options-grid">
                                        {currentQuestion.options.map((option, index) => (
                                            <Button
                                                key={index}
                                                variant={selectedOption === option.optionText ? "default" : "outline"}
                                                className="question-card__option-button"
                                                onClick={() => handleSelectOption(option.optionText, option.isCorrect)}
                                                disabled={selectedOption !== null}
                                            >
                                                {option.optionText}
                                            </Button>
                                        ))}
                                    </div>
                                </CardContent>
                            </Card>
                        </div>

                        {/* Placeholder cards  */}
                        <div className="question-page__right-column">
                            <Card className="info-card info-card--blue">
                                <CardHeader className="info-card__header">
                                    <CardTitle className="info-card__stats-title">
                                        <span>DIN POÄNG</span>
                                        <span>KVAR ATT VINNA</span>
                                    </CardTitle>
                                </CardHeader>
                                <CardContent className="info-card__stats-content">
                                    <div className="info-card__score">{score} / 30</div>
                                    <div className="info-card__remaining">{30 - score} p</div>
                                </CardContent>
                            </Card>

                            <Card className="info-card info-card--yellow">
                                <CardHeader>
                                    <CardTitle className="info-card__title">
                                        En bit i taget.
                                    </CardTitle>
                                    <CardDescription className="info-card__description">
                                        Varje stopp är en egen fråga. Svaret här avslöjar inte vart nästa ledtråd tar dig.
                                    </CardDescription>
                                </CardHeader>
                                <CardContent>
                                    <p className="info-card__footer-text">
                                        3 stopp · Max 30 poäng · Ingen tidspress
                                    </p>
                                </CardContent>
                            </Card>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    )
}

