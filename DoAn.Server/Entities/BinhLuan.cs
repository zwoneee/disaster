namespace DoAn.Server.Entities
{
    public class BinhLuan
    {
        public int MaBinhLuan { get; set; }
        public string MaTinTuc { get; set; } = null!;
        public string MaNguoiDung { get; set; } = null!;
        public string NoiDung { get; set; } = null!;
        public DateTime NgayTao { get; set; } = DateTime.Now;
        public string TrangThai { get; set; } = "Đã duyệt";

        public TinTuc TinTuc { get; set; } = null!;
        public NguoiDung NguoiDung { get; set; } = null!;
    }
}
