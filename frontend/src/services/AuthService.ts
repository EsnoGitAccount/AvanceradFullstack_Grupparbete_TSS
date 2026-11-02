import api from "./api"
import type { RegisterDto } from "@/models/RegisterDto";
import type { LoginCredentials, UserDto } from "@/context/auth/AuthContext";

// AuthService provides methods for user authentication
export const authService = {
    async fetchCsrfToken(): Promise<void> {
        await api.get('/api/auth/csrf');
    },

    async login(credentials: LoginCredentials): Promise<UserDto> {
        await this.fetchCsrfToken();

        const response = await api.post('/api/auth/login', credentials);
        return response.data;
    },

    async getCurrentUser(): Promise<UserDto> {
        const response = await api.get<UserDto>('/api/auth/me');
        return response.data;
    },

    async refresh() {
        const response = await api.post('/api/auth/refresh');
        return response.data;
    },

    async logout(): Promise<void> {
        await api.post('/api/auth/logout');
    },


    async register(registerData:RegisterDto):Promise<UserDto>{
        await this.fetchCsrfToken();
       const response= await api.post('/api/auth/register', registerData)

        return response.data;
    }
}