import api from './api';
import type { GameResult } from '@/models/GameResult'
import type { DailyChallenge } from '@/models/DailyChallenge'
import { getCacheData } from './Cache';

export const submitGameResult  = async (playerResult: GameResult) => {
    try {
          const response = await api.post('/api/games', JSON.stringify(playerResult), {
              headers: {
                  'Content-Type': 'application/json'
              }
          });
          console.log(response.data.message, response.data.data);
      } 
    catch (error) {
        console.error('Error submitting result:', error);
    }
}

export const getDailyChallenge = async (): Promise<DailyChallenge> => {
    return getCacheData<DailyChallenge>('/api/dailyChallenge', async () => {
    try {
        const response = await api.get<DailyChallenge>('/api/DailyChallenge');
        console.log('Daily challenge fetched:', response.data);
        return response.data;
    } catch (error) {
        console.error('Error fetching daily challenge:', error);
        throw error;
    }
});
};