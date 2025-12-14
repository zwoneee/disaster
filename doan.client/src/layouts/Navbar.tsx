import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { FaBars, FaTimes, FaUserCircle } from 'react-icons/fa';
import '../assets/Navbar.css'; // Chúng ta sẽ tạo CSS sau

const Navbar: React.FC = () => {
    const [click, setClick] = useState(false);
    const handleClick = () => setClick(!click);

    return (
        <nav className="navbar">
            <div className="navbar-container">
                <Link to="/" className="navbar-logo">
                    DISASTER ALERT
                    <i className="fas fa-typhoon" />
                </Link>

                <div className="menu-icon" onClick={handleClick}>
                    {click ? <FaTimes /> : <FaBars />}
                </div>

                <ul className={click ? "nav-menu active" : "nav-menu"}>
                    <li className="nav-item">
                        <Link to="/" className="nav-links" onClick={handleClick}>
                            Trang chủ
                        </Link>
                    </li>
                    {/* Chức năng xem bản đồ - UC Tổng quát */}
                    <li className="nav-item">
                        <Link to="/map" className="nav-links" onClick={handleClick}>
                            Bản đồ thiên tai
                        </Link>
                    </li>
                    {/* Chức năng Tin tức/Cảnh báo - UC Quản lý cảnh báo & Công thông tin */}
                    <li className="nav-item">
                        <Link to="/news" className="nav-links" onClick={handleClick}>
                            Tin tức & Cảnh báo
                        </Link>
                    </li>
                    {/* Chức năng Gửi báo cáo - UC Quản lý báo cáo hiện trường */}
                    <li className="nav-item">
                        <Link to="/report" className="nav-links" onClick={handleClick}>
                            Gửi báo cáo
                        </Link>
                    </li>
                    {/* Chức năng Cứu trợ - UC Quản lý nguồn lực */}
                    <li className="nav-item">
                        <Link to="/relief" className="nav-links" onClick={handleClick}>
                            Hoạt động Cứu trợ
                        </Link>
                    </li>

                    <li className="nav-item">
                        <Link to="/login" className="nav-links-mobile" onClick={handleClick}>
                            Đăng nhập
                        </Link>
                    </li>
                </ul>

                <div className="btn-login-container">
                    <Link to="/login" className="btn-login">
                        <FaUserCircle style={{ marginRight: '5px' }} /> Đăng nhập
                    </Link>
                </div>
            </div>
        </nav>
    );
};

export default Navbar;