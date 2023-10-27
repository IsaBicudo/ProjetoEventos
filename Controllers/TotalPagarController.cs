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
    public class TotalPagarController : Controller
    {
        private readonly Contexto _context;

        public TotalPagarController(Contexto context)
        {
            _context = context;
        }

        // GET: TotalPagar
        public async Task<IActionResult> Index()
        {
            var contexto = _context.TotalPagar.Include(t => t.Buffet).Include(t => t.Cliente).Include(t => t.Decoracao).Include(t => t.Horario).Include(t => t.Local).Include(t => t.TipoEvento);
            return View(await contexto.ToListAsync());
        }

        // GET: TotalPagar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TotalPagar == null)
            {
                return NotFound();
            }

            var totalPagar = await _context.TotalPagar
                .Include(t => t.Buffet)
                .Include(t => t.Cliente)
                .Include(t => t.Decoracao)
                .Include(t => t.Horario)
                .Include(t => t.Local)
                .Include(t => t.TipoEvento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (totalPagar == null)
            {
                return NotFound();
            }

            return View(totalPagar);
        }

        // GET: TotalPagar/Create
        public IActionResult Create()
        {
            ViewData["BuffetId"] = new SelectList(_context.Buffet, "Id", "BuffetTipo");
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "ClienteNome");
            ViewData["DecoracaoId"] = new SelectList(_context.Decoracao, "Id", "DecoracaoTipo");
            ViewData["HorarioId"] = new SelectList(_context.Horario, "Id", "HorarioEvento");
            ViewData["LocalId"] = new SelectList(_context.Local, "Id", "LocalNome");
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEvento, "Id", "EventoTipo");
            return View();
        }

        // POST: TotalPagar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,QuantidadeConvidados,LocalId,HorarioId,DecoracaoId,BuffetId,TipoEventoId,TotalValor")] TotalPagar totalPagar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(totalPagar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuffetId"] = new SelectList(_context.Buffet, "Id", "BuffetTipo", totalPagar.BuffetId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "ClienteNome", totalPagar.ClienteId);
            ViewData["DecoracaoId"] = new SelectList(_context.Decoracao, "Id", "DecoracaoTipo", totalPagar.DecoracaoId);
            ViewData["HorarioId"] = new SelectList(_context.Horario, "Id", "HorarioEvento", totalPagar.HorarioId);
            ViewData["LocalId"] = new SelectList(_context.Local, "Id", "LocalNome", totalPagar.LocalId);
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEvento, "Id", "EventoTipo", totalPagar.TipoEventoId);
            return View(totalPagar);
        }

        // GET: TotalPagar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TotalPagar == null)
            {
                return NotFound();
            }

            var totalPagar = await _context.TotalPagar.FindAsync(id);
            if (totalPagar == null)
            {
                return NotFound();
            }
            ViewData["BuffetId"] = new SelectList(_context.Buffet, "Id", "BuffetTipo", totalPagar.BuffetId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "ClienteNome", totalPagar.ClienteId);
            ViewData["DecoracaoId"] = new SelectList(_context.Decoracao, "Id", "DecoracaoTipo", totalPagar.DecoracaoId);
            ViewData["HorarioId"] = new SelectList(_context.Horario, "Id", "HorarioEvento", totalPagar.HorarioId);
            ViewData["LocalId"] = new SelectList(_context.Local, "Id", "LocalNome", totalPagar.LocalId);
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEvento, "Id", "EventoTipo", totalPagar.TipoEventoId);
            return View(totalPagar);
        }

        // POST: TotalPagar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,QuantidadeConvidados,LocalId,HorarioId,DecoracaoId,BuffetId,TipoEventoId,TotalValor")] TotalPagar totalPagar)
        {
            if (id != totalPagar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(totalPagar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TotalPagarExists(totalPagar.Id))
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
            ViewData["BuffetId"] = new SelectList(_context.Buffet, "Id", "BuffetTipo", totalPagar.BuffetId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "ClienteNome", totalPagar.ClienteId);
            ViewData["DecoracaoId"] = new SelectList(_context.Decoracao, "Id", "DecoracaoTipo", totalPagar.DecoracaoId);
            ViewData["HorarioId"] = new SelectList(_context.Horario, "Id", "HorarioEvento", totalPagar.HorarioId);
            ViewData["LocalId"] = new SelectList(_context.Local, "Id", "LocalNome", totalPagar.LocalId);
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEvento, "Id", "EventoTipo", totalPagar.TipoEventoId);
            return View(totalPagar);
        }

        // GET: TotalPagar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TotalPagar == null)
            {
                return NotFound();
            }

            var totalPagar = await _context.TotalPagar
                .Include(t => t.Buffet)
                .Include(t => t.Cliente)
                .Include(t => t.Decoracao)
                .Include(t => t.Horario)
                .Include(t => t.Local)
                .Include(t => t.TipoEvento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (totalPagar == null)
            {
                return NotFound();
            }

            return View(totalPagar);
        }

        // POST: TotalPagar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TotalPagar == null)
            {
                return Problem("Entity set 'Contexto.TotalPagar'  is null.");
            }
            var totalPagar = await _context.TotalPagar.FindAsync(id);
            if (totalPagar != null)
            {
                _context.TotalPagar.Remove(totalPagar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TotalPagarExists(int id)
        {
          return (_context.TotalPagar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
