using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelGestionale.Data;
using HotelGestionale.Models;

namespace HotelGestionale.Controllers
{
    public class TipoPensioneController : Controller
    {
        private readonly HotelGestionaleContext _context;

        public TipoPensioneController(HotelGestionaleContext context)
        {
            _context = context;
        }

        // GET: TipoPensione
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoPensione.ToListAsync());
        }

        // GET: TipoPensione/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPensione = await _context.TipoPensione
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoPensione == null)
            {
                return NotFound();
            }

            return View(tipoPensione);
        }

        // GET: TipoPensione/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPensione/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Tipologia,Prezzo")] TipoPensione tipoPensione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPensione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPensione);
        }

        // GET: TipoPensione/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPensione = await _context.TipoPensione.FindAsync(id);
            if (tipoPensione == null)
            {
                return NotFound();
            }
            return View(tipoPensione);
        }

        // POST: TipoPensione/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Tipologia,Prezzo")] TipoPensione tipoPensione)
        {
            if (id != tipoPensione.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPensione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPensioneExists(tipoPensione.ID))
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
            return View(tipoPensione);
        }

        // GET: TipoPensione/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPensione = await _context.TipoPensione
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoPensione == null)
            {
                return NotFound();
            }

            return View(tipoPensione);
        }

        // POST: TipoPensione/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoPensione = await _context.TipoPensione.FindAsync(id);
            if (tipoPensione != null)
            {
                _context.TipoPensione.Remove(tipoPensione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPensioneExists(int id)
        {
            return _context.TipoPensione.Any(e => e.ID == id);
        }
    }
}
