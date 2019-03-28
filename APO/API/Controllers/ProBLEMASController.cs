using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Interfaces.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemasController : Controller
    {
        private readonly IProblemasService _context;

        public ProblemasController(IProblemasService context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}