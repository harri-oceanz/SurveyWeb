using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyWeb.Models.Entity
{
    public class NguoiDung
    {
        [Key]
        public string MaND { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string MaLH { get; set; }
        public string MaKhoa { get; set; }
        public string VaiTro { get; set; }
        public string TrangThai { get; set; } = "Hoạt động";
    }
}
