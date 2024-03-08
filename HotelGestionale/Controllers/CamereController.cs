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
    public class CamereController : Controller
    {
        private readonly HotelGestionaleContext _context;

        public CamereController(HotelGestionaleContext context)
        {
            _context = context;
        }

        // GET: Camere
        public async Task<IActionResult> Index()
        {
            return View(await _context.Camere.ToListAsync());
        }

        // GET: Camere/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camere = await _context.Camere
                .FirstOrDefaultAsync(m => m.ID == id);
            if (camere == null)
            {
                return NotFound();
            }

            return View(camere);
        }

        // GET: Camere/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Camere/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Numero,Descrizione,Doppia,Disponibilita")] Camere camere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(camere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(camere);
        }

        // GET: Camere/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camere = await _context.Camere.FindAsync(id);
            if (camere == null)
            {
                return NotFound();
            }
            return View(camere);
        }

        // POST: Camere/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Numero,Descrizione,Doppia,Disponibilita")] Camere camere)
        {
            if (id != camere.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CamereExists(camere.ID))
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
            return View(camere);
        }

        // GET: Camere/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camere = await _context.Camere
                .FirstOrDefaultAsync(m => m.ID == id);
            if (camere == null)
            {
                return NotFound();
            }

            return View(camere);
        }

        // POST: Camere/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var camere = await _context.Camere.FindAsync(id);
            if (camere != null)
            {
                _context.Camere.Remove(camere);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CamereExists(int id)
        {
            return _context.Camere.Any(e => e.ID == id);
        }
    }
}
