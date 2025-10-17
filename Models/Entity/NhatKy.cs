using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyWeb.Models.Entity
{
    public class NhatKy
    {
        [Key]
        public int MaNK { get; set; }
        public string MaND { get; set; }
        public string HanhDong { get; set; }
        public DateTime ThoiGian { get; set; } = DateTime.Now;
        public string MoTa { get; set; }
        public string LoaiHanhDong { get; set; }
    }
}
