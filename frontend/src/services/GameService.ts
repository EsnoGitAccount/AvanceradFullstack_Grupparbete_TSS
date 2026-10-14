import api from './api';
import type { GameResult } from '@/models/GameResult'

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

export const getDailyChallenge = async () => {
    try {
        const response = await api.get('/api/DailyChallenge');
        console.log('Daily challenge fetched:', response.data);
        return response.data;
    } catch (error) {
        console.error('Error fetching daily challenge:', error);
        throw error;
    }
}