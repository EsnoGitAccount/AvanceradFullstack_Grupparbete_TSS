import { Link } from 'react-router'

import logo from '@/assets/logos/logo-transparent.svg'
import { Button } from '@/components/ui/Button'

import './SiteHeader.css'

function SiteHeader() {
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
          <Button variant="ghost" className="site-header__login-button">
            Logga in
          </Button>
          <Button className="site-header__account-button">Skapa konto</Button>
        </div>
      </div>
    </header>
  )
}

export default SiteHeader
