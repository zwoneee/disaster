using DoAn.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Server.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // 1. Đảm bảo database đã được tạo
            context.Database.EnsureCreated();

            // 2. Kiểm tra xem đã có Vai trò nào chưa?
            if (context.VaiTro.Any())
            {
                return; // Đã có dữ liệu, không cần làm gì thêm
            }

            // 3. Tạo các Vai trò mặc định
            // Lưu ý: Không cần set MaVaiTro vì DB sẽ tự sinh (VT01, VT02...)
            var roles = new VaiTro[]
            {
                new VaiTro { TenVaiTro = "Admin", MoTa = "Quản trị viên hệ thống" },
                new VaiTro { TenVaiTro = "NguoiDan", MoTa = "Người dân" },
                new VaiTro { TenVaiTro = "CanBo", MoTa = "Cán bộ quản lý" },
                new VaiTro { TenVaiTro = "CuuHo", MoTa = "Đội cứu hộ" },
                new VaiTro { TenVaiTro = "YTe", MoTa = "Nhân viên y tế" },
                new VaiTro { TenVaiTro = "CongAn", MoTa = "Công an" },
                new VaiTro { TenVaiTro = "TinhNguyenVien", MoTa = "Tình nguyện viên" },
                new VaiTro { TenVaiTro = "BaoChi", MoTa = "Phóng viên báo chí" }
            };

            foreach (var r in roles)
            {
                context.VaiTro.Add(r);
            }
            context.SaveChanges(); // Lưu để DB sinh mã MaVaiTro

            // 4. Tạo tài khoản Admin mặc định
            var adminRole = context.VaiTro.FirstOrDefault(r => r.TenVaiTro == "Admin");

            if (adminRole != null)
            {
                var adminUser = new NguoiDung
                {
                    // Không set MaNguoiDung, để DB tự sinh (U001)
                    TenDangNhap = "admin",
                    // Mật khẩu là: admin123 (Đã mã hóa BCrypt)
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    HoTen = "Administrator",
                    Email = "admin@gmail.com",
                    SoDienThoai = "0686868",
                    DiaChi = "Hệ thống trung tâm",
                    MaVaiTro = adminRole.MaVaiTro, // Gắn ID của vai trò Admin vừa tạo
                    TrangThai = true,
                    IsLocked = false,
                    NgayTao = DateTime.Now
                };

                context.NguoiDung.Add(adminUser);
                context.SaveChanges();
            }
        }
    }
}