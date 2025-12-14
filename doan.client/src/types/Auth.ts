// src/types/Auth.ts
export interface User {
    maNguoiDung: string;
    hoTen: string;
    email: string;
    avatarUrl?: string;
    role: string;
    maVaiTro: string;
}

export interface LoginResponse {
    token: string;
    user: User;
}