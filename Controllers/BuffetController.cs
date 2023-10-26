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
    public class BuffetController : Controller
    {
        private readonly Contexto _context;

        public BuffetController(Contexto context)
        {
            _context = context;
        }

        // GET: Buffet
        public async Task<IActionResult> Index()
        {
              return _context.Buffet != null ? 
                          View(await _context.Buffet.ToListAsync()) :
                          Problem("Entity set 'Contexto.Buffet'  is null.");
        }

        // GET: Buffet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Buffet == null)
            {
                return NotFound();
            }

            var buffet = await _context.Buffet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buffet == null)
            {
                return NotFound();
            }

            return View(buffet);
        }

        // GET: Buffet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buffet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BuffetTipo")] Buffet buffet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buffet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buffet);
        }

        // GET: Buffet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Buffet == null)
            {
                return NotFound();
            }

            var buffet = await _context.Buffet.FindAsync(id);
            if (buffet == null)
            {
                return NotFound();
            }
            return View(buffet);
        }

        // POST: Buffet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BuffetTipo")] Buffet buffet)
        {
            if (id != buffet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buffet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuffetExists(buffet.Id))
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
            return View(buffet);
        }

        // GET: Buffet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Buffet == null)
            {
                return NotFound();
            }

            var buffet = await _context.Buffet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buffet == null)
            {
                return NotFound();
            }

            return View(buffet);
        }

        // POST: Buffet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Buffet == null)
            {
                return Problem("Entity set 'Contexto.Buffet'  is null.");
            }
            var buffet = await _context.Buffet.FindAsync(id);
            if (buffet != null)
            {
                _context.Buffet.Remove(buffet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuffetExists(int id)
        {
          return (_context.Buffet?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
