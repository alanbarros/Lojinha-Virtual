using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistemaVendaWebApi.Models;

namespace sistemaVendaWebApi.Controllers
{
    public class VendaController : Controller
    {
        private readonly VendaContext _context;

        public VendaController(VendaContext context)
        {
            _context = context;
        }

        // GET: Venda
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vendas.ToListAsync());
        }

        // GET: Venda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Venda/Create
        public async Task<IActionResult> Create()
        {
            _context.Add(new Venda(null,DateTime.Now,Status.Pendente));
            await _context.SaveChangesAsync();
            var venda = _context.Vendas.Last();

            return RedirectToAction("Edit",venda);
        }

        // POST: Venda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,StatusVenda")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venda);
        }

        // GET: Venda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            return View(venda);
        }

        // POST: Venda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,StatusVenda")] Venda venda)
        {
            if (id != venda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(venda);
        }

        // GET: Venda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Venda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Vendas.FindAsync(id);
            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Vendas.Any(e => e.Id == id);
        }
    }
}
