using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyWeb.Models.Entity
{
    public class CauHoi
    {
        [Key]
        public string MaCH { get; set; }
        public string MaKS { get; set; }
        public string NoiDung { get; set; }
        public string LoaiCauHoi { get; set; }
        public int ThuTu { get; set; }
        public bool BatBuoc { get; set; } = false;
        public int? SoLuongChonToiDa { get; set; }
        public int? GiaTriToiThieu { get; set; }
        public int? GiaTriToiDa { get; set; }
        public string HinhAnhMinhHoa { get; set; }
        public string VideoMinhHoa { get; set; }
    }
}
