namespace DoAn.Server.Entities
{
    public class CanhBao
    {
        public string MaCanhBao { get; set; } = null!;
        public string TieuDe { get; set; } = null!;
        public string? NoiDung { get; set; }
        public string? LoaiCanhBao { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public float? KinhDo { get; set; }
        public float? ViDo { get; set; }
        public float? BanKinhAnhHuong { get; set; }
        public string? VungAnhHuong { get; set; }
        public string? MucDo { get; set; }
        public string MaNguoiTao { get; set; } = null!;
        public string? MaNguoiDuyet { get; set; }
        public string TrangThai { get; set; } = "Chờ duyệt";
        public bool IsSent { get; set; } = false;
        public DateTime? SentAt { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now;

        public NguoiDung NguoiTao { get; set; } = null!;
        public NguoiDung? NguoiDuyet { get; set; }
    }
}
