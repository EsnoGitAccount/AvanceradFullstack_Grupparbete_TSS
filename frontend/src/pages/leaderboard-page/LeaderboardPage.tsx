import SiteFooter from '@/components/site-footer/SiteFooter'
import SiteHeader from '@/components/site-header/SiteHeader'
import { Button } from '@/components/ui/Button'
import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/Card'
import { TrophyIcon } from '@/assets/icons/Icons'

import './LeaderboardPage.css'

function LeaderboardPage() {
    return (
        <div className="leaderboard-page">
            <SiteHeader />

            <main className="leaderboard-page__main">
                <section className="leaderboard-page__hero">

                    {/* Top section: Title and date badge */}
                    <div className="leaderboard-page__header">
                        <div>
                            <p className="leaderboard-page__eyebrow">Resenärer i hela Sverige</p>
                            <h1 className="leaderboard-page__title">Lite vänskaplig tävling.</h1>
                            <p className="leaderboard-page__description">
                                Samma fem ledtrådar. Vem har bäst koll på Sverige i dag?
                            </p>
                        </div>
                        <div className="leaderboard-page__date-badge">
                            8 oktober 2026 · 128 resenärer
                        </div>
                    </div>

                    {/* Tab buttons */}
                    <div className="leaderboard-page__tabs">
                        <Button variant="secondary" className="leaderboard-page__tab--active">I dag</Button>
                        <Button variant="ghost">Genom tiderna</Button>
                    </div>

                    {/* Main grid: two columns */}
                    <div className="leaderboard-page__grid">

                        {/* Left column: Leaderboard */}
                        <div className="leaderboard-page__left-column">

                            {/* Leaderboard card */}
                            <Card className="leaderboard-page__leaderboard-card">
                                <CardHeader className="leaderboard-page__card-header">
                                    <CardTitle style={{ fontWeight: 800 }}>Dagens topplista </CardTitle>
                                    <TrophyIcon color="var(--destructive)" />
                                </CardHeader>
                                <CardContent>
                                    <div className="leaderboard-page__table-header">
                                        <span>PLATS / RESENÄR</span>
                                        <span>SVIT / POÄNG</span>
                                    </div>

                                    {/* Placeholder for leaderboard rows */}
                                    <div className="leaderboard-page__table">
                                        <div className="leaderboard-page__row">
                                            <span><strong className="leaderboard-page__rank">01</strong> Linnea</span>
                                            <span>8 dagar &nbsp; <strong>50 p</strong></span>
                                        </div>
                                        <div className="leaderboard-page__row">
                                            <span><strong className="leaderboard-page__rank">02</strong> Oskar</span>
                                            <span>12 dagar &nbsp; <strong>50 p</strong></span>
                                        </div>
                                        <div className="leaderboard-page__row leaderboard-page__row--active">
                                            <span><strong className="leaderboard-page__rank">04</strong> Anton (du)</span>
                                            <span>7 dagar &nbsp; <strong>40 p</strong></span>
                                        </div>
                                    </div>

                                    <p className="leaderboard-page__footnote">
                                        Vid lika poäng delas placeringen. Listan uppdateras när en resa slutförs.
                                    </p>
                                </CardContent>
                            </Card>

                            {/* Placeholder  */}
                            <div className="leaderboard-page__pagination">
                                <span>Visar 1–7 av 128 resenärer</span>
                                <div className="leaderboard-page__pagination-controls">
                                    <Button variant="ghost">← Föregående</Button>
                                    <span>1 2 ...</span>
                                    <Button variant="ghost">Nästa →</Button>
                                </div>
                            </div>
                        </div>

                        {/* Right column: Statistics cards */}
                        <div className="leaderboard-page__right-column">

                            {/* Card 1: Your placement */}
                            <Card className="leaderboard-page__stat-card1">
                                <CardContent className="leaderboard-page__stat-card-content">
                                    <div className="leaderboard-page__avatar">A</div>
                                    <p className="leaderboard-page__stat-sub">ANTON · DIN PLACERING</p>
                                    <h2 className="leaderboard-page__stat-title">Plats 4</h2>
                                    <p className="leaderboard-page__stat-score">40 poäng · 4 av 5 rätt</p>
                                    <p className="leaderboard-page__stat-desc">
                                        Du är bland dagens främsta resenärer. Bra jobbat!
                                    </p>
                                </CardContent>
                            </Card>

                            {/* Card 2: Through the years */}
                            <Card className="leaderboard-page__stat-card2">
                                <CardContent>
                                    <p className="leaderboard-page__stat-sub">Genom tiderna</p>
                                    <h2 className="leaderboard-page__stat-title">400 p</h2>
                                    <p className="leaderboard-page__stat-desc">Dina samlade poäng från alla resor</p>
                                </CardContent>
                            </Card>

                            {/* Card 3: New opportunity tomorrow */}
                            <Card className="leaderboard-page__stat-card">
                                <CardHeader>
                                    <CardTitle>Ny chans i morgon</CardTitle>
                                </CardHeader>
                                <CardContent>
                                    <p className="leaderboard-page__stat-desc">
                                        Dagens poäng är låst. En ny topplista öppnar med morgondagens spel.
                                    </p>
                                </CardContent>
                            </Card>

                        </div>
                    </div>

                </section>
            </main>

            <SiteFooter />
        </div>
    )
}

export default LeaderboardPage