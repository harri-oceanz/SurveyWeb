using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyWeb.Models.Entity
{
    public class Khoa
    {
        [Key]
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public string MaTruong { get; set; }
    }
}
