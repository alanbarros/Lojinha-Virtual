using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class ClienteController : Controller
    {
        private readonly Repositorio _repositorio;

        public ClienteController(Repositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<ActionResult> Index(){
            var clientes = await _repositorio.GetClientesAsync();

            return View(clientes);
        }
    }
}