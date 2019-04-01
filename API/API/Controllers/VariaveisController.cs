using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Interfaces.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariaveisController : Controller
    {
        private readonly IVariaveisService _context;

        public VariaveisController(IVariaveisService context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("AllProblems")]
        public IEnumerable<Variavel> AllProblems([FromQuery]long id)
        {
            return this._context.AllProblems(id);
        }

        [HttpGet]
        [Route("AllProject")]
        public IEnumerable<Variavel> AllProject([FromQuery]long id)
        {
            return this._context.AllProject(id);
        }

        [HttpPost]
        public void Post([FromBody]Variavel item)
        {
            this._context.Add(item);
        }

        [HttpPut]
        public void Put([FromBody]Variavel item)
        {
            this._context.Update(item);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            this._context.Delete(id);
        }
    }
}