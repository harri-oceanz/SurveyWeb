using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyWeb.Models.Entity
{
    public class LopHoc
    {
        [Key]
        public string MaLH { get; set; }
        public string TenLH { get; set; }
        public string MaKhoa { get; set; }
    }
}
