import { useState, useEffect } from 'react'
import { getLeaderboard } from '@/services/LeaderboardService'

import type { LeaderboardEntry } from '@/models/LeaderboardEntry'

import { Button } from "@/components/ui/Button"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/Card"
import { TrophyIcon } from "@/assets/icons/Icons"
import './Leaderboard.css'

export default function Leaderboard() {
    const [leaderboardData, setLeaderboardData] = useState<LeaderboardEntry[]>([]);
    const [today, setToday] = useState('');
  
    useEffect(() => {
        const fetchLeaderboard = async () => {
            setToday(new Date().toLocaleDateString('sv-SE'));

            try {
                const data = await getLeaderboard();
                setLeaderboardData(data);
            } catch (error) {
                console.error('Error fetching leaderboard data:', error);
            }
        };

        fetchLeaderboard();
    }, []); // Clear previous data before fetching new data


    return (
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
                    {today} · {leaderboardData.length} resenärer
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
                                {leaderboardData.map((entry, index) => {

                                    return (
                                        <div
                                            key={index}
                                            className={`leaderboard-page__row ${entry.isCurrentUser
                                                    ? 'leaderboard-page__row--active'
                                                    : ''
                                                }`}
                                        >
                                            <span>
                                                <strong className="leaderboard-page__rank">
                                                    {String(entry.rank).padStart(2, '0')}
                                                </strong>{' '}
                                                {entry.userName}
                                            </span>

                                            <span>
                                                {entry.streak ? `${entry.streak} dagar` : ''} &nbsp;
                                                <strong>{entry.finalScore} p</strong>
                                            </span>
                                        </div>
                                    );
                                })}
                            </div>

                            <p className="leaderboard-page__footnote">
                                Vid lika poäng delas placeringen. Listan uppdateras när en resa slutförs.
                            </p>
                        </CardContent>
                    </Card>
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
    )
}