namespace DoAn.Server.Entities
{
    public class PhanCongNhiemVu
    {
        public string MaNhiemVu { get; set; } = null!;
        public string MaDoiCuuHo { get; set; } = null!;
        public DateTime NgayPhanCong { get; set; } = DateTime.Now;
        public string? TrangThai { get; set; }

        public NhiemVuCuuHo NhiemVu { get; set; } = null!;
        public DoiCuuHo DoiCuuHo { get; set; } = null!;
    }
}