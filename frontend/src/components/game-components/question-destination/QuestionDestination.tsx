import { useCallback, useEffect, useRef, useState } from 'react'
import { Button } from '@/components/ui/Button'
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/Card'
import './QuestionDestination.css'

import type { Question } from '@/models/City'
import type { DailyChallenge } from '@/models/DailyChallenge'
import { GAME_RULES } from '@/constants/gameConstants'

const SECONDS_PER_QUESTION = 15;

type QuestionDestinationProps = {
    onComplete: (score: number) => void
    dailyChallange: DailyChallenge
    previousScore: number
    onStepChange?: (index: number) => void
}

export default function QuestionDestination({ onComplete, dailyChallange, previousScore, onStepChange }: QuestionDestinationProps) {
    const [currentQuestionIndex, setCurrentQuestionIndex] = useState<number>(0)
    const [selectedOption, setSelectedOption] = useState<string | null>(null)
    const [score, setScore] = useState<number>(0)
    const [remainingSeconds, setRemainingSeconds] = useState<number>(SECONDS_PER_QUESTION)
    const [hasTimedOut, setHasTimedOut] = useState<boolean>(false)
    const [challengeQuestions] = useState<Question[]>(
        dailyChallange.cityDetails.questions
    );

    const answeredQuestion = useRef<number | null>(null)

    const questionDeadline = useRef<{ questionIndex: number; endsAt: number } | null>(null)

    const feedbackTimer = useRef<ReturnType<typeof setTimeout> | null>(null)

    const currentQuestion = challengeQuestions[currentQuestionIndex]
    const hasAnswered = selectedOption !== null || hasTimedOut

    const handleSelectOption = useCallback((optionText: string | null, isCorrect: boolean) => {
        if (answeredQuestion.current === currentQuestionIndex) {
            return;
        }

        answeredQuestion.current = currentQuestionIndex;

        const endsAt = questionDeadline.current?.endsAt ?? Date.now();

        const secondsLeft = Math.max(
            0,
            Math.ceil((endsAt - Date.now()) / 1000)
        );

        const timedOut = optionText === null || secondsLeft <= 0;

        const newScore = score + (isCorrect && !timedOut ? GAME_RULES.destinationQuestionScore : 0);

        setRemainingSeconds(secondsLeft);
        setHasTimedOut(timedOut);
        setSelectedOption(timedOut ? null : optionText);
        setScore(newScore);

        feedbackTimer.current = setTimeout(() => {
            feedbackTimer.current = null;

            if (currentQuestionIndex < challengeQuestions.length - 1) {
                const nextIndex = currentQuestionIndex + 1;

                setSelectedOption(null);
                setHasTimedOut(false);
                setRemainingSeconds(SECONDS_PER_QUESTION);
                setCurrentQuestionIndex(nextIndex);

                onStepChange?.(nextIndex);
            }

            else {
                onComplete(newScore);
            }
        }, timedOut ? 3000 : 3000);
    }, [currentQuestionIndex, challengeQuestions.length, score, onComplete, onStepChange]);

    useEffect(() => () => {
        if (feedbackTimer.current !== null) clearTimeout(feedbackTimer.current);
    }, [])

    // Get the active question based on the current index
    useEffect(() => {
        if (
            questionDeadline.current?.questionIndex !==
            currentQuestionIndex
        ) {
            questionDeadline.current = {
                questionIndex: currentQuestionIndex,
                endsAt: Date.now() + SECONDS_PER_QUESTION * 1000,
            };
        }

        const timer = window.setInterval(() => {
            if (answeredQuestion.current === currentQuestionIndex) {
                return;
            }

            const endsAt =
                questionDeadline.current?.endsAt ?? Date.now();

            const secondsLeft = Math.max(
                0,
                Math.ceil((endsAt - Date.now()) / 1000)
            );

            setRemainingSeconds(secondsLeft);

            if (secondsLeft === 0) {
                handleSelectOption(null, false);
            }
        }, 100);

        return () => window.clearInterval(timer);
    }, [currentQuestionIndex, handleSelectOption]);

return (
    <div className="question-page">
        <div className="question-page__main">
            <section className="question-page__hero">
                <div className="question-page__grid">

                    <div className="question-page__left-column">
                        <Card className="question-card">
                            <CardHeader>
                                <p className="question-card__eyebrow">
                                    STOPP 0{currentQuestionIndex + 1} · {dailyChallange.cityDetails.cityName}
                                </p>
                                <CardTitle className="question-card__title">
                                    {currentQuestion.questionText}
                                </CardTitle>
                                <CardDescription>
                                    Tänk efter och välj ditt svar, du har ett försök på den här frågan.
                                </CardDescription>
                                <div role="timer" aria-label="Återstående tid">
                                    <strong>{remainingSeconds} sekunder kvar</strong>
                                </div>

                                {hasTimedOut && (
                                    <p role="status">
                                        Tiden är ute! Frågan ger 0 poäng.
                                    </p>
                                )}
                            </CardHeader>

                            <CardContent>
                                <div className="question-card__options-grid">
                                    {currentQuestion.options.map((option, index) => {
                                        const isSelected = selectedOption === option.optionText;

                                        let answerClass = "";

                                        if (hasAnswered) {
                                            if (option.isCorrect) {
                                                answerClass = "answer-correct";
                                            } else if (isSelected) {
                                                answerClass = "answer-wrong";
                                            }
                                        }

                                        return (
                                            <Button
                                                key={index}
                                                variant="outline"
                                                className={`question-card__option-button ${answerClass}`}
                                                onClick={() =>
                                                    handleSelectOption(option.optionText, option.isCorrect)
                                                }
                                                disabled={hasAnswered}
                                            >
                                                {option.optionText}
                                            </Button>
                                        );
                                    })}
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
                                <div className="info-card__score">{score + previousScore} / {GAME_RULES.maxScore}</div>
                                <div className="info-card__remaining">{20 - (currentQuestionIndex * 10)} p</div>
                            </CardContent>
                        </Card>

                        <Card className="info-card info-card--yellow">
                            <CardHeader>
                                <CardTitle className="info-card__title">
                                    Tänk efter.
                                </CardTitle>
                                <CardDescription className="info-card__description">
                                    Varje fråga här ger 10 poäng, så tänk efter noga innan du svarar.
                                </CardDescription>
                            </CardHeader>
                            <CardContent>
                                <p className="info-card__footer-text">
                                    2 frågor · 10 poäng per fråga · Ingen tidspress
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

