import { Card, CardContent } from '@/components/ui/Card';
import { type UserProfileDto } from '@/services/ProfileService';
import { TrophyIcon } from "@/assets/icons/Icons";
import { EditAccountModal } from './EditAccount';
import { useState } from 'react';
import { UserRoundCog } from 'lucide-react';

interface ProfileSidebarProps {
    profile: UserProfileDto;
    onAccountDeleted: () => void;
    onUsernameUpdated: (newUsername: string) => void;
}

export function ProfileSidebar({ profile, onAccountDeleted, onUsernameUpdated }: ProfileSidebarProps) {
    const avatarLetter = profile.username ? profile.username.charAt(0).toUpperCase() : '?';
    const [isEditOpen, setIsEditOpen] = useState(false);

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
                className='group bg-[var(--card)] rounded-[20px] p-6 cursor-pointer transition-all duration-200 hover:scale-[1.02] hover:-translate-y-0.5 hover:shadow-md'
                onClick={() => setIsEditOpen(true)}
            >
                <CardContent className='p-0'>
                    <h3 className='relative flex items-center justify-center text-[1.1rem] font-semibold text-[var(--foreground)] m-0'>
                        <UserRoundCog className='w-6 h-6 text-[var(--primary)] absolute left-0' />
                        <span>Kontoinställningar</span>
                    </h3>
                </CardContent>
            </Card>

            <EditAccountModal
                key={isEditOpen ? 'open' : 'closed'}
                isOpen={isEditOpen}
                currentUsername={profile.username}
                onClose={() => setIsEditOpen(false)}
                onUsernameUpdated={onUsernameUpdated}
                onAccountDeleted={onAccountDeleted}
            />
        </div>
    );
}