import { ArrowRightIcon } from '@/assets/icons/Icons'
import { Button } from '@/components/ui/Button'
import { Card } from '@/components/ui/Card'
import { SwedenMap } from "@/assets/illustrations/SwedenMap"
import { useNavigate } from 'react-router'
import { useAuth } from '@/context/auth/UseAuth'

import './HomePage.css'

function HomePage() {
  const navigate = useNavigate()
  const { user, loading } = useAuth()

  return (
    <div className="home-page home-page__main">
      <section className="home-page__hero">
        <div className="home-page__hero-layout">
          <div className="home-page__hero-copy">
            <p className="home-page__eyebrow">
              EN LITEN RESA. VARJE DAG.
            </p>
            <h1 className="page-title home-page__title">
              Tre stopp. Hela Sverige. Hur långt kan du?
            </h1>
            <p className="home-page__description">
              Kliv ombord på dagens kluriga Sverigeresa. Läs ledtrådarna, skriv ditt svar och samla poäng - en ny resa väntar imorgon.
            </p>
            <div className="home-page__hero-actions">
              <Button onClick={() => navigate('/game')} className="home-page__primary-button">
                Kliv ombord
                <ArrowRightIcon data-icon="inline-end" />
              </Button>
              {!loading && !user && (
                <Button
                  variant="outline"
                  className="home-page__secondary-button"
                  onClick={() => navigate('/login')}
                >
                  Logga in
                </Button>
              )}
            </div>
            <p className="home-page__details">
              Gratis att spela · Massa frågor · Poäng · En gång per dag
            </p>
          </div>
          <Card
            className="home-page__journey-card relative"
            aria-label="Sverigekarta med bonuslägen"
          >
            <SwedenMap className="home-page__journey-card-map" bonusLinks />
          </Card>
        </div>
      </section>
    </div>
  )
}

export default HomePage
