export type LeaderboardEntry = {
    userName: string;
    finalScore: number;
    rank: number;
    streak: number | null;
    isCurrentUser: boolean;
};

export type PlayerStatistics = {
    userName: string;
    streak: number;
    dailyScore: number | null;
    dailyRank: number | null;
    allTimeScore: number;
    allTimeRank: number | null;
};

export type LeaderboardData = {
    date: string;
    dailyTop10: LeaderboardEntry[];
    allTimeTop10: LeaderboardEntry[];
    currentUser: PlayerStatistics | null;
    dailyCount: number;
    allTimeCount: number;
};