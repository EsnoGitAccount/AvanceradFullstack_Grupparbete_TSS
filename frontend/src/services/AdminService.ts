import api from "./api";
import type {
  AdminCity,
  AdminGameResult,
  AdminUser,
  CityQuestionsUpdate,
} from "@/models/AdminModels";

export const getAdminCities = async (): Promise<AdminCity[]> => {
  const response = await api.get<AdminCity[]>("/api/cities/admin");

  return response.data;
};

export const createCity = async (
  name: string,
  cityPicture: File,
): Promise<AdminCity> => {
  const formData = new FormData();

  formData.append("name", name);
  formData.append("cityPicture", cityPicture);

  const response = await api.post<AdminCity>("/api/cities", formData);

  return response.data;
};

export const updateCity = async (
  cityId: number,
  name: string,
  cityPicture?: File,
): Promise<AdminCity> => {
  const formData = new FormData();

  formData.append("name", name);

  if (cityPicture) {
    formData.append("cityPicture", cityPicture);
  }

  const response = await api.put<AdminCity>(`/api/cities/${cityId}`, formData);

  return response.data;
};

export const archiveCity = async (cityId: number): Promise<void> => {
  await api.post(`/api/cities/${cityId}/archive`);
};

export const restoreCity = async (cityId: number): Promise<void> => {
  await api.post(`/api/cities/${cityId}/restore`);
};

export const getCityQuestions = async (
  cityId: number,
): Promise<CityQuestionsUpdate> => {
  const response = await api.get<CityQuestionsUpdate>(
    `/api/cities/${cityId}/questions`,
  );

  return response.data;
};

export const updateCityQuestions = async (
  cityId: number,
  questions: CityQuestionsUpdate,
): Promise<void> => {
  await api.put(`/api/cities/${cityId}/questions`, questions);
};

export const getAdminUsers = async (): Promise<AdminUser[]> => {
  const response = await api.get<AdminUser[]>("/api/users/admin");

  return response.data;
};

export const archiveUser = async (userId: number): Promise<void> => {
  await api.post(`/api/users/admin/${userId}/archive`);
};

export const restoreUser = async (userId: number): Promise<void> => {
  await api.post(`/api/users/admin/${userId}/restore`);
};

export const getAdminGames = async (): Promise<AdminGameResult[]> => {
  const response = await api.get<AdminGameResult[]>("/api/games/admin");

  return response.data;
};
