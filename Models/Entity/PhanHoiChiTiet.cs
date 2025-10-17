using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyWeb.Models.Entity
{
    public class PhanHoiChiTiet
    {
        [Key]
        public string MaPHCT { get; set; }
        public string MaPH { get; set; }
        public string MaCH { get; set; }
        public string NoiDungText { get; set; }
        public string MaLC { get; set; }
        public string DanhSachMaLC { get; set; }
        public string MaRow { get; set; }
        public string MaCol { get; set; }
        public string DanhSachMaTrich { get; set; }
        public int? GiaTriSo { get; set; }
        public DateTime? GiaTriNgay { get; set; }
        public TimeSpan? GiaTriGio { get; set; }
        public DateTime? GiaTriDateTime { get; set; }
        public string MaFile { get; set; }
    }
}
