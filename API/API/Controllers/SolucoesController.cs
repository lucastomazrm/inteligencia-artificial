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
    public class SolucoesController : Controller
    {
        private readonly ISolucaoService _context;

        public SolucoesController(ISolucaoService context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}