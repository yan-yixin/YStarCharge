using Microsoft.AspNetCore.Mvc;
using YStarCharge.Web.Models;

namespace YStarCharge.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            UserAccount userAccount = new UserAccount()
            {
                Id = 1,
                Username = "admin",
                Password = "admin",
                Icon = "./images/user.png"
            };
            return View(userAccount);
        }

        public IActionResult RemeberPassword() 
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
