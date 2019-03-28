using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IA.inteligencia_artificial.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Interfaces.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : Controller
    {
        private readonly IProjetosService _context;

        public ProjetosController(IProjetosService context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}