namespace DoAn.Server.Entities
{
    public class TinhNguyenVien
    {
        public string MaTinhNguyenVien { get; set; } = null!;
        public string MaNguoiDung { get; set; } = null!;
        public DateTime NgayDangKy { get; set; } = DateTime.Now;
        public string TrangThai { get; set; } = "Đang hoạt động";

        public NguoiDung NguoiDung { get; set; } = null!;
        public ICollection<PhanCongTinhNguyenVien> PhanCongNhiemVus { get; set; } = new List<PhanCongTinhNguyenVien>();
    }
}