using Microsoft.EntityFrameworkCore;
using SurveyWeb.Models.Entity;

namespace SurveyWeb.Models.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BaoCao> BaoCao { get; set; }
        public DbSet<CauHoi> CauHoi { get; set; }
        public DbSet<ColMatrix> ColMatrix { get; set; }
        public DbSet<DanhMuc> DanhMuc { get; set; }
        public DbSet<PhanHoiChiTiet> PhanHoiChiTiet { get; set; }
        public DbSet<FileUpload> FileUpload { get; set; }
        public DbSet<KhaoSat> KhaoSat { get; set; }
        public DbSet<Khoa> Khoa { get; set; }
        public DbSet<LopHoc> LopHoc { get; set; }
        public DbSet<LuaChon> LuaChon { get; set; }
        public DbSet<NguoiDung> NguoiDung { get; set; }
        public DbSet<NhatKy> NhatKy { get; set; }
        public DbSet<PhanHoi> PhanHoi { get; set; }
        public DbSet<RowMatrix> RowMatrix { get; set; }
        public DbSet<Template> Template { get; set; }
        public DbSet<Truong> Truong { get; set; }

        //Cấu hình các thuộc tính các bảng
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureTables(modelBuilder);
            ConfigureUniqueConstraints(modelBuilder);
            ConfigureRelationships(modelBuilder);
        }

        private void ConfigureTables(ModelBuilder modelBuilder)
        {
            // TRUONG
            modelBuilder.Entity<Truong>(entity =>
            {
                entity.HasKey(e => e.MaTruong);
                entity.Property(e => e.MaTruong).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.TenTruong).HasMaxLength(200).IsRequired();
                entity.Property(e => e.DiaChi).HasMaxLength(300);
                entity.Property(e => e.DienThoai).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(100);
            });

            // KHOA
            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.HasKey(e => e.MaKhoa);
                entity.Property(e => e.MaKhoa).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.TenKhoa).HasMaxLength(200).IsRequired();
                entity.Property(e => e.MaTruong).HasMaxLength(10).IsUnicode(false).IsRequired();
            });

            // LOPHOC
            modelBuilder.Entity<LopHoc>(entity =>
            {
                entity.HasKey(e => e.MaLH);
                entity.Property(e => e.MaLH).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.TenLH).HasMaxLength(100).IsRequired();
                entity.Property(e => e.MaKhoa).HasMaxLength(10).IsUnicode(false).IsRequired();
            });

            // NGUOIDUNG - ĐÃ SỬA: Tất cả cột có thể null đều có IsRequired(false)
            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.MaND);
                entity.Property(e => e.MaND).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.Ho).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Ten).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
                entity.Property(e => e.MatKhau).HasMaxLength(100).IsRequired();
                entity.Property(e => e.GioiTinh).HasMaxLength(10).IsRequired(false);
                entity.Property(e => e.NgaySinh).HasColumnType("date");
                entity.Property(e => e.MaLH).HasMaxLength(10).IsUnicode(false).IsRequired(false);
                entity.Property(e => e.MaKhoa).HasMaxLength(10).IsUnicode(false).IsRequired(false);
                entity.Property(e => e.VaiTro).HasMaxLength(20).IsRequired();
                entity.Property(e => e.TrangThai).HasMaxLength(20).HasDefaultValue("Hoạt động");
            });

            // NHATKY
            modelBuilder.Entity<NhatKy>(entity =>
            {
                entity.HasKey(e => e.MaNK);
                entity.Property(e => e.MaNK).ValueGeneratedOnAdd();
                entity.Property(e => e.MaND).HasMaxLength(10).IsUnicode(false).IsRequired();
                entity.Property(e => e.HanhDong).HasMaxLength(200).IsRequired();
                entity.Property(e => e.ThoiGian).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.MoTa).HasMaxLength(500);
                entity.Property(e => e.LoaiHanhDong).HasMaxLength(50);
            });

            // DANHMUC - ĐÃ SỬA: Thêm IsRequired(false) cho các cột có thể null
            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.HasKey(e => e.MaDM);
                entity.Property(e => e.MaDM).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.TenDM).HasMaxLength(200).IsRequired();
                entity.Property(e => e.MoTa).HasMaxLength(300).IsRequired(false);
                entity.Property(e => e.MaNguoiTao).HasMaxLength(10).IsUnicode(false).IsRequired(false);
            });

            // TEMPLATE - ĐÃ SỬA: Thêm IsRequired(false) cho các cột có thể null
            modelBuilder.Entity<Template>(entity =>
            {
                entity.HasKey(e => e.MaTemplate);
                entity.Property(e => e.MaTemplate).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.TenTemplate).HasMaxLength(200).IsRequired();
                entity.Property(e => e.MoTa).HasMaxLength(300).IsRequired(false);
                entity.Property(e => e.NgayTao).HasColumnType("date").HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.MaNguoiTao).HasMaxLength(10).IsUnicode(false).IsRequired(false);
                entity.Property(e => e.BackgroundColor).HasMaxLength(20).HasDefaultValue("#FFFFFF");
                entity.Property(e => e.BackgroundImage).HasMaxLength(500).IsRequired(false);
                entity.Property(e => e.FontFamily).HasMaxLength(100).HasDefaultValue("Arial, sans-serif");
                entity.Property(e => e.QuestionColor).HasMaxLength(20).HasDefaultValue("#000000");
                entity.Property(e => e.QuestionFontSize).HasDefaultValue(18);
                entity.Property(e => e.AnswerColor).HasMaxLength(20).HasDefaultValue("#333333");
                entity.Property(e => e.AnswerBackgroundColor).HasMaxLength(20).HasDefaultValue("#FFFFFF");
                entity.Property(e => e.AnswerBorderRadius).HasDefaultValue(8);
                entity.Property(e => e.ButtonColor).HasMaxLength(20).HasDefaultValue("#4A90E2");
                entity.Property(e => e.ButtonTextColor).HasMaxLength(20).HasDefaultValue("#FFFFFF");
                entity.Property(e => e.ButtonBorderRadius).HasDefaultValue(25);
            });

            // KHAOSAT - ĐÃ SỬA: Thêm IsRequired(false) cho các cột có thể null
            modelBuilder.Entity<KhaoSat>(entity =>
            {
                entity.HasKey(e => e.MaKS);
                entity.Property(e => e.MaKS).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.TenKS).HasMaxLength(200).IsRequired();
                entity.Property(e => e.MoTa).HasMaxLength(500).IsRequired(false);
                entity.Property(e => e.NgayBatDau).HasColumnType("date").IsRequired();
                entity.Property(e => e.NgayKetThuc).HasColumnType("date").IsRequired();
                entity.Property(e => e.TrangThai).HasMaxLength(30).HasDefaultValue("Đang hoạt động");
                entity.Property(e => e.MaDM).HasMaxLength(10).IsUnicode(false).IsRequired();
                entity.Property(e => e.MaNguoiTao).HasMaxLength(10).IsUnicode(false).IsRequired();
                entity.Property(e => e.MaTemplate).HasMaxLength(10).IsUnicode(false).IsRequired(false);
                entity.Property(e => e.ApDungToanTruong).HasDefaultValue(true);
                entity.Property(e => e.DanhSachKhoa).IsRequired(false);
                entity.Property(e => e.DanhSachLop).IsRequired(false);
                entity.Property(e => e.DanhSachNguoiChinhSua).IsRequired(false);
            });

            // FILE_UPLOAD - ĐÃ SỬA: Thêm IsRequired(false) cho các cột có thể null
            modelBuilder.Entity<FileUpload>(entity =>
            {
                entity.HasKey(e => e.MaFile);
                entity.Property(e => e.MaFile).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.TenFile).HasMaxLength(300).IsRequired();
                entity.Property(e => e.DuongDan).HasMaxLength(500).IsRequired();
                entity.Property(e => e.KichThuoc).IsRequired();
                entity.Property(e => e.LoaiFile).HasMaxLength(100).IsRequired(false);
                entity.Property(e => e.NgayUpload).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.MaND).HasMaxLength(10).IsUnicode(false).IsRequired();
            });

            // CAUHOI - ĐÃ SỬA: Thêm IsRequired(false) cho các cột có thể null
            modelBuilder.Entity<CauHoi>(entity =>
            {
                entity.HasKey(e => e.MaCH);
                entity.Property(e => e.MaCH).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.MaKS).HasMaxLength(10).IsUnicode(false).IsRequired();
                entity.Property(e => e.NoiDung).HasMaxLength(500).IsRequired();
                entity.Property(e => e.LoaiCauHoi).HasMaxLength(30).IsRequired();
                entity.Property(e => e.ThuTu).IsRequired();
                entity.Property(e => e.BatBuoc).HasDefaultValue(false);
                entity.Property(e => e.SoLuongChonToiDa).IsRequired(false);
                entity.Property(e => e.GiaTriToiThieu).IsRequired(false);
                entity.Property(e => e.GiaTriToiDa).IsRequired(false);
                entity.Property(e => e.HinhAnhMinhHoa).HasMaxLength(500).IsRequired(false);
                entity.Property(e => e.VideoMinhHoa).HasMaxLength(500).IsRequired(false);
            });

            // LUACHON
            modelBuilder.Entity<LuaChon>(entity =>
            {
                entity.HasKey(e => e.MaLC);
                entity.Property(e => e.MaLC).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.MaCH).HasMaxLength(10).IsUnicode(false).IsRequired();
                entity.Property(e => e.NoiDung).HasMaxLength(300).IsRequired();
                entity.Property(e => e.GiaTri).IsRequired(false);
                entity.Property(e => e.ThuTu).IsRequired();
            });

            // ROW_MATRIX
            modelBuilder.Entity<RowMatrix>(entity =>
            {
                entity.HasKey(e => e.MaRow);
                entity.Property(e => e.MaRow).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.MaCH).HasMaxLength(10).IsUnicode(false).IsRequired();
                entity.Property(e => e.NoiDung).HasMaxLength(300).IsRequired();
                entity.Property(e => e.ThuTu).IsRequired();
            });

            // COL_MATRIX
            modelBuilder.Entity<ColMatrix>(entity =>
            {
                entity.HasKey(e => e.MaCol);
                entity.Property(e => e.MaCol).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.MaCH).HasMaxLength(10).IsUnicode(false).IsRequired();
                entity.Property(e => e.NoiDung).HasMaxLength(300).IsRequired();
                entity.Property(e => e.ThuTu).IsRequired();
            });

            // PHANHOI
            modelBuilder.Entity<PhanHoi>(entity =>
            {
                entity.HasKey(e => e.MaPH);
                entity.Property(e => e.MaPH).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.MaKS).HasMaxLength(10).IsUnicode(false).IsRequired();
                entity.Property(e => e.MaND).HasMaxLength(10).IsUnicode(false).IsRequired();
                entity.Property(e => e.NgayPhanHoi).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.TrangThai).HasMaxLength(20).HasDefaultValue("Hoàn thành");
            });

            // PHANHOI_CHITIET - ĐÃ SỬA: Tất cả cột có thể null đều có IsRequired(false)
            modelBuilder.Entity<PhanHoiChiTiet>(entity =>
            {
                entity.HasKey(e => e.MaPHCT);
                entity.Property(e => e.MaPHCT).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.MaPH).HasMaxLength(10).IsUnicode(false).IsRequired();
                entity.Property(e => e.MaCH).HasMaxLength(10).IsUnicode(false).IsRequired();
                entity.Property(e => e.NoiDungText).HasMaxLength(1000).IsRequired(false);
                entity.Property(e => e.MaLC).HasMaxLength(10).IsUnicode(false).IsRequired(false);
                entity.Property(e => e.DanhSachMaLC).HasMaxLength(500).IsRequired(false);
                entity.Property(e => e.MaRow).HasMaxLength(10).IsUnicode(false).IsRequired(false);
                entity.Property(e => e.MaCol).HasMaxLength(10).IsUnicode(false).IsRequired(false);
                entity.Property(e => e.DanhSachMaTrich).HasMaxLength(1000).IsRequired(false);
                entity.Property(e => e.GiaTriSo).IsRequired(false);
                entity.Property(e => e.GiaTriNgay).HasColumnType("date").IsRequired(false);
                entity.Property(e => e.GiaTriGio).IsRequired(false);
                entity.Property(e => e.GiaTriDateTime).IsRequired(false);
                entity.Property(e => e.MaFile).HasMaxLength(10).IsUnicode(false).IsRequired(false);
            });

            // BAOCAO
            modelBuilder.Entity<BaoCao>(entity =>
            {
                entity.HasKey(e => e.MaBC);
                entity.Property(e => e.MaBC).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.MaKS).HasMaxLength(10).IsUnicode(false).IsRequired();
                entity.Property(e => e.NgayTao).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.TongSoPhanHoi).HasDefaultValue(0);
                entity.Property(e => e.GhiChu).HasMaxLength(300).IsRequired(false);
            });
        }

        private void ConfigureUniqueConstraints(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CauHoi>()
                .HasIndex(e => new { e.MaKS, e.ThuTu })
                .IsUnique();

            modelBuilder.Entity<LuaChon>()
                .HasIndex(e => new { e.MaCH, e.ThuTu })
                .IsUnique();

            modelBuilder.Entity<PhanHoi>()
                .HasIndex(e => new { e.MaKS, e.MaND })
                .IsUnique();

            modelBuilder.Entity<NguoiDung>()
                .HasIndex(e => e.Email)
                .IsUnique();
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            // KHOA -> TRUONG
            modelBuilder.Entity<Khoa>()
                .HasOne<Truong>()
                .WithMany()
                .HasForeignKey(e => e.MaTruong)
                .OnDelete(DeleteBehavior.Restrict);

            // LOPHOC -> KHOA
            modelBuilder.Entity<LopHoc>()
                .HasOne<Khoa>()
                .WithMany()
                .HasForeignKey(e => e.MaKhoa)
                .OnDelete(DeleteBehavior.Restrict);

            // NGUOIDUNG -> LOPHOC & KHOA
            modelBuilder.Entity<NguoiDung>()
                .HasOne<LopHoc>()
                .WithMany()
                .HasForeignKey(e => e.MaLH)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<NguoiDung>()
                .HasOne<Khoa>()
                .WithMany()
                .HasForeignKey(e => e.MaKhoa)
                .OnDelete(DeleteBehavior.SetNull);

            // NHATKY -> NGUOIDUNG
            modelBuilder.Entity<NhatKy>()
                .HasOne<NguoiDung>()
                .WithMany()
                .HasForeignKey(e => e.MaND)
                .OnDelete(DeleteBehavior.Restrict);

            // DANHMUC -> NGUOIDUNG
            modelBuilder.Entity<DanhMuc>()
                .HasOne<NguoiDung>()
                .WithMany()
                .HasForeignKey(e => e.MaNguoiTao)
                .OnDelete(DeleteBehavior.SetNull);

            // TEMPLATE -> NGUOIDUNG
            modelBuilder.Entity<Template>()
                .HasOne<NguoiDung>()
                .WithMany()
                .HasForeignKey(e => e.MaNguoiTao)
                .OnDelete(DeleteBehavior.SetNull);

            // KHAOSAT -> DANHMUC, NGUOIDUNG, TEMPLATE
            modelBuilder.Entity<KhaoSat>()
                .HasOne<DanhMuc>()
                .WithMany()
                .HasForeignKey(e => e.MaDM)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<KhaoSat>()
                .HasOne<NguoiDung>()
                .WithMany()
                .HasForeignKey(e => e.MaNguoiTao)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<KhaoSat>()
                .HasOne<Template>()
                .WithMany()
                .HasForeignKey(e => e.MaTemplate)
                .OnDelete(DeleteBehavior.SetNull);

            // FILE_UPLOAD -> NGUOIDUNG
            modelBuilder.Entity<FileUpload>()
                .HasOne<NguoiDung>()
                .WithMany()
                .HasForeignKey(e => e.MaND)
                .OnDelete(DeleteBehavior.Restrict);

            // CAUHOI -> KHAOSAT
            modelBuilder.Entity<CauHoi>()
                .HasOne<KhaoSat>()
                .WithMany()
                .HasForeignKey(e => e.MaKS)
                .OnDelete(DeleteBehavior.Cascade);

            // LUACHON -> CAUHOI
            modelBuilder.Entity<LuaChon>()
                .HasOne<CauHoi>()
                .WithMany()
                .HasForeignKey(e => e.MaCH)
                .OnDelete(DeleteBehavior.Cascade);

            // ROW_MATRIX -> CAUHOI
            modelBuilder.Entity<RowMatrix>()
                .HasOne<CauHoi>()
                .WithMany()
                .HasForeignKey(e => e.MaCH)
                .OnDelete(DeleteBehavior.Cascade);

            // COL_MATRIX -> CAUHOI
            modelBuilder.Entity<ColMatrix>()
                .HasOne<CauHoi>()
                .WithMany()
                .HasForeignKey(e => e.MaCH)
                .OnDelete(DeleteBehavior.Cascade);

            // PHANHOI -> KHAOSAT & NGUOIDUNG
            modelBuilder.Entity<PhanHoi>()
                .HasOne<KhaoSat>()
                .WithMany()
                .HasForeignKey(e => e.MaKS)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PhanHoi>()
                .HasOne<NguoiDung>()
                .WithMany()
                .HasForeignKey(e => e.MaND)
                .OnDelete(DeleteBehavior.Restrict);

            // PHANHOI_CHITIET -> PHANHOI, CAUHOI, LUACHON, ROW_MATRIX, COL_MATRIX, FILE_UPLOAD
            modelBuilder.Entity<PhanHoiChiTiet>()
                .HasOne<PhanHoi>()
                .WithMany()
                .HasForeignKey(e => e.MaPH)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PhanHoiChiTiet>()
                .HasOne<CauHoi>()
                .WithMany()
                .HasForeignKey(e => e.MaCH)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PhanHoiChiTiet>()
                .HasOne<LuaChon>()
                .WithMany()
                .HasForeignKey(e => e.MaLC)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PhanHoiChiTiet>()
                .HasOne<RowMatrix>()
                .WithMany()
                .HasForeignKey(e => e.MaRow)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PhanHoiChiTiet>()
                .HasOne<ColMatrix>()
                .WithMany()
                .HasForeignKey(e => e.MaCol)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PhanHoiChiTiet>()
                .HasOne<FileUpload>()
                .WithMany()
                .HasForeignKey(e => e.MaFile)
                .OnDelete(DeleteBehavior.SetNull);

            // BAOCAO -> KHAOSAT
            modelBuilder.Entity<BaoCao>()
                .HasOne<KhaoSat>()
                .WithMany()
                .HasForeignKey(e => e.MaKS)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}