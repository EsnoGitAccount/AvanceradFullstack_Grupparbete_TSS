import SiteHeader from '@/components/site-header/SiteHeader'
import SiteFooter from '@/components/site-footer/SiteFooter'
import { Button } from '@/components/ui/Button'
import { useNavigate } from 'react-router'
import { useAuth } from "../../context/auth/UseAuth"

import "./ProfilePage.css"

function ProfilePage() {
    const navigate = useNavigate();
    const { logout } = useAuth();

    const handleLogout = async () => {
        try {
            await logout();
            navigate('/homepage');
        } catch (error) {
            console.error("Misslyckades att logga ut", error);
        }
    };

    return (
        <div className='profile-page'>
            <SiteHeader />

            <section>

                <p>Här är vår profil sida</p>
                <Button
                    type="button"
                    onClick={handleLogout}
                >
                    Logga ut
                </Button>

            </section>

            <SiteFooter />

        </div>

    );
}
export default ProfilePage;