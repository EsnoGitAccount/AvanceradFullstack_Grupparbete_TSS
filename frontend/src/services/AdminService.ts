import api from './api';
import type { AdminCity } from '@/models/AdminModels';

export const getAdminCities = async (): Promise<AdminCity[]> => {
  const response = await api.get<AdminCity[]>('/api/cities/admin');

  return response.data;
};