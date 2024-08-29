using Microsoft.AspNetCore.Mvc;
using YStarCharge.Web.Models;

namespace YStarCharge.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            Login userAccount = new Login()
            {
                Id = 1,
                Username = "admin",
                Password = "admin",
                Icon = "./images/user.png"
            };
            return View(userAccount);
        }

        public IActionResult ForgetPassword() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register()
        {
            return View();
        }



    }
}
