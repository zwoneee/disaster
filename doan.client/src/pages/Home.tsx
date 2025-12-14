import React from 'react';
import { Link } from 'react-router-dom';
import { FaMapMarkedAlt, FaBroadcastTower, FaHandsHelping, FaFileMedical } from 'react-icons/fa';

const Home: React.FC = () => {
    return (
        <div className="home-container">
            {/* Hero Section */}
            <section className="hero-section">
                <div className="hero-content">
                    <h1>HỆ THỐNG QUẢN LÝ VÀ CẢNH BÁO THIÊN TAI</h1>
                    <p>Cập nhật nhanh chóng - Thông tin chính xác - Hỗ trợ kịp thời</p>
                    <div className="hero-btns">
                        <Link to="/map" className="btn btn-primary">Xem Bản Đồ Trực Tuyến</Link>
                        <Link to="/report" className="btn btn-outline">Gửi Báo Cáo Khẩn Cấp</Link>
                    </div>
                </div>
            </section>

            {/* Features Section - Dựa trên các Use Case chính */}
            <section className="features-section">
                <h2>Chức Năng Chính</h2>
                <div className="features-grid">
                    <div className="feature-card">
                        <FaBroadcastTower className="feature-icon" />
                        <h3>Cảnh Báo Sớm</h3>
                        <p>Nhận thông báo về bão, lũ lụt và các thảm họa thiên nhiên từ Trung tâm Khí tượng nhanh nhất.</p>
                    </div>

                    <div className="feature-card">
                        <FaMapMarkedAlt className="feature-icon" />
                        <h3>Bản Đồ Trực Quan</h3>
                        <p>Theo dõi vị trí thiên tai, vùng nguy hiểm và các trạm cứu hộ trên bản đồ thời gian thực.</p>
                    </div>

                    <div className="feature-card">
                        <FaFileMedical className="feature-icon" />
                        <h3>Báo Cáo Hiện Trường</h3>
                        <p>Người dân có thể gửi hình ảnh, vị trí và yêu cầu cứu trợ khẩn cấp trực tiếp đến cơ quan chức năng.</p>
                    </div>

                    <div className="feature-card">
                        <FaHandsHelping className="feature-icon" />
                        <h3>Kết Nối Cứu Trợ</h3>
                        <p>Quản lý nguồn lực, phân phối nhu yếu phẩm và điều phối tình nguyện viên đến vùng bị nạn.</p>
                    </div>
                </div>
            </section>
        </div>
    );
};

export default Home;