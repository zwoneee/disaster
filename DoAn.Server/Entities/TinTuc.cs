namespace DoAn.Server.Entities
{
    public class TinTuc
    {
        public string MaTinTuc { get; set; } = null!;
        public string TieuDe { get; set; } = null!;
        public string? NoiDung { get; set; }
        public string? AnhBia { get; set; }
        public string MaNguoiTao { get; set; } = null!;
        public DateTime NgayDang { get; set; } = DateTime.Now;
        public string TrangThai { get; set; } = "Đã duyệt";
        public int LuotXem { get; set; } = 0;

        public NguoiDung NguoiTao { get; set; } = null!;
        public ICollection<BinhLuan> BinhLuans { get; set; } = new List<BinhLuan>();
    }
}
