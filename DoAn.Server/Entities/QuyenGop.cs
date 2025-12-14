namespace DoAn.Server.Entities
{
    public class QuyenGop
    {
        public string MaQuyenGop { get; set; } = null!;
        public string? MaNguoiQuyenGop { get; set; }
        public string? MaNguonLuc { get; set; }
        public decimal SoLuong { get; set; }
        public string LoaiQuyenGop { get; set; } = null!; // Tiền mặt hoặc Hiện vật
        public DateTime NgayQuyenGop { get; set; } = DateTime.Now;

        public NguoiDung? NguoiQuyenGop { get; set; }
        public NguonLucCuuTro? NguonLuc { get; set; }
    }
}
