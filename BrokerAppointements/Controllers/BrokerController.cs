using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrokerAppointements.Data;
using BrokerAppointements.Models;

namespace BrokerAppointements.Controllers
{
    public class BrokerController : Controller
    {
        private readonly GlobalDataContext _context;

        public BrokerController(GlobalDataContext context)
        {
            _context = context;
        }

        // GET: Broker
        public async Task<IActionResult> Index()
        {
              return _context.brokers != null ? 
                          View(await _context.brokers.ToListAsync()) :
                          Problem("Entity set 'GlobalDataContext.brokers'  is null.");
        }

        // GET: Broker/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.brokers == null)
            {
                return NotFound();
            }

            var broker = await _context.brokers
                .FirstOrDefaultAsync(m => m.BrokerId == id);
            if (broker == null)
            {
                return NotFound();
            }

            return View(broker);
        }

        // GET: Broker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Broker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrokerId,LastName,FirstName,Mail,PhoneNumber")] Broker broker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(broker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(broker);
        }

        // GET: Broker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.brokers == null)
            {
                return NotFound();
            }

            var broker = await _context.brokers.FindAsync(id);
            if (broker == null)
            {
                return NotFound();
            }
            return View(broker);
        }

        // POST: Broker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrokerId,LastName,FirstName,Mail,PhoneNumber")] Broker broker)
        {
            if (id != broker.BrokerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(broker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrokerExists(broker.BrokerId))
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
            return View(broker);
        }

        // GET: Broker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.brokers == null)
            {
                return NotFound();
            }

            var broker = await _context.brokers
                .FirstOrDefaultAsync(m => m.BrokerId == id);
            if (broker == null)
            {
                return NotFound();
            }

            return View(broker);
        }

        // POST: Broker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.brokers == null)
            {
                return Problem("Entity set 'GlobalDataContext.brokers'  is null.");
            }
            var broker = await _context.brokers.FindAsync(id);
            if (broker != null)
            {
                _context.brokers.Remove(broker);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrokerExists(int id)
        {
          return (_context.brokers?.Any(e => e.BrokerId == id)).GetValueOrDefault();
        }
    }
}
