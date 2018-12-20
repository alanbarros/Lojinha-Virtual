using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Modelos;
using DAL;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly LojaDbContext _context;

        public UsuariosController(LojaDbContext context)
        {
            _context = context;
        }
        
        // GET api/Usuarios
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_context.Usuarios.ToList());
        }

        // GET api/Usuarios/5
        [HttpGet("{id}")]
        public JsonResult Get(int Id){
            return new JsonResult(_context.Usuarios.FirstOrDefault(usuario => usuario.Id.Equals(Id)));
        }

        // POST
        [HttpPost]
        public void Post(Usuario usuario){
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        //PUT
        [HttpPut("{id}")]
        public ActionResult Update(int id, Usuario usuario)
        {
            var user = _context.Usuarios.Find(id);

            user.Username = usuario.Username;
            user.Password = usuario.Password;

            _context.Usuarios.Update(user);
            _context.SaveChanges();
            return NoContent();
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int Id){
            var u = _context.Usuarios.Find(Id);

            _context.Usuarios.Remove(u);
            _context.SaveChanges();
            return NoContent();
        }

    }
}