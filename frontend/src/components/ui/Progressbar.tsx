// Desgin for the progress bar on the question page, 
// showing the current step and total steps in a horizontal layout with circles representing each step.
//  The active step is highlighted with a different color and scale effect.
interface ProgressStepperProps {
    currentStep: number
    totalSteps?: number
}

export function ProgressStepper({
    currentStep = 1,
    totalSteps = 4
}: ProgressStepperProps) {
    return (
        <div className="relative flex items-center justify-between w-full max-w-5xl mx-auto my-6 px-4">
            {/* Background line */}
            <div className="absolute top-1/2 left-8 right-8 h-[2px] bg-[var(--card-border)] -translate-y-1/2 z-0" />

            {/* Circles */}
            {Array.from({ length: totalSteps }).map((_, index) => {
                const isActive = index === currentStep

                return (
                    <div
                        key={index}
                        className={`
              relative z-10 w-10 h-10 rounded-full flex items-center justify-center font-bold text-sm transition-all duration-300
              ${isActive
                                ? "bg-[var(--primary)] text-[var(--primary-foreground)] border-2 border-[var(--primary)] scale-110 ring-4 ring-[var(--primary)]/20"
                                : "bg-[var(--page)] text-[var(--muted-foreground)] border-2 border-[var(--card-border)]"
                            }
            `}
                    >
                        {index + 1}
                    </div>
                )
            })}
        </div>
    )
}