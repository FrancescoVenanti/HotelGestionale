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
    public class ServiziController : Controller
    {
        private readonly HotelGestionaleContext _context;

        public ServiziController(HotelGestionaleContext context)
        {
            _context = context;
        }

        // GET: Servizi
        public async Task<IActionResult> Index()
        {
            var hotelGestionaleContext = _context.Servizi.Include(s => s.Prenotazione);
            return View(await hotelGestionaleContext.ToListAsync());
        }

        // GET: Servizi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servizi = await _context.Servizi
                .Include(s => s.Prenotazione)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (servizi == null)
            {
                return NotFound();
            }

            return View(servizi);
        }

        // GET: Servizi/Create
        public IActionResult Create()
        {
            ViewData["IDPrenotazione"] = new SelectList(_context.Prenotazioni, "ID", "ID");
            return View();
        }

        // POST: Servizi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descrizione,Prezzo,DataServizio,IDPrenotazione")] Servizi servizi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servizi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDPrenotazione"] = new SelectList(_context.Prenotazioni, "ID", "ID", servizi.IDPrenotazione);
            return View(servizi);
        }

        // GET: Servizi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servizi = await _context.Servizi.FindAsync(id);
            if (servizi == null)
            {
                return NotFound();
            }
            ViewData["IDPrenotazione"] = new SelectList(_context.Prenotazioni, "ID", "ID", servizi.IDPrenotazione);
            return View(servizi);
        }

        // POST: Servizi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descrizione,Prezzo,DataServizio,IDPrenotazione")] Servizi servizi)
        {
            if (id != servizi.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servizi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiziExists(servizi.ID))
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
            ViewData["IDPrenotazione"] = new SelectList(_context.Prenotazioni, "ID", "ID", servizi.IDPrenotazione);
            return View(servizi);
        }

        // GET: Servizi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servizi = await _context.Servizi
                .Include(s => s.Prenotazione)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (servizi == null)
            {
                return NotFound();
            }

            return View(servizi);
        }

        // POST: Servizi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servizi = await _context.Servizi.FindAsync(id);
            if (servizi != null)
            {
                _context.Servizi.Remove(servizi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiziExists(int id)
        {
            return _context.Servizi.Any(e => e.ID == id);
        }
    }
}
