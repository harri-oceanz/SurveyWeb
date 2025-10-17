using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyWeb.Models.Entity
{
    public class KhaoSat
    {
        [Key]
        public string MaKS { get; set; }
        public string TenKS { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string TrangThai { get; set; } = "Đang hoạt động";
        public string MaDM { get; set; }
        public string MaNguoiTao { get; set; }
        public string MaTemplate { get; set; }
        public bool ApDungToanTruong { get; set; } = true;
        public string DanhSachKhoa { get; set; }
        public string DanhSachLop { get; set; }
        public string DanhSachNguoiChinhSua { get; set; }
    }
}
