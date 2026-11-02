import type { RegisterDto } from '@/models/RegisterDto';
import { createContext } from 'react';

// Define the types for user and login credentials, as well as the shape of the authentication context
export type UserDto = {
  username: string;
  email: string;
  roles: string[];
};

export type LoginCredentials = {
  username: string;
  password: string;
};

export interface AuthContextType {
  user: UserDto | null;
  loading: boolean;
  login: (credentials: LoginCredentials) => Promise<void>;
  logout: () => Promise<void>;
  register:(registerData:RegisterDto)=>Promise<void>
}

export const AuthContext = createContext<AuthContextType | undefined>(undefined);