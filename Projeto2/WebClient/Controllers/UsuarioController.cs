using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Modelos;
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

        public async Task<ActionResult> Details(int? id){
            if (id == null) return NotFound();
            var usuario = await _repositorio.GetUsuarioAsync((long) id);
            if (usuario.Username == null) return NotFound(); 
            return View(usuario);
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password")] Usuario usuario)
        {
            if (ModelState.IsValid){
                var criacao = await _repositorio.PostUsuarioAsync(usuario);
                if (criacao) return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _repositorio.GetUsuarioAsync((long) id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var edicao = await _repositorio.PostUsuarioAsync((long)id,usuario);                
                if (edicao) return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _repositorio.GetUsuarioAsync((long)id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repositorio.DeleteUsuarioAsync((long)id);
            return RedirectToAction(nameof(Index));
        }        
    }
}