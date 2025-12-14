namespace DoAn.Server.Entities
{
    public class VatTuTrongKho
    {
        public string MaNguonLuc { get; set; } = null!;
        public string MaKho { get; set; } = null!;
        public decimal SoLuong { get; set; } = 0;

        public NguonLucCuuTro NguonLuc { get; set; } = null!;
        public KhoVatTu KhoVatTu { get; set; } = null!;
    }
}
