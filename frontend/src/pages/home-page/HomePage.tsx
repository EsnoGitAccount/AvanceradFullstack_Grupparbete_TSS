import { ArrowRightIcon } from '@/assets/icons/Icons'
import SiteFooter from '@/components/site-footer/SiteFooter'
import SiteHeader from '@/components/site-header/SiteHeader'
import { Button } from '@/components/ui/Button'
import { Card } from '@/components/ui/Card'

import { useNavigate } from 'react-router'

import './HomePage.css'


function HomePage() {
  const navigate = useNavigate()

  return (
    <div className="home-page">
      <SiteHeader />
      <main className="home-page__main">
        <section className="home-page__hero">
          <div className="home-page__hero-layout">
            <div className="home-page__hero-copy">
              <p className="home-page__eyebrow">
                EN LITEN RESA. VARJE DAG.
              </p>
              <h1 className="home-page__title">
                Tre stopp. Hela Sverige. Hur långt kan du?
              </h1>
              <p className="home-page__description">
                Kliv ombord på dagens kluriga Sverigeresa. Läs ledtrådarna, skriv ditt svar och samla poäng - en ny resa väntar imorgon.
              </p>
              <div className="home-page__hero-actions">
                <Button onClick={() => navigate('/game')} className="home-page__primary-button">
                  Börja din resa
                  <ArrowRightIcon data-icon="inline-end" />
                </Button>
                <Button
                  variant="outline"
                  className="home-page__secondary-button"
                >
                  Så spelar du
                </Button>
              </div>
              <p className="home-page__details">
                Gratis att spela · Massa frågor · Poäng · En gång per dag
              </p>
            </div>
            <Card
              className="home-page__journey-card"
              aria-label="Dagens Sverigeresa"
            >
            </Card>
          </div>
        </section>
      </main>
      <SiteFooter />
    </div>
  )
}

export default HomePage
