// src/services/axiosClient.ts
import axios from 'axios';

const axiosClient = axios.create({
    // 👇👇👇 Kiểm tra kỹ cổng này bên dự án Server (file launchSettings.json)
    baseURL: 'https://localhost:7249/api',
    headers: {
        'Content-Type': 'application/json',
    },
});

// Tự động gắn Token vào mỗi request nếu đã đăng nhập
axiosClient.interceptors.request.use(
    (config) => {
        const token = localStorage.getItem('token');
        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
    },
    (error) => Promise.reject(error)
);

export default axiosClient;