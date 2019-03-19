using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace IA.inteligencia_artificial.WebAPI.Controllers
{
    public class HomeController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View("index");

        }
    }
}