using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyWeb.Models.Entity
{
    public class PhanHoi
    {
        [Key]
        public string MaPH { get; set; }
        public string MaKS { get; set; }
        public string MaND { get; set; }
        public DateTime NgayPhanHoi { get; set; } = DateTime.Now;
        public string TrangThai { get; set; } = "Hoàn thành";
    }
}
