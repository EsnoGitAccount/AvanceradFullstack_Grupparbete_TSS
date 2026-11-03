import api from "./api";

export type AchievementDto = {
    name: string;
    description: string;
    imageKey: string;
};

export type UserProfileDto = {
    username: string;
    currentStreak: number;
    dailyScore?: number;
    allTimeScore: number;
    achievements: AchievementDto[];
    unachievedAchievements: AchievementDto[];
};

export const getProfile = async (): Promise<UserProfileDto> => {
    const response = await api.get<UserProfileDto>('/api/profile');
    return response.data;
};