import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import './App.css';
import Navbar from './layouts/Navbar'; // Đã sửa đường dẫn
import Home from './pages/Home';
import MapDisaster from './components/MapDisaster';
import Login from './pages/Login';
import Register from './pages/Register'

function App() {
    return (
        <Router>
            <Navbar />
            <Routes>
                <Route path="/" element={<Home />} />

                {/* Đường dẫn đến bản đồ: Full chiều rộng và chiều cao còn lại */}
                <Route path="/map" element={
                    <div style={{
                        height: 'calc(100vh - 80px)',
                        width: '100%',  /* QUAN TRỌNG: Full width */
                        overflow: 'hidden'
                    }}>
                        <MapDisaster />
                    </div>
                } />

                <Route path="/login" element={<Login />} />
                <Route path="/register" element={<Register />} />
                <Route path="/news" element={<h2 style={{ marginTop: '100px', textAlign: 'center' }}>Trang Tin Tức (Đang phát triển)</h2>} />
                <Route path="/report" element={<h2 style={{ marginTop: '100px', textAlign: 'center' }}>Trang Gửi Báo Cáo (Đang phát triển)</h2>} />
            </Routes>
        </Router>
    );
}

export default App;