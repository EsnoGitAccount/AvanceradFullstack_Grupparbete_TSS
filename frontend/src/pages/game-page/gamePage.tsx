import SiteFooter from '@/components/site-footer/SiteFooter'
import SiteHeader from '@/components/site-header/SiteHeader'
import Game from '@/components/game-components/game/game'

export default function GamePage() {

    return(
        <>
            <header>
                <SiteHeader />
            </header>
            <main>
                <Game />
            </main>
            <footer>
                <SiteFooter />
            </footer>
        </>
    )
}