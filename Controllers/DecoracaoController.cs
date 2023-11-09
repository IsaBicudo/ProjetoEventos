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
    public class DecoracaoController : Controller
    {
        private readonly Contexto _context;

        public DecoracaoController(Contexto context)
        {
            _context = context;
        }

        // GET: Decoracao
        public async Task<IActionResult> Index()
        {
              return _context.Decoracao != null ? 
                          View(await _context.Decoracao.ToListAsync()) :
                          Problem("Entity set 'Contexto.Decoracao'  is null.");
        }

        // GET: Decoracao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Decoracao == null)
            {
                return NotFound();
            }

            var decoracao = await _context.Decoracao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (decoracao == null)
            {
                return NotFound();
            }

            return View(decoracao);
        }

        // GET: Decoracao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Decoracao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DecoracaoTipo,ImagemDecoracao1,ImagemDecoracao2,ImagemDecoracao3")] Decoracao decoracao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(decoracao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(decoracao);
        }

        // GET: Decoracao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Decoracao == null)
            {
                return NotFound();
            }

            var decoracao = await _context.Decoracao.FindAsync(id);
            if (decoracao == null)
            {
                return NotFound();
            }
            return View(decoracao);
        }

        // POST: Decoracao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DecoracaoTipo,ImagemDecoracao1,ImagemDecoracao2,ImagemDecoracao3")] Decoracao decoracao)
        {
            if (id != decoracao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(decoracao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DecoracaoExists(decoracao.Id))
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
            return View(decoracao);
        }

        // GET: Decoracao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Decoracao == null)
            {
                return NotFound();
            }

            var decoracao = await _context.Decoracao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (decoracao == null)
            {
                return NotFound();
            }

            return View(decoracao);
        }

        // POST: Decoracao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Decoracao == null)
            {
                return Problem("Entity set 'Contexto.Decoracao'  is null.");
            }
            var decoracao = await _context.Decoracao.FindAsync(id);
            if (decoracao != null)
            {
                _context.Decoracao.Remove(decoracao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DecoracaoExists(int id)
        {
          return (_context.Decoracao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
