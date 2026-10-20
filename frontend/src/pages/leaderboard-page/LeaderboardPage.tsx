import SiteFooter from '@/components/site-footer/SiteFooter'
import SiteHeader from '@/components/site-header/SiteHeader'
import Leaderboard from '@/components/game-components/leaderboard/Leaderboard'

import './LeaderboardPage.css'

function LeaderboardPage() {
    return (
        <div className="leaderboard-page">
            <SiteHeader />
            <Leaderboard />
            
            <SiteFooter />
        </div>
    )
}

export default LeaderboardPage