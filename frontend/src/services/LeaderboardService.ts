import api from './api';
import type { LeaderboardEntry } from '@/models/LeaderboardEntry'

export const getLeaderboard = async (): Promise<LeaderboardEntry[]> => {
    try {
          const response = await api.get('/api/games', {
              headers: {
                  'Content-Type': 'application/json'
              }
          });
          console.log(response.data.message, response.data.data);
          return response.data;
      } 
    catch (error) {
        console.error('Error submitting result:', error);
        throw error;
    }
}