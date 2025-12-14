import React, { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { authService } from '../services/authService';
import '../assets/Login.css'; // Tận dụng lại CSS của trang Login

const Register: React.FC = () => {
    const [formData, setFormData] = useState({
        username: '',
        password: '',
        confirmPassword: '',
        hoTen: '',
        email: ''
    });
    const [error, setError] = useState('');
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();

    // Hàm xử lý khi người dùng nhập liệu
    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    // Hàm xử lý khi bấm nút Đăng ký
    const handleRegister = async (e: React.FormEvent) => {
        e.preventDefault();
        setError('');

        // 1. Kiểm tra mật khẩu nhập lại
        if (formData.password !== formData.confirmPassword) {
            setError('Mật khẩu nhập lại không khớp!');
            return;
        }

        setLoading(true);

        try {
            // 2. Gọi API đăng ký
            await authService.register({
                username: formData.username,
                password: formData.password,
                hoTen: formData.hoTen,
                email: formData.email
            });

            // 3. Thành công -> Chuyển về Login
            alert('Đăng ký thành công! Vui lòng đăng nhập.');
            navigate('/login');
        } catch (err: any) {
            console.error(err);
            // Lấy lỗi từ Server trả về (nếu có)
            const msg = err.response?.data?.message || 'Đăng ký thất bại. Vui lòng thử lại!';
            setError(msg);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="login-container">
            <div className="login-form-wrapper">
                <h2 className="login-title">Đăng Ký Tài Khoản</h2>

                {error && <div className="error-msg">{error}</div>}

                <form onSubmit={handleRegister}>
                    <div className="form-group">
                        <label className="form-label">Họ và tên</label>
                        <input
                            name="hoTen" type="text" className="form-input"
                            value={formData.hoTen} onChange={handleChange}
                            required placeholder="Ví dụ: Nguyễn Văn A"
                        />
                    </div>

                    <div className="form-group">
                        <label className="form-label">Email</label>
                        <input
                            name="email" type="email" className="form-input"
                            value={formData.email} onChange={handleChange}
                            required placeholder="email@example.com"
                        />
                    </div>

                    <div className="form-group">
                        <label className="form-label">Tên đăng nhập</label>
                        <input
                            name="username" type="text" className="form-input"
                            value={formData.username} onChange={handleChange}
                            required
                        />
                    </div>

                    <div className="form-group">
                        <label className="form-label">Mật khẩu</label>
                        <input
                            name="password" type="password" className="form-input"
                            value={formData.password} onChange={handleChange}
                            required
                        />
                    </div>

                    <div className="form-group">
                        <label className="form-label">Nhập lại mật khẩu</label>
                        <input
                            name="confirmPassword" type="password" className="form-input"
                            value={formData.confirmPassword} onChange={handleChange}
                            required
                        />
                    </div>

                    <button type="submit" className="btn-submit" disabled={loading}>
                        {loading ? 'Đang xử lý...' : 'Đăng Ký Ngay'}
                    </button>

                    {/* Nút chuyển về trang Login */}
                    <div style={{ marginTop: '15px', fontSize: '14px' }}>
                        Đã có tài khoản? <Link to="/login" style={{ color: '#f00946', fontWeight: 'bold' }}>Đăng nhập</Link>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default Register;