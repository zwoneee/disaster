namespace DoAn.Server.Entities
{
    public class DoiCuuHo
    {
        public string MaDoiCuuHo { get; set; } = null!;
        public string TenDoi { get; set; } = null!;
        public string? MaNguoiQuanLy { get; set; }
        public string TrangThai { get; set; } = "Sẵn sàng";

        public NguoiDung? NguoiQuanLy { get; set; }
        public ICollection<PhanCongNhiemVu> PhanCongNhiemVus { get; set; } = new List<PhanCongNhiemVu>();
    }
}