namespace DoAn.Server.Entities
{
    public class NguoiDung
    {
        public string MaNguoiDung { get; set; } = null!;
        public string TenDangNhap { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string HoTen { get; set; } = null!;
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public string? DiaChi { get; set; }
        public string? AvatarUrl { get; set; }
        public string MaVaiTro { get; set; } = null!;
        public bool TrangThai { get; set; } = true;
        public bool IsLocked { get; set; } = false;
        public byte LoginAttempts { get; set; } = 0;
        public DateTime NgayTao { get; set; } = DateTime.Now;
        public DateTime? LanDangNhapCuoi { get; set; }

        public VaiTro VaiTro { get; set; } = null!;
    }
}
