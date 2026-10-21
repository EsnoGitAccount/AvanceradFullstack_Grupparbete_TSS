import api from './api';
import type { LeaderboardData } from '@/models/LeaderboardEntry'

export const getLeaderboard = async (signal?: AbortSignal): Promise<LeaderboardData | null> => {
    const response = await api.get<LeaderboardData>('/api/leaderboard', { signal });

    return response.data;    
}