using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelGestionale.Data;
using HotelGestionale.Models;
using Microsoft.AspNetCore.Authorization;

namespace HotelGestionale.Controllers
{
    [Authorize]
    public class PrenotazioniController : Controller
    {
        private readonly HotelGestionaleContext _context;

        public PrenotazioniController(HotelGestionaleContext context)
        {
            _context = context;
        }

        // GET: Prenotazioni
        public async Task<IActionResult> Index()
        {
            var hotelGestionaleContext = _context.Prenotazioni.Include(p => p.Camera).Include(p => p.Cliente).Include(p => p.TipoPensione);
            return View(await hotelGestionaleContext.ToListAsync());
        }

        // GET: Prenotazioni/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazioni = await _context.Prenotazioni
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.TipoPensione)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prenotazioni == null)
            {
                return NotFound();
            }

            return View(prenotazioni);
        }

        // GET: Prenotazioni/Create
        public IActionResult Create()
        {
            ViewData["IDCamera"] = new SelectList(_context.Camere, "ID", "ID");
            ViewData["IDCliente"] = new SelectList(_context.Clienti, "Id", "Cognome");
            ViewData["IDTipoPensione"] = new SelectList(_context.TipoPensione, "ID", "Tipologia");
            return View();
        }

        // POST: Prenotazioni/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DataPrenotazione,DataInizioSoggiorno,DataFineSoggiorno,Anno,Acconto,Prezzo,IDCliente,IDCamera,IDTipoPensione")] Prenotazioni prenotazioni)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prenotazioni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDCamera"] = new SelectList(_context.Camere, "ID", "ID", prenotazioni.IDCamera);
            ViewData["IDCliente"] = new SelectList(_context.Clienti, "Id", "Cognome", prenotazioni.IDCliente);
            ViewData["IDTipoPensione"] = new SelectList(_context.TipoPensione, "ID", "Tipologia", prenotazioni.IDTipoPensione);
            return View(prenotazioni);
        }

        // GET: Prenotazioni/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazioni = await _context.Prenotazioni.FindAsync(id);
            if (prenotazioni == null)
            {
                return NotFound();
            }
            ViewData["IDCamera"] = new SelectList(_context.Camere, "ID", "ID", prenotazioni.IDCamera);
            ViewData["IDCliente"] = new SelectList(_context.Clienti, "Id", "Cognome", prenotazioni.IDCliente);
            ViewData["IDTipoPensione"] = new SelectList(_context.TipoPensione, "ID", "Tipologia", prenotazioni.IDTipoPensione);
            return View(prenotazioni);
        }

        // POST: Prenotazioni/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DataPrenotazione,DataInizioSoggiorno,DataFineSoggiorno,Anno,Acconto,Prezzo,IDCliente,IDCamera,IDTipoPensione")] Prenotazioni prenotazioni)
        {
            if (id != prenotazioni.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prenotazioni);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrenotazioniExists(prenotazioni.ID))
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
            ViewData["IDCamera"] = new SelectList(_context.Camere, "ID", "ID", prenotazioni.IDCamera);
            ViewData["IDCliente"] = new SelectList(_context.Clienti, "Id", "Cognome", prenotazioni.IDCliente);
            ViewData["IDTipoPensione"] = new SelectList(_context.TipoPensione, "ID", "Tipologia", prenotazioni.IDTipoPensione);
            return View(prenotazioni);
        }

        // GET: Prenotazioni/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazioni = await _context.Prenotazioni
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.TipoPensione)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prenotazioni == null)
            {
                return NotFound();
            }

            return View(prenotazioni);
        }

        // POST: Prenotazioni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prenotazioni = await _context.Prenotazioni.FindAsync(id);
            if (prenotazioni != null)
            {
                _context.Prenotazioni.Remove(prenotazioni);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrenotazioniExists(int id)
        {
            return _context.Prenotazioni.Any(e => e.ID == id);
        }

        [HttpGet]
        public async Task<IActionResult> TrovaPrenotazioni(string codiceFiscale)
        {
            if (string.IsNullOrEmpty(codiceFiscale))
            {
                return BadRequest("Il codice fiscale è obbligatorio");
            }

            var cliente = await _context.Clienti.FirstOrDefaultAsync(c => c.CodiceFiscale == codiceFiscale);

            if (cliente == null)
            {
                TempData["Error"] = "Cliente non trovato";
                return RedirectToAction("Index");
            }

            var prenotazioni = await _context.Prenotazioni
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.TipoPensione)
                .Where(p => p.IDCliente == cliente.Id)
                .ToListAsync();

            return View(prenotazioni);
        }

        //restituisce il numero di prenotazioni con pensione completa

        [HttpGet]
        public async Task<IActionResult> PensioneCompleta()
        {
            var pensioneCompleta = await _context.TipoPensione.FirstOrDefaultAsync(p => p.Tipologia == "pensione completa");

            if (pensioneCompleta == null)
            {
                TempData["pensione"] = "Nessuna pensione completa trovata";
                return RedirectToAction("Index");
            }

            var totalPrenotazioni = await _context.Prenotazioni
                .Where(p => p.IDTipoPensione == pensioneCompleta.ID)
                .CountAsync();

            TempData["pensione"] = "Prenotazioni con pensione completa: " +totalPrenotazioni;
            return RedirectToAction("Index");
        }

        // medoto per effettuare il checkout di una prenotazione
        public async Task<IActionResult> Checkout(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazione = await _context.Prenotazioni
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.TipoPensione)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            var servizi = await _context.Servizi
                .Where(s => s.IDPrenotazione == id)
                .ToListAsync();


            var model = new Checkout
            {
                Prenotazione = prenotazione,
                Servizi = servizi
            };

            return View(model);
        }
    }
}
