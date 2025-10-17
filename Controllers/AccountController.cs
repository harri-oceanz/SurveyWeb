using Microsoft.AspNetCore.Mvc;
using SurveyWeb.Models.EF;
using Microsoft.EntityFrameworkCore;
using SurveyWeb.Models;
using System.Diagnostics;
using System.Threading.Tasks;
namespace SurveyWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ApplicationDbContext _context;
        public AccountController(ILogger<AccountController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(string username, string password, string newEmail)
        {
            var user = _context.NguoiDung.AsNoTracking().FirstOrDefault(t => t.Email == username);
            // Kiểm tra có tồn tại user không
            if (user == null)
            {
                ViewBag.Error = "Tài khoản này chưa được đăng ký!";
                return View();
            }

            // Kiểm tra mật khẩu
            if (user.MatKhau != password)
            {
                ViewBag.Error = "Mật khẩu không đúng!";
                return View();
            }

            // Nếu đúng thì đăng nhập thành công → chuyển sang trang chủ
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> CheckEmail(string newEmail)
        {
            var existingUser = _context.NguoiDung
                .AsNoTracking()
                .FirstOrDefault(u => u.Email == newEmail);

            if (existingUser != null)
            {
                ViewBag.EmailError = "Email này đã được đăng ký!";
                ViewBag.ShowModal = true; // 🔹 cờ cho biết cần mở modal
                ViewBag.NewEmail = newEmail; // để giữ lại email người dùng đã nhập
                
                return View("SignIn");
            }
            // Nếu chưa tồn tại → sang bước tiếp theo
            return RedirectToAction("RegisterStep2", new { email = newEmail });
        }
        [HttpGet]
        public IActionResult RegisterStep2(string email)
        {
            ViewBag.Email = email;
            return View();
        }
    }
}
