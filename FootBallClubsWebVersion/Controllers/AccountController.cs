
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FootBallClubsWebVersion.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}
