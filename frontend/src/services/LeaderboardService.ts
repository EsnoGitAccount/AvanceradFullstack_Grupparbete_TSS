import api from './api';
import type { LeaderboardData } from '@/models/LeaderboardEntry'

export const getLeaderboard = async (signal?: AbortSignal): Promise<LeaderboardData> => {
    const lastGameId = sessionStorage.getItem('lastGameId');
    const response = await api.get<LeaderboardData>('/api/leaderboard', 
        { 
            signal,
            params: lastGameId ? { gameId: Number(lastGameId) } 
            : {},
        }
    );

    return response.data;    
}