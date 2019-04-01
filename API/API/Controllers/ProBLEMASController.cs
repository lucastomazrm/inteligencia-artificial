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

        [HttpGet("{id}")]
        public Problema Get(int id)
        {
            return this._context.Get(id);
        }
        [HttpGet]
        [Route("Projeto")]
        public IEnumerable<Problema> All(int id)
        {
            return this._context.All(id);
        }

        [HttpGet]
        [Route("AddVariaveis")]
        public void AddVariaveis([FromQuery]long idProblema, IEnumerable<long> idVariaveis)
        {
            this._context.AddVariaies(idProblema, idVariaveis);
        }

        [HttpPost]
        public void Post([FromBody]Problema item)
        {
            this._context.Add(item);
        }

        [HttpPut]
        public void Put([FromBody]Problema item)
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