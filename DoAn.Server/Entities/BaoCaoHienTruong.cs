using DoAn.Server.Models;
using System.ComponentModel.DataAnnotations;

namespace DoAn.Server.Entities
{
    public class BaoCaoHienTruong
    {
        public string MaBaoCaoHT { get; set; } = null!;
        public string MaNguoiBaoCao { get; set; } = null!;
        public string? TieuDe { get; set; }
        public string? NoiDung { get; set; }
        public float? KinhDo { get; set; }
        public float? ViDo { get; set; }
        public string? LinkHinhAnh { get; set; }
        public string? LinkVideo { get; set; }
        public string? LoaiThietHai { get; set; }
        public int? MucDoThietHai { get; set; }
        public string TrangThai { get; set; } = "Chờ duyệt";
        public DateTime NgayTao { get; set; } = DateTime.Now;

        public NguoiDung NguoiBaoCao { get; set; } = null!;
    }
}
