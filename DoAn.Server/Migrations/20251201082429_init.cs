using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAn.Server.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "Seq_BaoCaoHT_ID");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_BinhLuan_ID");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_CanhBao_ID");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_DoiCuuHo_ID");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_KhoVatTu_ID");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_NguoiDung_ID");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_NguonLuc_ID");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_NhiemVuCuuHo_ID");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_QuyenGop_ID");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_ThongBao_ID");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_TinhNguyenVien_ID");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_TinTuc_ID");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_VaiTro_ID");

            migrationBuilder.CreateTable(
                name: "VaiTro",
                columns: table => new
                {
                    MaVaiTro = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "'VT' + FORMAT(NEXT VALUE FOR Seq_VaiTro_ID, '00')"),
                    TenVaiTro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTro", x => x.MaVaiTro);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    MaNguoiDung = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "'U' + FORMAT(NEXT VALUE FOR Seq_NguoiDung_ID, '000')"),
                    TenDangNhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaVaiTro = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    LoginAttempts = table.Column<byte>(type: "tinyint", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LanDangNhapCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.MaNguoiDung);
                    table.ForeignKey(
                        name: "FK_NguoiDung_VaiTro_MaVaiTro",
                        column: x => x.MaVaiTro,
                        principalTable: "VaiTro",
                        principalColumn: "MaVaiTro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BaoCaoHienTruong",
                columns: table => new
                {
                    MaBaoCaoHT = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "'BCHT' + FORMAT(NEXT VALUE FOR Seq_BaoCaoHT_ID, '000')"),
                    MaNguoiBaoCao = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KinhDo = table.Column<float>(type: "real", nullable: true),
                    ViDo = table.Column<float>(type: "real", nullable: true),
                    LinkHinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiThietHai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucDoThietHai = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoCaoHienTruong", x => x.MaBaoCaoHT);
                    table.ForeignKey(
                        name: "FK_BaoCaoHienTruong_NguoiDung_MaNguoiBaoCao",
                        column: x => x.MaNguoiBaoCao,
                        principalTable: "NguoiDung",
                        principalColumn: "MaNguoiDung",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CanhBao",
                columns: table => new
                {
                    MaCanhBao = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "'CB' + FORMAT(NEXT VALUE FOR Seq_CanhBao_ID, '000')"),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiCanhBao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KinhDo = table.Column<float>(type: "real", nullable: true),
                    ViDo = table.Column<float>(type: "real", nullable: true),
                    BanKinhAnhHuong = table.Column<float>(type: "real", nullable: true),
                    VungAnhHuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaNguoiTao = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaNguoiDuyet = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsSent = table.Column<bool>(type: "bit", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanhBao", x => x.MaCanhBao);
                    table.ForeignKey(
                        name: "FK_CanhBao_NguoiDung_MaNguoiDuyet",
                        column: x => x.MaNguoiDuyet,
                        principalTable: "NguoiDung",
                        principalColumn: "MaNguoiDung",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CanhBao_NguoiDung_MaNguoiTao",
                        column: x => x.MaNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "MaNguoiDung",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoiCuuHo",
                columns: table => new
                {
                    MaDoiCuuHo = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "'DCH' + FORMAT(NEXT VALUE FOR Seq_DoiCuuHo_ID, '000')"),
                    TenDoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaNguoiQuanLy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoiCuuHo", x => x.MaDoiCuuHo);
                    table.ForeignKey(
                        name: "FK_DoiCuuHo_NguoiDung_MaNguoiQuanLy",
                        column: x => x.MaNguoiQuanLy,
                        principalTable: "NguoiDung",
                        principalColumn: "MaNguoiDung",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "KhoVatTu",
                columns: table => new
                {
                    MaKho = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "'K' + FORMAT(NEXT VALUE FOR Seq_KhoVatTu_ID, '000')"),
                    TenKho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaNguoiQuanLy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoVatTu", x => x.MaKho);
                    table.ForeignKey(
                        name: "FK_KhoVatTu_NguoiDung_MaNguoiQuanLy",
                        column: x => x.MaNguoiQuanLy,
                        principalTable: "NguoiDung",
                        principalColumn: "MaNguoiDung",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "NguonLucCuuTro",
                columns: table => new
                {
                    MaNguonLuc = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "'NL' + FORMAT(NEXT VALUE FOR Seq_NguonLuc_ID, '000')"),
                    TenNguonLuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaNguoiQuanLyKho = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguonLucCuuTro", x => x.MaNguonLuc);
                    table.ForeignKey(
                        name: "FK_NguonLucCuuTro_NguoiDung_MaNguoiQuanLyKho",
                        column: x => x.MaNguoiQuanLyKho,
                        principalTable: "NguoiDung",
                        principalColumn: "MaNguoiDung",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "NhiemVuCuuHo",
                columns: table => new
                {
                    MaNhiemVu = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "'NV' + FORMAT(NEXT VALUE FOR Seq_NhiemVuCuuHo_ID, '000')"),
                    MaNguoiTao = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaDoiCuuHo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhiemVuCuuHo", x => x.MaNhiemVu);
                    table.ForeignKey(
                        name: "FK_NhiemVuCuuHo_NguoiDung_MaNguoiTao",
                        column: x => x.MaNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "MaNguoiDung",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThongBaoCaNhan",
                columns: table => new
                {
                    MaThongBao = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "'TB' + FORMAT(NEXT VALUE FOR Seq_ThongBao_ID, '000')"),
                    MaNguoiNhan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiThongBao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    NgayGui = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBaoCaNhan", x => x.MaThongBao);
                    table.ForeignKey(
                        name: "FK_ThongBaoCaNhan_NguoiDung_MaNguoiNhan",
                        column: x => x.MaNguoiNhan,
                        principalTable: "NguoiDung",
                        principalColumn: "MaNguoiDung",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TinhNguyenVien",
                columns: table => new
                {
                    MaTinhNguyenVien = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "'TNV' + FORMAT(NEXT VALUE FOR Seq_TinhNguyenVien_ID, '000')"),
                    MaNguoiDung = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhNguyenVien", x => x.MaTinhNguyenVien);
                    table.ForeignKey(
                        name: "FK_TinhNguyenVien_NguoiDung_MaNguoiDung",
                        column: x => x.MaNguoiDung,
                        principalTable: "NguoiDung",
                        principalColumn: "MaNguoiDung",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TinTuc",
                columns: table => new
                {
                    MaTinTuc = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "'TT' + FORMAT(NEXT VALUE FOR Seq_TinTuc_ID, '000')"),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhBia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaNguoiTao = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LuotXem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinTuc", x => x.MaTinTuc);
                    table.ForeignKey(
                        name: "FK_TinTuc_NguoiDung_MaNguoiTao",
                        column: x => x.MaNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "MaNguoiDung",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuyenGop",
                columns: table => new
                {
                    MaQuyenGop = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "'QG' + FORMAT(NEXT VALUE FOR Seq_QuyenGop_ID, '000')"),
                    MaNguoiQuyenGop = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaNguonLuc = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SoLuong = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoaiQuyenGop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayQuyenGop = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenGop", x => x.MaQuyenGop);
                    table.ForeignKey(
                        name: "FK_QuyenGop_NguoiDung_MaNguoiQuyenGop",
                        column: x => x.MaNguoiQuyenGop,
                        principalTable: "NguoiDung",
                        principalColumn: "MaNguoiDung",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_QuyenGop_NguonLucCuuTro_MaNguonLuc",
                        column: x => x.MaNguonLuc,
                        principalTable: "NguonLucCuuTro",
                        principalColumn: "MaNguonLuc",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "VatTuTrongKho",
                columns: table => new
                {
                    MaNguonLuc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaKho = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoLuong = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VatTuTrongKho", x => new { x.MaNguonLuc, x.MaKho });
                    table.ForeignKey(
                        name: "FK_VatTuTrongKho_KhoVatTu_MaKho",
                        column: x => x.MaKho,
                        principalTable: "KhoVatTu",
                        principalColumn: "MaKho",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VatTuTrongKho_NguonLucCuuTro_MaNguonLuc",
                        column: x => x.MaNguonLuc,
                        principalTable: "NguonLucCuuTro",
                        principalColumn: "MaNguonLuc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhanCongNhiemVu",
                columns: table => new
                {
                    MaNhiemVu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaDoiCuuHo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayPhanCong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanCongNhiemVu", x => new { x.MaNhiemVu, x.MaDoiCuuHo });
                    table.ForeignKey(
                        name: "FK_PhanCongNhiemVu_DoiCuuHo_MaDoiCuuHo",
                        column: x => x.MaDoiCuuHo,
                        principalTable: "DoiCuuHo",
                        principalColumn: "MaDoiCuuHo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanCongNhiemVu_NhiemVuCuuHo_MaNhiemVu",
                        column: x => x.MaNhiemVu,
                        principalTable: "NhiemVuCuuHo",
                        principalColumn: "MaNhiemVu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhanCongTinhNguyenVien",
                columns: table => new
                {
                    MaTinhNguyenVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaNhiemVu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayPhanCong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanCongTinhNguyenVien", x => new { x.MaTinhNguyenVien, x.MaNhiemVu });
                    table.ForeignKey(
                        name: "FK_PhanCongTinhNguyenVien_NhiemVuCuuHo_MaNhiemVu",
                        column: x => x.MaNhiemVu,
                        principalTable: "NhiemVuCuuHo",
                        principalColumn: "MaNhiemVu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanCongTinhNguyenVien_TinhNguyenVien_MaTinhNguyenVien",
                        column: x => x.MaTinhNguyenVien,
                        principalTable: "TinhNguyenVien",
                        principalColumn: "MaTinhNguyenVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BinhLuan",
                columns: table => new
                {
                    MaBinhLuan = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR Seq_BinhLuan_ID"),
                    MaTinTuc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaNguoiDung = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinhLuan", x => x.MaBinhLuan);
                    table.ForeignKey(
                        name: "FK_BinhLuan_NguoiDung_MaNguoiDung",
                        column: x => x.MaNguoiDung,
                        principalTable: "NguoiDung",
                        principalColumn: "MaNguoiDung",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BinhLuan_TinTuc_MaTinTuc",
                        column: x => x.MaTinTuc,
                        principalTable: "TinTuc",
                        principalColumn: "MaTinTuc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoHienTruong_KinhDo_ViDo",
                table: "BaoCaoHienTruong",
                columns: new[] { "KinhDo", "ViDo" });

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoHienTruong_MaNguoiBaoCao",
                table: "BaoCaoHienTruong",
                column: "MaNguoiBaoCao");

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuan_MaNguoiDung",
                table: "BinhLuan",
                column: "MaNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuan_MaTinTuc",
                table: "BinhLuan",
                column: "MaTinTuc");

            migrationBuilder.CreateIndex(
                name: "IX_CanhBao_MaNguoiDuyet",
                table: "CanhBao",
                column: "MaNguoiDuyet");

            migrationBuilder.CreateIndex(
                name: "IX_CanhBao_MaNguoiTao",
                table: "CanhBao",
                column: "MaNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_CanhBao_TrangThai",
                table: "CanhBao",
                column: "TrangThai");

            migrationBuilder.CreateIndex(
                name: "IX_DoiCuuHo_MaNguoiQuanLy",
                table: "DoiCuuHo",
                column: "MaNguoiQuanLy");

            migrationBuilder.CreateIndex(
                name: "IX_KhoVatTu_MaNguoiQuanLy",
                table: "KhoVatTu",
                column: "MaNguoiQuanLy");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_MaVaiTro",
                table: "NguoiDung",
                column: "MaVaiTro");

            migrationBuilder.CreateIndex(
                name: "IX_NguonLucCuuTro_MaNguoiQuanLyKho",
                table: "NguonLucCuuTro",
                column: "MaNguoiQuanLyKho");

            migrationBuilder.CreateIndex(
                name: "IX_NhiemVuCuuHo_MaNguoiTao",
                table: "NhiemVuCuuHo",
                column: "MaNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_NhiemVuCuuHo_TrangThai",
                table: "NhiemVuCuuHo",
                column: "TrangThai");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCongNhiemVu_MaDoiCuuHo",
                table: "PhanCongNhiemVu",
                column: "MaDoiCuuHo");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCongTinhNguyenVien_MaNhiemVu",
                table: "PhanCongTinhNguyenVien",
                column: "MaNhiemVu");

            migrationBuilder.CreateIndex(
                name: "IX_QuyenGop_MaNguoiQuyenGop",
                table: "QuyenGop",
                column: "MaNguoiQuyenGop");

            migrationBuilder.CreateIndex(
                name: "IX_QuyenGop_MaNguonLuc",
                table: "QuyenGop",
                column: "MaNguonLuc");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaoCaNhan_MaNguoiNhan",
                table: "ThongBaoCaNhan",
                column: "MaNguoiNhan");

            migrationBuilder.CreateIndex(
                name: "IX_TinhNguyenVien_MaNguoiDung",
                table: "TinhNguyenVien",
                column: "MaNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_TinTuc_MaNguoiTao",
                table: "TinTuc",
                column: "MaNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_VatTuTrongKho_MaKho",
                table: "VatTuTrongKho",
                column: "MaKho");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaoCaoHienTruong");

            migrationBuilder.DropTable(
                name: "BinhLuan");

            migrationBuilder.DropTable(
                name: "CanhBao");

            migrationBuilder.DropTable(
                name: "PhanCongNhiemVu");

            migrationBuilder.DropTable(
                name: "PhanCongTinhNguyenVien");

            migrationBuilder.DropTable(
                name: "QuyenGop");

            migrationBuilder.DropTable(
                name: "ThongBaoCaNhan");

            migrationBuilder.DropTable(
                name: "VatTuTrongKho");

            migrationBuilder.DropTable(
                name: "TinTuc");

            migrationBuilder.DropTable(
                name: "DoiCuuHo");

            migrationBuilder.DropTable(
                name: "NhiemVuCuuHo");

            migrationBuilder.DropTable(
                name: "TinhNguyenVien");

            migrationBuilder.DropTable(
                name: "KhoVatTu");

            migrationBuilder.DropTable(
                name: "NguonLucCuuTro");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "VaiTro");

            migrationBuilder.DropSequence(
                name: "Seq_BaoCaoHT_ID");

            migrationBuilder.DropSequence(
                name: "Seq_BinhLuan_ID");

            migrationBuilder.DropSequence(
                name: "Seq_CanhBao_ID");

            migrationBuilder.DropSequence(
                name: "Seq_DoiCuuHo_ID");

            migrationBuilder.DropSequence(
                name: "Seq_KhoVatTu_ID");

            migrationBuilder.DropSequence(
                name: "Seq_NguoiDung_ID");

            migrationBuilder.DropSequence(
                name: "Seq_NguonLuc_ID");

            migrationBuilder.DropSequence(
                name: "Seq_NhiemVuCuuHo_ID");

            migrationBuilder.DropSequence(
                name: "Seq_QuyenGop_ID");

            migrationBuilder.DropSequence(
                name: "Seq_ThongBao_ID");

            migrationBuilder.DropSequence(
                name: "Seq_TinhNguyenVien_ID");

            migrationBuilder.DropSequence(
                name: "Seq_TinTuc_ID");

            migrationBuilder.DropSequence(
                name: "Seq_VaiTro_ID");
        }
    }
}
