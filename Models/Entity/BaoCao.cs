using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyWeb.Models.Entity
{
    public class BaoCao
    {
        [Key]
        public string MaBC { get; set; }
        public string MaKS { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now;
        public int TongSoPhanHoi { get; set; } = 0;
        public string GhiChu { get; set; }
    }
}
