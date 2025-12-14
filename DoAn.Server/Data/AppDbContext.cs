// DoAn.Server/Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using DoAn.Server.Models;
using DoAn.Server.Entities;

namespace DoAn.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // ==================== DBSET ====================
        public DbSet<VaiTro> VaiTro => Set<VaiTro>();
        public DbSet<NguoiDung> NguoiDung => Set<NguoiDung>();
        public DbSet<CanhBao> CanhBao => Set<CanhBao>();
        public DbSet<BaoCaoHienTruong> BaoCaoHienTruong => Set<BaoCaoHienTruong>();
        public DbSet<TinTuc> TinTuc => Set<TinTuc>();
        public DbSet<BinhLuan> BinhLuan => Set<BinhLuan>();
        public DbSet<ThongBaoCaNhan> ThongBaoCaNhan => Set<ThongBaoCaNhan>();
        public DbSet<NguonLucCuuTro> NguonLucCuuTro => Set<NguonLucCuuTro>();
        public DbSet<KhoVatTu> KhoVatTu => Set<KhoVatTu>();
        public DbSet<VatTuTrongKho> VatTuTrongKho => Set<VatTuTrongKho>();
        public DbSet<QuyenGop> QuyenGop => Set<QuyenGop>();
        public DbSet<DoiCuuHo> DoiCuuHo => Set<DoiCuuHo>();
        public DbSet<TinhNguyenVien> TinhNguyenVien => Set<TinhNguyenVien>();
        public DbSet<NhiemVuCuuHo> NhiemVuCuuHo => Set<NhiemVuCuuHo>();
        public DbSet<PhanCongNhiemVu> PhanCongNhiemVu => Set<PhanCongNhiemVu>();
        public DbSet<PhanCongTinhNguyenVien> PhanCongTinhNguyenVien => Set<PhanCongTinhNguyenVien>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ==================== SEQUENCE CHO TẤT CẢ BẢNG ====================
            var sequences = new[]
            {
                "Seq_VaiTro_ID", "Seq_NguoiDung_ID", "Seq_CanhBao_ID", "Seq_BaoCaoHT_ID",
                "Seq_TinTuc_ID", "Seq_ThongBao_ID", "Seq_NguonLuc_ID", "Seq_KhoVatTu_ID",
                "Seq_QuyenGop_ID", "Seq_DoiCuuHo_ID", "Seq_NhiemVuCuuHo_ID",
                "Seq_TinhNguyenVien_ID", "Seq_BinhLuan_ID"
            };

            foreach (var seq in sequences)
                modelBuilder.HasSequence<int>(seq).StartsAt(1).IncrementsBy(1);

            // ==================== KHÓA CHÍNH + MÃ TỰ ĐỘNG ====================
            modelBuilder.Entity<VaiTro>(e =>
            {
                e.HasKey(x => x.MaVaiTro);
                e.Property(x => x.MaVaiTro).HasDefaultValueSql("'VT' + FORMAT(NEXT VALUE FOR Seq_VaiTro_ID, '00')");
            });

            modelBuilder.Entity<NguoiDung>(e =>
            {
                e.HasKey(x => x.MaNguoiDung);
                e.Property(x => x.MaNguoiDung).HasDefaultValueSql("'U' + FORMAT(NEXT VALUE FOR Seq_NguoiDung_ID, '000')");
            });

            modelBuilder.Entity<CanhBao>(e =>
            {
                e.HasKey(x => x.MaCanhBao);
                e.Property(x => x.MaCanhBao).HasDefaultValueSql("'CB' + FORMAT(NEXT VALUE FOR Seq_CanhBao_ID, '000')");
            });

            modelBuilder.Entity<BaoCaoHienTruong>(e =>
            {
                e.HasKey(x => x.MaBaoCaoHT);
                e.Property(x => x.MaBaoCaoHT).HasDefaultValueSql("'BCHT' + FORMAT(NEXT VALUE FOR Seq_BaoCaoHT_ID, '000')");
            });

            modelBuilder.Entity<TinTuc>(e =>
            {
                e.HasKey(x => x.MaTinTuc);
                e.Property(x => x.MaTinTuc).HasDefaultValueSql("'TT' + FORMAT(NEXT VALUE FOR Seq_TinTuc_ID, '000')");
            });

            modelBuilder.Entity<BinhLuan>(e =>
            {
                e.HasKey(x => x.MaBinhLuan);
                e.Property(x => x.MaBinhLuan).HasDefaultValueSql("NEXT VALUE FOR Seq_BinhLuan_ID"); // int nên không cần prefix
            });

            modelBuilder.Entity<ThongBaoCaNhan>(e =>
            {
                e.HasKey(x => x.MaThongBao);
                e.Property(x => x.MaThongBao).HasDefaultValueSql("'TB' + FORMAT(NEXT VALUE FOR Seq_ThongBao_ID, '000')");
            });

            modelBuilder.Entity<NguonLucCuuTro>(e =>
            {
                e.HasKey(x => x.MaNguonLuc);
                e.Property(x => x.MaNguonLuc).HasDefaultValueSql("'NL' + FORMAT(NEXT VALUE FOR Seq_NguonLuc_ID, '000')");
            });

            modelBuilder.Entity<KhoVatTu>(e =>
            {
                e.HasKey(x => x.MaKho);
                e.Property(x => x.MaKho).HasDefaultValueSql("'K' + FORMAT(NEXT VALUE FOR Seq_KhoVatTu_ID, '000')");
            });

            modelBuilder.Entity<QuyenGop>(e =>
            {
                e.HasKey(x => x.MaQuyenGop);
                e.Property(x => x.MaQuyenGop).HasDefaultValueSql("'QG' + FORMAT(NEXT VALUE FOR Seq_QuyenGop_ID, '000')");
            });

            modelBuilder.Entity<DoiCuuHo>(e =>
            {
                e.HasKey(x => x.MaDoiCuuHo);
                e.Property(x => x.MaDoiCuuHo).HasDefaultValueSql("'DCH' + FORMAT(NEXT VALUE FOR Seq_DoiCuuHo_ID, '000')");
            });

            modelBuilder.Entity<TinhNguyenVien>(e =>
            {
                e.HasKey(x => x.MaTinhNguyenVien);
                e.Property(x => x.MaTinhNguyenVien).HasDefaultValueSql("'TNV' + FORMAT(NEXT VALUE FOR Seq_TinhNguyenVien_ID, '000')");
            });

            modelBuilder.Entity<NhiemVuCuuHo>(e =>
            {
                e.HasKey(x => x.MaNhiemVu);
                e.Property(x => x.MaNhiemVu).HasDefaultValueSql("'NV' + FORMAT(NEXT VALUE FOR Seq_NhiemVuCuuHo_ID, '000')");
            });

            // ==================== KHÓA NGOẠI & QUAN HỆ ====================

            // Người dùng - Vai trò
            modelBuilder.Entity<NguoiDung>()
                .HasOne(u => u.VaiTro)
                .WithMany(v => v.NguoiDungs)
                .HasForeignKey(u => u.MaVaiTro)
                .OnDelete(DeleteBehavior.Restrict);

            // Cảnh báo
            modelBuilder.Entity<CanhBao>()
                .HasOne(c => c.NguoiTao)
                .WithMany()
                .HasForeignKey(c => c.MaNguoiTao)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CanhBao>()
                .HasOne(c => c.NguoiDuyet)
                .WithMany()
                .HasForeignKey(c => c.MaNguoiDuyet)
                .OnDelete(DeleteBehavior.SetNull);

            // Báo cáo hiện trường
            modelBuilder.Entity<BaoCaoHienTruong>()
                .HasOne(b => b.NguoiBaoCao)
                .WithMany()
                .HasForeignKey(b => b.MaNguoiBaoCao)
                .OnDelete(DeleteBehavior.Restrict);

            // Tin tức & Bình luận
            modelBuilder.Entity<TinTuc>()
                .HasOne(t => t.NguoiTao)
                .WithMany()
                .HasForeignKey(t => t.MaNguoiTao)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BinhLuan>()
                .HasOne(bl => bl.TinTuc)
                .WithMany(t => t.BinhLuans)
                .HasForeignKey(bl => bl.MaTinTuc)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BinhLuan>()
                .HasOne(bl => bl.NguoiDung)
                .WithMany()
                .HasForeignKey(bl => bl.MaNguoiDung)
                .OnDelete(DeleteBehavior.Restrict);

            // Thông báo cá nhân
            modelBuilder.Entity<ThongBaoCaNhan>()
                .HasOne(t => t.NguoiNhan)
                .WithMany()
                .HasForeignKey(t => t.MaNguoiNhan)
                .OnDelete(DeleteBehavior.Cascade);

            // Nguồn lực & Kho
            modelBuilder.Entity<NguonLucCuuTro>()
                .HasOne(n => n.NguoiQuanLyKho)
                .WithMany()
                .HasForeignKey(n => n.MaNguoiQuanLyKho)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<KhoVatTu>()
                .HasOne(k => k.NguoiQuanLy)
                .WithMany()
                .HasForeignKey(k => k.MaNguoiQuanLy)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<VatTuTrongKho>()
                .HasOne(v => v.NguonLuc)
                .WithMany(n => n.VatTuTrongKhos)
                .HasForeignKey(v => v.MaNguonLuc)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VatTuTrongKho>()
                .HasOne(v => v.KhoVatTu)
                .WithMany(k => k.VatTuTrongKhos)
                .HasForeignKey(v => v.MaKho)
                .OnDelete(DeleteBehavior.Cascade);

            // Quyên góp
            modelBuilder.Entity<QuyenGop>()
                .HasOne(q => q.NguoiQuyenGop)
                .WithMany()
                .HasForeignKey(q => q.MaNguoiQuyenGop)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<QuyenGop>()
                .HasOne(q => q.NguonLuc)
                .WithMany()
                .HasForeignKey(q => q.MaNguonLuc)
                .OnDelete(DeleteBehavior.SetNull);

            // Đội cứu hộ
            modelBuilder.Entity<DoiCuuHo>()
                .HasOne(d => d.NguoiQuanLy)
                .WithMany()
                .HasForeignKey(d => d.MaNguoiQuanLy)
                .OnDelete(DeleteBehavior.SetNull);

            // Tình nguyện viên (1-1 với NguoiDung)
            modelBuilder.Entity<TinhNguyenVien>()
                .HasOne(t => t.NguoiDung)
                .WithMany()
                .HasForeignKey(t => t.MaNguoiDung)
                .OnDelete(DeleteBehavior.Cascade);

            // Nhiệm vụ cứu hộ - Người tạo
            modelBuilder.Entity<NhiemVuCuuHo>()
                .HasOne(n => n.NguoiTao)
                .WithMany()
                .HasForeignKey(n => n.MaNguoiTao)
                .OnDelete(DeleteBehavior.Restrict);

            // ==================== NHIỀU-NHIỀU CHUẨN EF CORE ====================

            // Phân công nhiệm vụ cho Đội cứu hộ
            modelBuilder.Entity<PhanCongNhiemVu>()
                .HasOne(p => p.NhiemVu)
                .WithMany(n => n.PhanCongNhiemVus)
                .HasForeignKey(p => p.MaNhiemVu)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PhanCongNhiemVu>()
                .HasOne(p => p.DoiCuuHo)
                .WithMany(d => d.PhanCongNhiemVus)
                .HasForeignKey(p => p.MaDoiCuuHo)
                .OnDelete(DeleteBehavior.Cascade);

            // Phân công tình nguyện viên vào nhiệm vụ
            modelBuilder.Entity<PhanCongTinhNguyenVien>()
                .HasOne(p => p.TinhNguyenVien)
                .WithMany(t => t.PhanCongNhiemVus)
                .HasForeignKey(p => p.MaTinhNguyenVien)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PhanCongTinhNguyenVien>()
                .HasOne(p => p.NhiemVu)
                .WithMany(n => n.PhanCongTinhNguyenViens)
                .HasForeignKey(p => p.MaNhiemVu)
                .OnDelete(DeleteBehavior.Cascade);

            // ==================== KHÓA CHÍNH COMPOSITE ====================
            modelBuilder.Entity<VatTuTrongKho>()
                .HasKey(v => new { v.MaNguonLuc, v.MaKho });

            modelBuilder.Entity<PhanCongNhiemVu>()
                .HasKey(p => new { p.MaNhiemVu, p.MaDoiCuuHo });

            modelBuilder.Entity<PhanCongTinhNguyenVien>()
                .HasKey(p => new { p.MaTinhNguyenVien, p.MaNhiemVu });

            // ==================== INDEX ====================
            modelBuilder.Entity<BaoCaoHienTruong>()
                .HasIndex(b => new { b.KinhDo, b.ViDo });

            modelBuilder.Entity<CanhBao>()
                .HasIndex(c => c.TrangThai);

            modelBuilder.Entity<NhiemVuCuuHo>()
                .HasIndex(n => n.TrangThai);
        }
    }
}