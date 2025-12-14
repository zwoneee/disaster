namespace DoAn.Server.Entities
{
    public class KhoVatTu
    {
        public string MaKho { get; set; } = null!;
        public string TenKho { get; set; } = null!;
        public string? DiaChi { get; set; }
        public string? MaNguoiQuanLy { get; set; }

        public NguoiDung? NguoiQuanLy { get; set; }
        public ICollection<VatTuTrongKho> VatTuTrongKhos { get; set; } = new List<VatTuTrongKho>();
    }
}
