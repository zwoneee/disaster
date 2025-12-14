import React, { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { authService } from '../services/authService';
import '../assets/Login.css';

const Login: React.FC = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();

    const handleLogin = async (e: React.FormEvent) => {
        e.preventDefault();
        setError('');
        setLoading(true);

        try {
            await authService.login(username, password);
            navigate('/');
            window.location.reload();
        } catch (err: any) {
            console.error(err);
            const msg = err.response?.data?.message || 'Đăng nhập thất bại. Kiểm tra lại tài khoản!';
            setError(msg);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="login-container">
            <div className="login-form-wrapper">
                <h2 className="login-title">Đăng Nhập Hệ Thống</h2>

                {error && <div className="error-msg">{error}</div>}

                <form onSubmit={handleLogin}>
                    <div className="form-group">
                        <label className="form-label">Tên đăng nhập</label>
                        <input
                            type="text" className="form-input"
                            value={username} onChange={(e) => setUsername(e.target.value)}
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label className="form-label">Mật khẩu</label>
                        <input
                            type="password" className="form-input"
                            value={password} onChange={(e) => setPassword(e.target.value)}
                            required
                        />
                    </div>

                    <button type="submit" className="btn-submit" disabled={loading}>
                        {loading ? 'Đang xử lý...' : 'Đăng Nhập'}
                    </button>

                    <div style={{ marginTop: '15px', fontSize: '14px' }}>
                        Chưa có tài khoản? <Link to="/register" style={{ color: '#f00946', fontWeight: 'bold' }}>Đăng ký ngay</Link>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default Login;