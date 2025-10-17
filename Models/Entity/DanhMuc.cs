using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyWeb.Models.Entity
{
    public class DanhMuc
    {
        [Key]
        public string MaDM { get; set; }
        public string TenDM { get; set; }
        public string MoTa { get; set; }
        public string MaNguoiTao { get; set; }
    }
}
