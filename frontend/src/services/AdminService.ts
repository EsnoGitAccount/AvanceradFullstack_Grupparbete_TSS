import api from './api';
import type { AdminCity } from '@/models/AdminModels';

export const getAdminCities = async (): Promise<AdminCity[]> => {
  const response = await api.get<AdminCity[]>('/api/cities/admin');

  return response.data;
};

export const createCity = async ( name: string, cityPicture: File): Promise<AdminCity> => {
  const formData = new FormData();

  formData.append('name', name);
  formData.append('cityPicture', cityPicture);

  const response = await api.post<AdminCity>('/api/cities', formData);

  return response.data;
};