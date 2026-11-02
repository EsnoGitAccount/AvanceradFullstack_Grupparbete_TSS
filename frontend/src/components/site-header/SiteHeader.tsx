import { Link, useNavigate } from 'react-router'
import { useAuth } from "../../context/auth/UseAuth"
import { useState } from 'react'

import logo from '@/assets/logos/logo-transparent.svg'
import { Button } from '@/components/ui/Button'

import './SiteHeader.css'

function SiteHeader() {
  const navigate = useNavigate();
  const { user, loading, logout } = useAuth();
  const [loggingOut, setLoggingOut] = useState(false);
  const [logoutError, setLogoutError] = useState('');

  const handleLogout = async () => {
    setLoggingOut(true);
    setLogoutError('');

    try {
      await logout();
      navigate('/homepage');
    } catch {
      setLogoutError('Misslyckades att logga ut. Försök igen.');
    } finally {
      setLoggingOut(false);
    }
  };

  return (
    <header className="site-header">
      <div className="site-header__inner">
        <Link
          to="/homepage"
          className="site-header__logo-link"
          aria-label="Vart är vi? – startsida"
        >
          <img
            src={logo}
            alt="Vart är vi?"
            className="site-header__logo"
          />
        </Link>

        <div className="site-header__actions">
          {!loading && ( user ? (
            <>
          <Button variant="ghost" className="site-header__login-button"
            onClick={() => navigate('/profile')}
          >
            Min profil
          </Button>

          <Button variant="ghost" className="site-header__account-button"
            onClick={handleLogout}
            disabled={loggingOut}
          >
            {loggingOut ? 'Loggar ut...' : 'Logga ut'}
          </Button>
          </>
          ) : (
          <>
          <Button variant="ghost" className="site-header__login-button"
            onClick={() => navigate('/login')}
          >
            Logga in
          </Button>
          <Button className="site-header__account-button" onClick={() => navigate('/register')}>
            Skapa konto
          </Button> 
          </>
          )           
        )}
        </div>
      </div>
      {logoutError && <p role="alert">{logoutError}</p>}
    </header>
  )
}

export default SiteHeader