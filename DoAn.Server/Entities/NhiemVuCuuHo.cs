namespace DoAn.Server.Entities
{
    public class NhiemVuCuuHo
    {
        public string MaNhiemVu { get; set; } = null!;
        public string MaNguoiTao { get; set; } = null!;
        public string? MaDoiCuuHo { get; set; }
        public string? MoTa { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string TrangThai { get; set; } = "Mới";

        public NguoiDung NguoiTao { get; set; } = null!;
        public ICollection<PhanCongNhiemVu> PhanCongNhiemVus { get; set; } = new List<PhanCongNhiemVu>();
        public ICollection<PhanCongTinhNguyenVien> PhanCongTinhNguyenViens { get; set; } = new List<PhanCongTinhNguyenVien>();
    }
}