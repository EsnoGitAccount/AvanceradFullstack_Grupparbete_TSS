import { Card, CardContent } from '@/components/ui/Card';
import { Button } from '@/components/ui/Button';
import { type UserProfileDto } from '@/services/ProfileService';
import { TrophyIcon } from "@/assets/icons/Icons"

interface ProfileSidebarProps {
    profile: UserProfileDto;
    onLogout: () => void;
    onOpenEditModal?: () => void;
}

export function ProfileSidebar({ profile, onLogout, onOpenEditModal }: ProfileSidebarProps) {
    const avatarLetter = profile.username ? profile.username.charAt(0).toUpperCase() : '?';

    const latestAchievement = profile.achievements && profile.achievements.length > 0
        ? profile.achievements[profile.achievements.length - 1].name
        : 'Nykomling'; // Fallback 

    return (
        <div className='profile-left-col'>
            {/* Profilecard */}
            <Card className='bg-[var(--blue-card)] border-none rounded-[20px] p-6'>
                <CardContent className='p-0'>
                    <div className='w-[70px] h-[70px] rounded-full bg-[var(--yellow-card)] text-[var(--primary)] flex items-center justify-center text-2xl font-bold mb-4'>
                        {avatarLetter}
                    </div>

                    <h2 className='text-[1.75rem] font-bold text-[var(--foreground)] m-0'>
                        {profile.username}
                    </h2>

                    <span className='inline-block bg-[var(--illustration-sky-bottom)] text-[var(--primary)] text-xs font-semibold px-3 py-1 rounded-xl mb-2 mt-2'>
                        {latestAchievement}
                    </span>

                    <hr className='border-t border-black/10 my-4' />

                    <div className='text-base font-semibold text-[var(--foreground)] flex items-center gap-2'>
                        <TrophyIcon className='w-5 h-5 text-[var(--primary)]' />
                        <span>{profile.currentStreak} dagars svit</span>
                    </div>
                </CardContent>
            </Card>

            {/* Popup */}
            <Card
                className='bg-white border border-[#e2e8f0] rounded-[20px] p-6 cursor-pointer hover:shadow-sm transition-shadow'
                onClick={onOpenEditModal}
            >
                <CardContent className='p-0'>
                    <h3 className='text-[1.1rem] font-semibold text-[var(--foreground)] mb-2'>
                        En popup på denna ruta för att kunna ändra uppgifter?
                    </h3>
                    <p className='text-xs text-[var(--chart-2)] leading-relaxed m-0'>
                        Redigera UserName, ändra lösenord & ta bort konto
                    </p>
                </CardContent>
            </Card>

            <Button
                type="button"
                variant="outline"
                onClick={onLogout}
                className='mt-2 rounded-xl'
            >
                Logga ut
            </Button>
        </div>
    );
}