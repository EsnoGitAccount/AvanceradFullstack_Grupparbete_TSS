import axios from "axios";
import type { GameResult } from '@/models/GameResult'

const api = axios.create({
    baseURL: import.meta.env.VITE_API_BASE_URL,
    withCredentials: true,
});

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