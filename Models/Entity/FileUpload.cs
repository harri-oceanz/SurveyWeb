using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyWeb.Models.Entity
{
    public class FileUpload
    {
        [Key]
        public string MaFile { get; set; }
        public string TenFile { get; set; }
        public string DuongDan { get; set; }
        public long KichThuoc { get; set; }
        public string LoaiFile { get; set; }
        public DateTime NgayUpload { get; set; } = DateTime.Now;
        public string MaND { get; set; }
    }
}
