﻿using System;
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
        public async Task<IActionResult> Index(string pesquisa)
        {
            if (pesquisa == null)
            {
                return _context.TotalPagar != null ?
                         View(await _context.TotalPagar.Include(x => x.Cliente)
                               .Include(x => x.Convidado)
                               .Include(x => x.Local)
                               .Include(x => x.Horario)
                               .Include(x => x.Decoracao)
                               .Include(x => x.Buffet)
                               .Include(x => x.TipoEvento).ToListAsync()) :
                         Problem("Entity set 'Contexto.TotalPagar'  is null.");
            }
            else
            {
                var totalpagar = _context.TotalPagar
                               .Include(x => x.Cliente)
                               .Include(x => x.Convidado)
                               .Include(x => x.Local)
                               .Include(x => x.Horario)
                               .Include(x => x.Decoracao)
                               .Include(x => x.Buffet)
                               .Include(x => x.TipoEvento)
                               .Where(x => x.Cliente.ClienteNome.Contains(pesquisa)).ToListAsync();

                return View(totalpagar);
            }
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
                .Include(t => t.Convidado)
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
            ViewData["BuffetId"] = new SelectList(_context.Buffet, "Id", "Id");
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id");
            ViewData["ConvidadoId"] = new SelectList(_context.Convidado, "Id", "Id");
            ViewData["DecoracaoId"] = new SelectList(_context.Decoracao, "Id", "Id");
            ViewData["HorarioId"] = new SelectList(_context.Horario, "Id", "Id");
            ViewData["LocalId"] = new SelectList(_context.Local, "Id", "Id");
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEvento, "Id", "Id");
            return View();
        }

        // POST: TotalPagar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,ConvidadoId,LocalId,HorarioId,DecoracaoId,BuffetId,TipoEventoId,TotalValor")] TotalPagar totalPagar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(totalPagar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuffetId"] = new SelectList(_context.Buffet, "Id", "Id", totalPagar.BuffetId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", totalPagar.ClienteId);
            ViewData["ConvidadoId"] = new SelectList(_context.Convidado, "Id", "Id", totalPagar.ConvidadoId);
            ViewData["DecoracaoId"] = new SelectList(_context.Decoracao, "Id", "Id", totalPagar.DecoracaoId);
            ViewData["HorarioId"] = new SelectList(_context.Horario, "Id", "Id", totalPagar.HorarioId);
            ViewData["LocalId"] = new SelectList(_context.Local, "Id", "Id", totalPagar.LocalId);
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEvento, "Id", "Id", totalPagar.TipoEventoId);
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
            ViewData["BuffetId"] = new SelectList(_context.Buffet, "Id", "Id", totalPagar.BuffetId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", totalPagar.ClienteId);
            ViewData["ConvidadoId"] = new SelectList(_context.Convidado, "Id", "Id", totalPagar.ConvidadoId);
            ViewData["DecoracaoId"] = new SelectList(_context.Decoracao, "Id", "Id", totalPagar.DecoracaoId);
            ViewData["HorarioId"] = new SelectList(_context.Horario, "Id", "Id", totalPagar.HorarioId);
            ViewData["LocalId"] = new SelectList(_context.Local, "Id", "Id", totalPagar.LocalId);
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEvento, "Id", "Id", totalPagar.TipoEventoId);
            return View(totalPagar);
        }

        // POST: TotalPagar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,ConvidadoId,LocalId,HorarioId,DecoracaoId,BuffetId,TipoEventoId,TotalValor")] TotalPagar totalPagar)
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
            ViewData["BuffetId"] = new SelectList(_context.Buffet, "Id", "Id", totalPagar.BuffetId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", totalPagar.ClienteId);
            ViewData["ConvidadoId"] = new SelectList(_context.Convidado, "Id", "Id", totalPagar.ConvidadoId);
            ViewData["DecoracaoId"] = new SelectList(_context.Decoracao, "Id", "Id", totalPagar.DecoracaoId);
            ViewData["HorarioId"] = new SelectList(_context.Horario, "Id", "Id", totalPagar.HorarioId);
            ViewData["LocalId"] = new SelectList(_context.Local, "Id", "Id", totalPagar.LocalId);
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEvento, "Id", "Id", totalPagar.TipoEventoId);
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
                .Include(t => t.Convidado)
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
