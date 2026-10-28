import { useEffect, useState } from 'react';
import SiteHeader from '@/components/site-header/SiteHeader'
import SiteFooter from '@/components/site-footer/SiteFooter'
import { Button } from '@/components/ui/Button'
import { useNavigate } from 'react-router'
import { useAuth } from "../../context/auth/UseAuth"
import { type UserProfileDto, getProfile } from '@/services/ProfileService'
import { Card, CardContent } from '@/components/ui/Card'

import "./ProfilePage.css"

function ProfilePage() {
    const navigate = useNavigate();
    const { logout } = useAuth();
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

    const handleLogout = async () => {
        try {
            await logout();
            navigate('/homepage');
        } catch (error) {
            console.error("Misslyckades att logga ut", error);
        }
    };
    if (loading) {
        return <div>Laddar profildata...</div>;
    }

    return (
        <div className='profile-page'>
            <SiteHeader />
            <main className='profile-main'>
                <div className='profile-container'>

                    {/* Top section */}
                    <header className='profile-header'>
                        <span className='profile-subtitle'>DINA UPPGIFTER</span>
                        <h1 className='profile-title'>Din plats på resan.</h1>
                        <p className='profile-description'>
                            Håll din reseprofil uppdaterad. Dina poäng och din svit följer med.
                        </p>
                    </header>

                    <div className='profile-grid'>

                        {/* Left column: Profile info */}
                        <div className='profile-left-col'>
                            <Card className='profile-card-summary'>
                                <CardContent>
                                    {/* <div className='profile-avatar'>{avatarLetter}</div> */}
                                    <h2 className='profile-name'>{profile?.username || 'Användare'}</h2>
                                    <p className='profile-email'>{profile?.email}</p>
                                    <span className='profile-badge'>Nyfiken resenär</span>

                                    <hr className='profile-divider' />

                                    <div className='profile-stats'>
                                        <span> {profile?.currentStreak ?? 0} dagars svit</span>
                                    </div>
                                </CardContent>
                            </Card>

                            <Card className='profile-card-privacy'>
                                <CardContent>
                                    <h3>En popup på denna ruta för att kunna ändra uppgifter?</h3>
                                    <p>
                                        Redigera UserName, ändra lösenord & ta bort konto
                                    </p>
                                </CardContent>
                            </Card>

                            <Button
                                type="button"
                                variant="outline"
                                onClick={handleLogout}
                                className="logout-btn"
                            >
                                Logga ut
                            </Button>
                        </div>

                        {/* Right column: Stats/streak */}
                        <div className='profile-right-col'>
                            <Card className='profile-stats-card'>
                                <CardContent>
                                    {/* TODO: Stats/streak */}
                                </CardContent>
                            </Card>
                        </div>

                    </div>
                </div>
            </main>
            <SiteFooter />
        </div>
    );
}
export default ProfilePage;