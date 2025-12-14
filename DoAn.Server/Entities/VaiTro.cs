namespace DoAn.Server.Entities
{
    public class VaiTro
    {
        public string MaVaiTro { get; set; } = null!;
        public string TenVaiTro { get; set; } = null!;
        public string? MoTa { get; set; }
        public ICollection<NguoiDung> NguoiDungs { get; set; } = new List<NguoiDung>();
    }
}
