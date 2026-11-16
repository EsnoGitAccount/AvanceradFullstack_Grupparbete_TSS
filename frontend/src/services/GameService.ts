import api from './api';
import type { GameResult } from '@/models/GameResult'
import type { DailyChallenge } from '@/models/DailyChallenge'


type Achievement = {
    achievementId: number;
    name: string;
    description: string;
    imageKey: string;
};

type SavedGame={
    gameId: number;
    isGuest: boolean;
    newAchievements: Achievement[];
}

export const submitGameResult  = async (playerResult: GameResult): Promise<SavedGame> => {
    const response = await api.post<SavedGame>('/api/games', playerResult);
    
    if (response.data.isGuest) {
        sessionStorage.setItem('lastGameId', String(response.data.gameId));
    }
    else {
        sessionStorage.removeItem('lastGameId');
    }
    return response.data;
}

export const getDailyChallenge = async (): Promise<DailyChallenge> => {
    try {
        const response = await api.get('/api/DailyChallenge');
        console.log('Daily challenge fetched:', response.data);
        return response.data;
    } catch (error) {
        console.error('Error fetching daily challenge:', error);
        throw error;
    }
}