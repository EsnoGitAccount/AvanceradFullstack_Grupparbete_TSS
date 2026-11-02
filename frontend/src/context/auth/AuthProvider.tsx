import React, { useState, useEffect } from 'react';
import { AuthContext, type LoginCredentials, type UserDto } from './AuthContext';
import { authService } from "../../services/AuthService";
import type { RegisterDto } from '@/models/RegisterDto';
// AuthProvider component that provides authentication context to its children
// It manages user state, loading state, and provides login and logout methods.
export const AuthProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    const [user, setUser] = useState<UserDto | null>(null);
    const [loading, setLoading] = useState<boolean>(true);

    useEffect(() => {
        const initAuth = async () => {
            try {
                await authService.fetchCsrfToken();
                const currentUser = await authService.getCurrentUser();
                setUser(currentUser);
            } catch {
                setUser(null);
            } finally {
                setLoading(false);
            }
        };

        initAuth();
    }, []);

    const login = async (credentials: LoginCredentials) => {
        const loggedInUser = await authService.login(credentials);
        setUser(loggedInUser);
    };

    const logout = async () => {
        try {
            await authService.logout();
        } finally {
            setUser(null);
        }
    };

   const register=async( registerData:RegisterDto)=>{
    const registeredUser=await authService.register(registerData);
    setUser(registeredUser);
   }

    return (
        <AuthContext.Provider value={{ user, loading, login, logout, register }}>
            {children}
        </AuthContext.Provider>
    );
};