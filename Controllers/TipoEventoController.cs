using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoEventos.Models;

namespace ProjetoEventos.Controllers
{
    public class TipoEventoController : Controller
    {
        private readonly Contexto _context;

        public TipoEventoController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoEvento
        public async Task<IActionResult> Index()
        {
              return _context.TipoEvento != null ? 
                          View(await _context.TipoEvento.ToListAsync()) :
                          Problem("Entity set 'Contexto.TipoEvento'  is null.");
        }

        // GET: TipoEvento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoEvento == null)
            {
                return NotFound();
            }

            var tipoEvento = await _context.TipoEvento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEvento == null)
            {
                return NotFound();
            }

            return View(tipoEvento);
        }

        // GET: TipoEvento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEvento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventoTipo")] TipoEvento tipoEvento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEvento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEvento);
        }

        // GET: TipoEvento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoEvento == null)
            {
                return NotFound();
            }

            var tipoEvento = await _context.TipoEvento.FindAsync(id);
            if (tipoEvento == null)
            {
                return NotFound();
            }
            return View(tipoEvento);
        }

        // POST: TipoEvento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventoTipo")] TipoEvento tipoEvento)
        {
            if (id != tipoEvento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEvento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEventoExists(tipoEvento.Id))
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
            return View(tipoEvento);
        }

        // GET: TipoEvento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoEvento == null)
            {
                return NotFound();
            }

            var tipoEvento = await _context.TipoEvento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEvento == null)
            {
                return NotFound();
            }

            return View(tipoEvento);
        }

        // POST: TipoEvento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoEvento == null)
            {
                return Problem("Entity set 'Contexto.TipoEvento'  is null.");
            }
            var tipoEvento = await _context.TipoEvento.FindAsync(id);
            if (tipoEvento != null)
            {
                _context.TipoEvento.Remove(tipoEvento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEventoExists(int id)
        {
          return (_context.TipoEvento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
