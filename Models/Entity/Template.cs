using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyWeb.Models.Entity
{
    public class Template
    {
        [Key]
        public string MaTemplate { get; set; }
        public string TenTemplate { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now;
        public string MaNguoiTao { get; set; }
        public string BackgroundColor { get; set; } = "#FFFFFF";
        public string BackgroundImage { get; set; }
        public string FontFamily { get; set; } = "Arial, sans-serif";
        public string QuestionColor { get; set; } = "#000000";
        public int QuestionFontSize { get; set; } = 18;
        public string AnswerColor { get; set; } = "#333333";
        public string AnswerBackgroundColor { get; set; } = "#FFFFFF";
        public int AnswerBorderRadius { get; set; } = 8;
        public string ButtonColor { get; set; } = "#4A90E2";
        public string ButtonTextColor { get; set; } = "#FFFFFF";
        public int ButtonBorderRadius { get; set; } = 25;
    }
}
