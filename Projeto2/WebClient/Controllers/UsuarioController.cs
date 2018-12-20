using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Repositorio _repositorio;

        public UsuarioController(Repositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<ActionResult> Index(){
            var usuarios = await _repositorio.GetUsuariosAsync();

            return View(usuarios);
        }
        
    }
}