// Desgin for the progress bar on the question page, 
// showing the current step and total steps in a horizontal layout with circles representing each step.
//  The active step is highlighted with a different color and scale effect.
import { TrainIcon } from "@/assets/icons/TrainIcon"
import { CartIcon } from "@/assets/icons/CartIcon"

interface ProgressStepperProps {
    currentStep: number
    totalSteps?: number
}

export function ProgressStepper({
    currentStep = 1,
    totalSteps = 4
}: ProgressStepperProps) {
    const stepIndex = Math.max(0, Math.min(currentStep - 1, totalSteps - 1))
    return (
        <div className="relative flex items-center justify-between w-full max-w-5xl mx-auto my-6 px-4">
            {/* Background line */}
            <div className="absolute top-1/2 left-8 right-8 h-[2px] bg-[var(--card-border)] -translate-y-1/2 z-0" />

            {Array.from({ length: totalSteps }).map((_, index) => {
                const isTrain = index === stepIndex
                const isCart = index < stepIndex

                return (
                    <div
                        key={index}
                        className={`
              relative z-10 w-10 h-10 rounded-full flex items-center justify-center font-bold text-sm transition-all duration-300
              ${isTrain
                                ? "text-[var(--primary)] scale-150"
                                : isCart
                                    ? "text-[var(--primary)] scale-140"
                                    : "rounded-full bg-[var(--page)] text-[var(--muted-foreground)] border-2 border-[var(--card-border)]"
                            }
            `}
                    >
                        {isTrain ? (
                            <TrainIcon width="35" height="50" />
                        ) : isCart ? (
                            <CartIcon width="30" height="40" />
                        ) : (
                            index + 1
                        )}
                    </div>
                )
            })}
        </div>
    )
}