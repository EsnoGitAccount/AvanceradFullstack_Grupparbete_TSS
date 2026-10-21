import { useState, useEffect } from 'react'
import { getLeaderboard } from '@/services/LeaderboardService'

import type { LeaderboardData } from '@/models/LeaderboardEntry'

import { Button } from "@/components/ui/Button"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/Card"
import { TrophyIcon } from "@/assets/icons/Icons"
import './Leaderboard.css'

export default function Leaderboard() {
    const [data, setData] = useState<LeaderboardData | null>(null);
    const [period, setPeriod] = useState<'daily' | 'allTime'>('daily');
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);
    const [reload, setReload] = useState(0);
  
    useEffect(() => {
        const Controller = new AbortController();

        async function fetchLeaderboard() {
            try {
                const result = await getLeaderboard(Controller.signal);

                if (!Controller.signal.aborted) {
                    setData(result);
                }
            } catch  {
                if (!Controller.signal.aborted) {
                    setError('Kunde inte hämta topplistan. Försök igen senare.');
                }
            }
            finally {
                if (!Controller.signal.aborted) {
                    setLoading(false);
                }
            }
        };

        void fetchLeaderboard();

        return () => {
            Controller.abort();
        }
    }, [reload]);

    function retry() {
        setLoading(true);
        setError(null);
        setReload(value => value + 1);
    }

    const isDaily = period === 'daily';
    
    const entries = (isDaily ? data?.dailyTop10 : data?.allTimeTop10) ?? [];

    const player = data?.currentUser;

    const playerRank = isDaily ? player?.dailyRank : player?.allTimeRank;

    const playerScore = isDaily ? player?.dailyScore : player?.allTimeScore;


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
                {data && (
                <div className="leaderboard-page__date-badge">
                    {period === 'daily' ? data.dailyCount : data.allTimeCount} resenärer
                </div>
                )}
            </div>

            {/* Tab buttons */}
            <div className="leaderboard-page__tabs">
                <Button variant={isDaily ? "secondary" : "ghost"} 
                className={isDaily ? "leaderboard-page__tab--active" : ""}
                aria-pressed={!isDaily}
                onClick={() => setPeriod('daily')}>
                    I dag
                </Button>
                <Button variant={isDaily ? "ghost" : "secondary"} 
                className={isDaily ? "" : "leaderboard-page__tab--active"}
                aria-pressed={isDaily}
                onClick={() => setPeriod('allTime')}>
                    Genom tiderna
                </Button>
            </div>

            {/* Main grid: two columns */}
            {loading ? (
                <div className="leaderboard-page__loading">
                    <p>Laddar topplistan...</p>
                </div>
            ) : error ? (
                <div className="leaderboard-page__error">
                    <p>{error}</p>
                    <Button onClick={retry}>Försök igen</Button>
                </div>
            ) : data ? (
                <div className="leaderboard-page__grid">

                {/* Left column: Leaderboard */}
                <div className="leaderboard-page__left-column">

                    {/* Leaderboard card */}
                    <Card className="leaderboard-page__leaderboard-card">
                        <CardHeader className="leaderboard-page__card-header">
                            <CardTitle style={{ fontWeight: 800 }}>
                                {isDaily ? 
                                'Dagens top 10 topplista' :
                                'Topplista top 10 genom tiderna'} </CardTitle>
                            <TrophyIcon color="var(--destructive)" />
                        </CardHeader>
                        <CardContent>
                            <div className="leaderboard-page__table-header">
                                <span>PLATS / RESENÄR</span>
                                <span>SVIT / POÄNG</span>
                            </div>

                            {/* Placeholder for leaderboard rows */}
                            <div className="leaderboard-page__table">
                                {entries.map ((entry, index) => (
                                        <div
                                            key={`${period}-${index}`}
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
                                                {entry.isCurrentUser && ' (du)'}
                                            </span>

                                            <span>
                                                {entry.streak ? `${entry.streak} dagar` : ''} &nbsp;
                                                <strong>{entry.finalScore} p</strong>
                                            </span>
                                        </div>
                                ))}
                                {entries.length === 0 && (
                                    <div className="leaderboard-page__row">
                                        <span>Ingen data tillgänglig</span>
                                    </div>
                                )}
                            </div>

                            <p className="leaderboard-page__footnote">
                                Listan uppdateras när en resa slutförs.
                            </p>
                        </CardContent>
                    </Card>
                </div>

                {/* Right column: Statistics cards */}
                <div className="leaderboard-page__right-column">

                    {/* Card 1: Your placement */}
                    <Card className="leaderboard-page__stat-card1">
                        <CardContent className="leaderboard-page__stat-card-content">
                            {player ? (
                                <>
                            <div className="leaderboard-page__avatar">{player.userName.charAt(0).toUpperCase()}</div>
                                
                            <p className="leaderboard-page__stat-sub">
                                {player.userName} · DIN PLACERING</p>
                            <h2 className="leaderboard-page__stat-title">
                                {playerRank ? `#${playerRank}` : 'Ingen placering ännu'}
                            </h2>
                            <p className="leaderboard-page__stat-score">
                                {playerScore !== null ? `${playerScore} poäng` : 'Du har inte spelat än'}
                            </p>
                            <p className="leaderboard-page__stat-desc">
                                {isDaily ?
                                'Din placering i dagens topplista. Listan uppdateras när en resa slutförs.' :
                                'Din placering i topplistan genom tiderna. Listan uppdateras när en resa slutförs.'}
                            </p>
                            </>
                            ) : (
                                <p>
                                    Logga in för att se din placering och statistik.
                                </p>
                            )}
                        </CardContent>
                    </Card>

                    {/* Card 2: Through the years */}
                    <Card className="leaderboard-page__stat-card2">
                        <CardContent>
                            <p className="leaderboard-page__stat-sub">Genom tiderna</p>
                            <h2 className="leaderboard-page__stat-title">
                                {player?.allTimeScore ? `${player.allTimeScore} poäng` : 'Ingen poäng ännu'}
                            </h2>
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
            ) : null}
        </section>
    );
}