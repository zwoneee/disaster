namespace DoAn.Server.Entities
{
    public class ThongBaoCaNhan
    {
        public string MaThongBao { get; set; } = null!;
        public string MaNguoiNhan { get; set; } = null!;
        public string TieuDe { get; set; } = null!;
        public string? NoiDung { get; set; }
        public string? LoaiThongBao { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime NgayGui { get; set; } = DateTime.Now;

        public NguoiDung NguoiNhan { get; set; } = null!;
    }
}
