import api from "./api";

export const changeUsername = async (newUsername: string): Promise<void> => {
    await api.patch('/api/account/username', { newUsername });
};

export const changePassword = async (currentPassword: string, newPassword: string): Promise<void> => {
    await api.patch('/api/account/password', { currentPassword, newPassword });
};

export const deleteAccount = async (): Promise<void> => {
    await api.delete('/api/account');
};