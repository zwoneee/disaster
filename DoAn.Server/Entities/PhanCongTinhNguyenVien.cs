namespace DoAn.Server.Entities
{
    public class PhanCongTinhNguyenVien
    {
        public string MaTinhNguyenVien { get; set; } = null!;
        public string MaNhiemVu { get; set; } = null!;
        public DateTime NgayPhanCong { get; set; } = DateTime.Now;
        public string? TrangThai { get; set; }

        public TinhNguyenVien TinhNguyenVien { get; set; } = null!;
        public NhiemVuCuuHo NhiemVu { get; set; } = null!;
    }
}