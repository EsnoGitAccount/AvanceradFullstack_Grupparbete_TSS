import { Card, CardContent } from '@/components/ui/Card';
import { type AchievementDto } from '@/services/ProfileService';

interface AchievementsSectionProps {
    achievements: AchievementDto[];
}

export function AchievementsSection({ achievements }: AchievementsSectionProps) {
    return (
        <Card className='mt-8 bg-white border border-[var(--card-border)] rounded-[20px] p-6 md:p-8 shadow-[0_2px_8px_rgba(0,0,0,0.02)]'>
            <CardContent className='p-0'>
                <h2 className='text-[1.75rem] font-extrabold text-[var(--foreground)] mb-6'>
                    Dina utmärkelser
                </h2>

                <div className='achievements-grid'>
                    {achievements.length > 0 ? (
                        achievements.map((ach, index) => (
                            <div key={index} className='achievement-tile bg-[var(--green-card)] rounded-2xl p-5'>
                                <h4 className='text-base font-bold text-[var(--foreground)] mb-1'>
                                    {ach.name}
                                </h4>
                                <p className='text-[0.825rem] text-[var(--chart-4)] leading-snug m-0'>
                                    {ach.description}
                                </p>
                            </div>
                        ))
                    ) : (
                        <p className='text-sm text-[var(--chart-4)]'>Inga utmärkelser ännu.</p>
                    )}
                </div>
            </CardContent>
        </Card>
    );
}