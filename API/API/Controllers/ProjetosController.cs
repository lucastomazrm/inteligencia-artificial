using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IA.inteligencia_artificial.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
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

        [HttpGet("{id}")]
        public Projeto Get(int id)
        {
            return this._context.Get(id);
        }
        [HttpGet]
        public IEnumerable<Projeto> All()
        {
            return this._context.All();
        }


        [HttpPost]
        public void Post([FromBody]Projeto item)
        {
            this._context.Add(item);
        }

        [HttpPut]
        public void Put([FromBody]Projeto item)
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