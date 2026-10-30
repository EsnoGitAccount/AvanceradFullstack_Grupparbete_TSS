import { Card, CardContent } from '@/components/ui/Card';
import { type UserProfileDto } from '@/services/ProfileService';

interface ProfileOverviewProps {
    profile: UserProfileDto;
}

export function ProfileOverview({ profile }: ProfileOverviewProps) {
    return (
        <div className='profile-right-col'>
            <Card className='bg-white border border-[#e2e8f0] rounded-[20px] min-h-[480px] shadow-[0_2px_8px_rgba(0,0,0,0.02)] p-6'>
                <CardContent className='p-0 flex flex-col gap-6'>
                    <h2 className='text-2xl font-extrabold text-[var(--foreground)] m-0'>
                        Översikt & Statistik
                    </h2>

                    <div className='grid grid-cols-1 gap-4'>
                        {/* Streak */}
                        <div className='bg-[var(--green-card)] p-4 rounded-2xl'>
                            <span className='text-xs font-bold text-[var(--muted-foreground)] uppercase tracking-wider'>
                                Svit
                            </span>
                            <p className='text-2xl font-black text-[var(--foreground)] mt-1 mb-0'>
                                {profile.currentStreak} dagar
                            </p>
                        </div>

                        {/* Todays point */}
                        <div className='bg-[var(--blue-card)] p-4 rounded-2xl'>
                            <span className='text-xs font-bold text-[var(--muted-foreground)] uppercase tracking-wider'>
                                Dagens resultat
                            </span>
                            <p className='text-2xl font-black text-[var(--foreground)] mt-1 mb-0'>
                                {profile.dailyScore ?? 0} p
                            </p>
                        </div>

                        {/* All time score*/}
                        <div className='bg-[var(--yellow-card)] p-4 rounded-2xl'>
                            <span className='text-xs font-bold text-[var(--muted-foreground)] uppercase tracking-wider'>
                                Totalt poäng
                            </span>
                            <p className='text-2xl font-black text-[var(--foreground)] mt-1 mb-0'>
                                {profile.allTimeScore} p
                            </p>
                        </div>
                    </div>
                </CardContent>
            </Card>
        </div>
    );
}