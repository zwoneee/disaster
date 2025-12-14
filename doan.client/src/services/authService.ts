// src/services/authService.ts
import axiosClient from './axiosClient';
import { LoginResponse } from '../types/Auth';

export const authService = {
    register: async (data: RegisterRequest) => {
        // Gọi API: POST /api/Auth/register
        const response = await axiosClient.post('/Auth/register', data);
        return response.data;
    },

    login: async (username: string, password: string) => {
        // Gọi API: POST /api/Auth/login
        const response = await axiosClient.post<LoginResponse>('/Auth/login', {
            username,
            password
        });

        // Lưu token và thông tin user vào bộ nhớ trình duyệt
        if (response.data.token) {
            localStorage.setItem('token', response.data.token);
            localStorage.setItem('user', JSON.stringify(response.data.user));
        }

        return response.data;
    },

    logout: () => {
        localStorage.removeItem('token');
        localStorage.removeItem('user');
        window.location.href = '/login';
    },

    getCurrentUser: () => {
        const userStr = localStorage.getItem('user');
        if (userStr) return JSON.parse(userStr);
        return null;
    }
};

// Định nghĩa kiểu dữ liệu gửi lên (DTO)
interface RegisterRequest {
    username: string;
    password: string;
    hoTen: string;
    email: string;
}