using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyWeb.Models.Entity
{
    public class ColMatrix
    {
        [Key]
        public string MaCol { get; set; }
        public string MaCH { get; set; }
        public string NoiDung { get; set; }
        public int ThuTu { get; set; }
    }
}
