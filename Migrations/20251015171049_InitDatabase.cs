using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Truong",
                columns: table => new
                {
                    MaTruong = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenTruong = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DienThoai = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truong", x => x.MaTruong);
                });

            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    MaKhoa = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenKhoa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MaTruong = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa", x => x.MaKhoa);
                    table.ForeignKey(
                        name: "FK_Khoa_Truong_MaTruong",
                        column: x => x.MaTruong,
                        principalTable: "Truong",
                        principalColumn: "MaTruong",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    MaLH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenLH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaKhoa = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.MaLH);
                    table.ForeignKey(
                        name: "FK_LopHoc_Khoa_MaKhoa",
                        column: x => x.MaKhoa,
                        principalTable: "Khoa",
                        principalColumn: "MaKhoa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    MaND = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Ho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: true),
                    MaLH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    MaKhoa = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    VaiTro = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Hoạt động")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.MaND);
                    table.ForeignKey(
                        name: "FK_NguoiDung_Khoa_MaKhoa",
                        column: x => x.MaKhoa,
                        principalTable: "Khoa",
                        principalColumn: "MaKhoa",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_NguoiDung_LopHoc_MaLH",
                        column: x => x.MaLH,
                        principalTable: "LopHoc",
                        principalColumn: "MaLH",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DanhMuc",
                columns: table => new
                {
                    MaDM = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenDM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    MaNguoiTao = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMuc", x => x.MaDM);
                    table.ForeignKey(
                        name: "FK_DanhMuc_NguoiDung_MaNguoiTao",
                        column: x => x.MaNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "MaND",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "FileUpload",
                columns: table => new
                {
                    MaFile = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenFile = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DuongDan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    KichThuoc = table.Column<long>(type: "bigint", nullable: false),
                    LoaiFile = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgayUpload = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    MaND = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileUpload", x => x.MaFile);
                    table.ForeignKey(
                        name: "FK_FileUpload_NguoiDung_MaND",
                        column: x => x.MaND,
                        principalTable: "NguoiDung",
                        principalColumn: "MaND",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhatKy",
                columns: table => new
                {
                    MaNK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaND = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    HanhDong = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LoaiHanhDong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatKy", x => x.MaNK);
                    table.ForeignKey(
                        name: "FK_NhatKy_NguoiDung_MaND",
                        column: x => x.MaND,
                        principalTable: "NguoiDung",
                        principalColumn: "MaND",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Template",
                columns: table => new
                {
                    MaTemplate = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenTemplate = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    NgayTao = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "GETDATE()"),
                    MaNguoiTao = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    BackgroundColor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "#FFFFFF"),
                    BackgroundImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FontFamily = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Arial, sans-serif"),
                    QuestionColor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "#000000"),
                    QuestionFontSize = table.Column<int>(type: "int", nullable: false, defaultValue: 18),
                    AnswerColor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "#333333"),
                    AnswerBackgroundColor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "#FFFFFF"),
                    AnswerBorderRadius = table.Column<int>(type: "int", nullable: false, defaultValue: 8),
                    ButtonColor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "#4A90E2"),
                    ButtonTextColor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "#FFFFFF"),
                    ButtonBorderRadius = table.Column<int>(type: "int", nullable: false, defaultValue: 25)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Template", x => x.MaTemplate);
                    table.ForeignKey(
                        name: "FK_Template_NguoiDung_MaNguoiTao",
                        column: x => x.MaNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "MaND",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "KhaoSat",
                columns: table => new
                {
                    MaKS = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenKS = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "date", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "date", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "Đang hoạt động"),
                    MaDM = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MaNguoiTao = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MaTemplate = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ApDungToanTruong = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DanhSachKhoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanhSachLop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanhSachNguoiChinhSua = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhaoSat", x => x.MaKS);
                    table.ForeignKey(
                        name: "FK_KhaoSat_DanhMuc_MaDM",
                        column: x => x.MaDM,
                        principalTable: "DanhMuc",
                        principalColumn: "MaDM",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KhaoSat_NguoiDung_MaNguoiTao",
                        column: x => x.MaNguoiTao,
                        principalTable: "NguoiDung",
                        principalColumn: "MaND",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KhaoSat_Template_MaTemplate",
                        column: x => x.MaTemplate,
                        principalTable: "Template",
                        principalColumn: "MaTemplate",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BaoCao",
                columns: table => new
                {
                    MaBC = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MaKS = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    TongSoPhanHoi = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    GhiChu = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoCao", x => x.MaBC);
                    table.ForeignKey(
                        name: "FK_BaoCao_KhaoSat_MaKS",
                        column: x => x.MaKS,
                        principalTable: "KhaoSat",
                        principalColumn: "MaKS",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CauHoi",
                columns: table => new
                {
                    MaCH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MaKS = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LoaiCauHoi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ThuTu = table.Column<int>(type: "int", nullable: false),
                    BatBuoc = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SoLuongChonToiDa = table.Column<int>(type: "int", nullable: true),
                    GiaTriToiThieu = table.Column<int>(type: "int", nullable: true),
                    GiaTriToiDa = table.Column<int>(type: "int", nullable: true),
                    HinhAnhMinhHoa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    VideoMinhHoa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHoi", x => x.MaCH);
                    table.ForeignKey(
                        name: "FK_CauHoi_KhaoSat_MaKS",
                        column: x => x.MaKS,
                        principalTable: "KhaoSat",
                        principalColumn: "MaKS",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhanHoi",
                columns: table => new
                {
                    MaPH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MaKS = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MaND = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NgayPhanHoi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Hoàn thành")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanHoi", x => x.MaPH);
                    table.ForeignKey(
                        name: "FK_PhanHoi_KhaoSat_MaKS",
                        column: x => x.MaKS,
                        principalTable: "KhaoSat",
                        principalColumn: "MaKS",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhanHoi_NguoiDung_MaND",
                        column: x => x.MaND,
                        principalTable: "NguoiDung",
                        principalColumn: "MaND",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ColMatrix",
                columns: table => new
                {
                    MaCol = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MaCH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ThuTu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColMatrix", x => x.MaCol);
                    table.ForeignKey(
                        name: "FK_ColMatrix_CauHoi_MaCH",
                        column: x => x.MaCH,
                        principalTable: "CauHoi",
                        principalColumn: "MaCH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LuaChon",
                columns: table => new
                {
                    MaLC = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MaCH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    GiaTri = table.Column<int>(type: "int", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LuaChon", x => x.MaLC);
                    table.ForeignKey(
                        name: "FK_LuaChon_CauHoi_MaCH",
                        column: x => x.MaCH,
                        principalTable: "CauHoi",
                        principalColumn: "MaCH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RowMatrix",
                columns: table => new
                {
                    MaRow = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MaCH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ThuTu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RowMatrix", x => x.MaRow);
                    table.ForeignKey(
                        name: "FK_RowMatrix_CauHoi_MaCH",
                        column: x => x.MaCH,
                        principalTable: "CauHoi",
                        principalColumn: "MaCH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhanHoiChiTiet",
                columns: table => new
                {
                    MaPHCT = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MaPH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MaCH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NoiDungText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MaLC = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    DanhSachMaLC = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MaRow = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    MaCol = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    DanhSachMaTrich = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    GiaTriSo = table.Column<int>(type: "int", nullable: true),
                    GiaTriNgay = table.Column<DateTime>(type: "date", nullable: true),
                    GiaTriGio = table.Column<TimeSpan>(type: "time", nullable: true),
                    GiaTriDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaFile = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanHoiChiTiet", x => x.MaPHCT);
                    table.ForeignKey(
                        name: "FK_PhanHoiChiTiet_CauHoi_MaCH",
                        column: x => x.MaCH,
                        principalTable: "CauHoi",
                        principalColumn: "MaCH",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhanHoiChiTiet_ColMatrix_MaCol",
                        column: x => x.MaCol,
                        principalTable: "ColMatrix",
                        principalColumn: "MaCol",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhanHoiChiTiet_FileUpload_MaFile",
                        column: x => x.MaFile,
                        principalTable: "FileUpload",
                        principalColumn: "MaFile",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PhanHoiChiTiet_LuaChon_MaLC",
                        column: x => x.MaLC,
                        principalTable: "LuaChon",
                        principalColumn: "MaLC",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhanHoiChiTiet_PhanHoi_MaPH",
                        column: x => x.MaPH,
                        principalTable: "PhanHoi",
                        principalColumn: "MaPH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanHoiChiTiet_RowMatrix_MaRow",
                        column: x => x.MaRow,
                        principalTable: "RowMatrix",
                        principalColumn: "MaRow",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaoCao_MaKS",
                table: "BaoCao",
                column: "MaKS");

            migrationBuilder.CreateIndex(
                name: "IX_CauHoi_MaKS_ThuTu",
                table: "CauHoi",
                columns: new[] { "MaKS", "ThuTu" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ColMatrix_MaCH",
                table: "ColMatrix",
                column: "MaCH");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMuc_MaNguoiTao",
                table: "DanhMuc",
                column: "MaNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_FileUpload_MaND",
                table: "FileUpload",
                column: "MaND");

            migrationBuilder.CreateIndex(
                name: "IX_KhaoSat_MaDM",
                table: "KhaoSat",
                column: "MaDM");

            migrationBuilder.CreateIndex(
                name: "IX_KhaoSat_MaNguoiTao",
                table: "KhaoSat",
                column: "MaNguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KhaoSat_MaTemplate",
                table: "KhaoSat",
                column: "MaTemplate");

            migrationBuilder.CreateIndex(
                name: "IX_Khoa_MaTruong",
                table: "Khoa",
                column: "MaTruong");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_MaKhoa",
                table: "LopHoc",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_LuaChon_MaCH_ThuTu",
                table: "LuaChon",
                columns: new[] { "MaCH", "ThuTu" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_Email",
                table: "NguoiDung",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_MaKhoa",
                table: "NguoiDung",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_MaLH",
                table: "NguoiDung",
                column: "MaLH");

            migrationBuilder.CreateIndex(
                name: "IX_NhatKy_MaND",
                table: "NhatKy",
                column: "MaND");

            migrationBuilder.CreateIndex(
                name: "IX_PhanHoi_MaKS_MaND",
                table: "PhanHoi",
                columns: new[] { "MaKS", "MaND" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhanHoi_MaND",
                table: "PhanHoi",
                column: "MaND");

            migrationBuilder.CreateIndex(
                name: "IX_PhanHoiChiTiet_MaCH",
                table: "PhanHoiChiTiet",
                column: "MaCH");

            migrationBuilder.CreateIndex(
                name: "IX_PhanHoiChiTiet_MaCol",
                table: "PhanHoiChiTiet",
                column: "MaCol");

            migrationBuilder.CreateIndex(
                name: "IX_PhanHoiChiTiet_MaFile",
                table: "PhanHoiChiTiet",
                column: "MaFile");

            migrationBuilder.CreateIndex(
                name: "IX_PhanHoiChiTiet_MaLC",
                table: "PhanHoiChiTiet",
                column: "MaLC");

            migrationBuilder.CreateIndex(
                name: "IX_PhanHoiChiTiet_MaPH",
                table: "PhanHoiChiTiet",
                column: "MaPH");

            migrationBuilder.CreateIndex(
                name: "IX_PhanHoiChiTiet_MaRow",
                table: "PhanHoiChiTiet",
                column: "MaRow");

            migrationBuilder.CreateIndex(
                name: "IX_RowMatrix_MaCH",
                table: "RowMatrix",
                column: "MaCH");

            migrationBuilder.CreateIndex(
                name: "IX_Template_MaNguoiTao",
                table: "Template",
                column: "MaNguoiTao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaoCao");

            migrationBuilder.DropTable(
                name: "NhatKy");

            migrationBuilder.DropTable(
                name: "PhanHoiChiTiet");

            migrationBuilder.DropTable(
                name: "ColMatrix");

            migrationBuilder.DropTable(
                name: "FileUpload");

            migrationBuilder.DropTable(
                name: "LuaChon");

            migrationBuilder.DropTable(
                name: "PhanHoi");

            migrationBuilder.DropTable(
                name: "RowMatrix");

            migrationBuilder.DropTable(
                name: "CauHoi");

            migrationBuilder.DropTable(
                name: "KhaoSat");

            migrationBuilder.DropTable(
                name: "DanhMuc");

            migrationBuilder.DropTable(
                name: "Template");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "LopHoc");

            migrationBuilder.DropTable(
                name: "Khoa");

            migrationBuilder.DropTable(
                name: "Truong");
        }
    }
}
