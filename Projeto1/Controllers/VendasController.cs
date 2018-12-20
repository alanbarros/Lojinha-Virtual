using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistemaVendaWebApi.Models;

namespace sistemaVendaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly VendaContext _context;        

        public VendasController(VendaContext context)
        {
            _context = context;
        }

        // GET api/values
        // [HttpGet]
        // public ActionResult<IEnumerable<Venda>> Get(string Pesquisa)
        // {
            
        //     var q = _context.Vendas.AsQueryable();
        //     if(!string.IsNullOrEmpty(Pesquisa))
        //         q = q.Where(c => c.Nome.Contains(Pesquisa));
        //     q = q.OrderBy(c => c.Nome);

        //     return q.ToArray();
        // }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
