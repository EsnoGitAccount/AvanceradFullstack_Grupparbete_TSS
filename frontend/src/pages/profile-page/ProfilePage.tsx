import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router'
import { useAuth } from "../../context/auth/UseAuth"
import { type UserProfileDto, getProfile } from '@/services/ProfileService'
import { ProfileSidebar } from '@/components/profile/ProfileSidebar';
import { AchievementsSection } from '@/components/profile/AchievementsSection';
import { ProfileOverview } from '@/components/profile/ProfileOverview';

import "./ProfilePage.css"

function ProfilePage() {
    const navigate = useNavigate();
    const { clearSession, updateUsername } = useAuth();
    const [profile, setProfile] = useState<UserProfileDto | null>(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        getProfile()
            .then(data => {
                setProfile(data);
                setLoading(false);
            })
            .catch(err => {
                console.error("Kunde inte hämta profil:", err);
                setLoading(false);
                if (err.response?.status === 401) {
                    navigate('/login');
                }
            });
    }, [navigate]);

    const handleUsernameUpdated = (newUsername: string) => {
        updateUsername(newUsername);
        setProfile((prev) => (prev ? { ...prev, username: newUsername } : null));
    };

    const handleAccountDeleted = () => {
        clearSession();
        navigate('/homepage');
    };

    if (loading) {
        return <div>Laddar profildata...</div>;
    }

    if (!profile) {
        return <div>Kunde inte hämta profil. Logga in igen.</div>;
    }

    return (
        <div className='profile-page profile-main'>
            <div className='profile-container'>
                <header className='mb-10'>
                    <span className='text-[0.75rem] font-bold tracking-widest text-[var(--primary)] uppercase'>
                        DINA UPPGIFTER
                    </span>
                    <h1 className='text-4xl font-extrabold text-[var(--foreground)] mt-1 mb-2'>
                        Din plats på resan.
                    </h1>
                    <p className='text-base text-[var(--muted-foreground)]'>
                        Håll din reseprofil uppdaterad. Dina poäng och din svit följer med.
                    </p>
                </header>

                <div className='profile-grid'>
                    <ProfileSidebar
                        profile={profile}
                        onAccountDeleted={handleAccountDeleted}
                        onUsernameUpdated={handleUsernameUpdated}
                    />
                    <ProfileOverview profile={profile} />
                </div>

                <AchievementsSection
                    achievements={profile.achievements}
                    unachievedAchievements={profile.unachievedAchievements}
                />
            </div>
        </div>
    );
}
export default ProfilePage;
