namespace DoAn.Server.Entities
{
    public class NguonLucCuuTro
    {
        public string MaNguonLuc { get; set; } = null!;
        public string TenNguonLuc { get; set; } = null!;
        public string? DonViTinh { get; set; }
        public string TinhTrang { get; set; } = "Tốt";
        public string? MaNguoiQuanLyKho { get; set; }

        public NguoiDung? NguoiQuanLyKho { get; set; }
        public ICollection<VatTuTrongKho> VatTuTrongKhos { get; set; } = new List<VatTuTrongKho>();
    }
}
