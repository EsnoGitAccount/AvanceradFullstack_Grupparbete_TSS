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