import api from "./api";

export type UserProfileDto = {
    username: string;
    email: string;
    currentStreak: number;
};

export const getProfile = async (): Promise<UserProfileDto> => {
    const response = await api.get<UserProfileDto>('/api/profile');
    return response.data;
};