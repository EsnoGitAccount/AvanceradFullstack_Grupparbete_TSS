import { ArrowRightIcon } from '@/assets/icons/Icons'
import SiteFooter from '@/components/site-footer/SiteFooter'
import SiteHeader from '@/components/site-header/SiteHeader'
import { Button } from '@/components/ui/Button'
import { Card } from '@/components/ui/Card'

import './HomePage.css'

function HomePage() {
  return (
    <div className="home-page">
      <SiteHeader />
      <main className="home-page__main">
        <section className="home-page__hero">
          <div className="home-page__hero-layout">
            <div className="home-page__hero-copy">
              <p className="home-page__eyebrow">
                Vart fan är vi påväg?
              </p>
              <h1 className="home-page__title">
                Vi lovar att det inte är en "på spåret" kopia
              </h1>
              <p className="home-page__description">
                Tänk er GeoGuesser + vem vill bli miljonär + På spåret. 
                Kan inte bli annat än toppen!
              </p>
              <div className="home-page__hero-actions">
                <Button className="home-page__primary-button">
                  Starta spelet
                  <ArrowRightIcon data-icon="inline-end" />
                </Button>
                <Button
                  variant="outline"
                  className="home-page__secondary-button"
                >
                  Hur gör vi?????
                </Button>
              </div>
              <p className="home-page__details">
                Gratis att spela · Massa frågor · Poäng · En gång per dag
              </p>
            </div>
            <Card
              className="home-page__journey-card"
              aria-label="Dagens Sverigeresa"
            />
          </div>
        </section>
      </main>
      <SiteFooter />
    </div>
  )
}

export default HomePage
