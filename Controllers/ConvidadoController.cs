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
    public class ConvidadoController : Controller
    {
        private readonly Contexto _context;

        public ConvidadoController(Contexto context)
        {
            _context = context;
        }

        // GET: Convidado
        public async Task<IActionResult> Index()
        {
              return _context.Convidado != null ? 
                          View(await _context.Convidado.ToListAsync()) :
                          Problem("Entity set 'Contexto.Convidado'  is null.");
        }

        // GET: Convidado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Convidado == null)
            {
                return NotFound();
            }

            var convidado = await _context.Convidado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (convidado == null)
            {
                return NotFound();
            }

            return View(convidado);
        }

        // GET: Convidado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Convidado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConvidadoTotal")] Convidado convidado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(convidado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(convidado);
        }

        // GET: Convidado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Convidado == null)
            {
                return NotFound();
            }

            var convidado = await _context.Convidado.FindAsync(id);
            if (convidado == null)
            {
                return NotFound();
            }
            return View(convidado);
        }

        // POST: Convidado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConvidadoTotal")] Convidado convidado)
        {
            if (id != convidado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(convidado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConvidadoExists(convidado.Id))
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
            return View(convidado);
        }

        // GET: Convidado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Convidado == null)
            {
                return NotFound();
            }

            var convidado = await _context.Convidado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (convidado == null)
            {
                return NotFound();
            }

            return View(convidado);
        }

        // POST: Convidado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Convidado == null)
            {
                return Problem("Entity set 'Contexto.Convidado'  is null.");
            }
            var convidado = await _context.Convidado.FindAsync(id);
            if (convidado != null)
            {
                _context.Convidado.Remove(convidado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConvidadoExists(int id)
        {
          return (_context.Convidado?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
