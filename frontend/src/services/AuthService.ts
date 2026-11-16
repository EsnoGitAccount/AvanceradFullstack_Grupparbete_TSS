import api from "./api"
import type { RegisterDto } from "@/models/RegisterDto";
import type { LoginCredentials, UserDto } from "@/context/auth/AuthContext";

let csrfToken: string | null = null;

// AuthService provides methods for user authentication
api.interceptors.request.use((config) => {
    if (csrfToken) {
        config.headers['X-XSRF-TOKEN'] = csrfToken;
    }
    return config;
});

export const authService = {

    async fetchCsrfToken(): Promise<void> {
        const response = await api.get<{ token: string }>("/api/auth/csrf");
        csrfToken = response.data.token;
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
        await this.fetchCsrfToken();
        
        const response = await api.post('/api/auth/refresh');
        return response.data;
    },

    async logout(): Promise<void> {
        await this.fetchCsrfToken();
        
        await api.post('/api/auth/logout');
    },


    async register(registerData:RegisterDto):Promise<UserDto>{
        await this.fetchCsrfToken();
       const response= await api.post('/api/auth/register', registerData)

        return response.data;
    }
}