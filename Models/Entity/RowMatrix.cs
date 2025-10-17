using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyWeb.Models.Entity
{
    public class RowMatrix
    {
        [Key]
        public string MaRow { get; set; }
        public string MaCH { get; set; }
        public string NoiDung { get; set; }
        public int ThuTu { get; set; }
    }
}
