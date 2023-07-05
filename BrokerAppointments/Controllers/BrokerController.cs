using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrokerAppointments.Data;
using BrokerAppointments.Models;

namespace BrokerAppointments.Controllers
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
            if (_context.Brokers == null)
                return Problem("Entity set 'GlobalDataContext.customers'  is null.");

            return View(await _context.Brokers.FromSql($"select * from brokers order by LastName;").ToListAsync());
        }

        // GET: Broker/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Brokers == null)
            {
                return NotFound();
            }

            var brokerModel = await _context.Brokers
                .FirstOrDefaultAsync(m => m.BrokerId == id);
            if (brokerModel == null)
            {
                return NotFound();
            }

            return View(brokerModel);
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
        public async Task<IActionResult> Create([Bind("BrokerId,LastName,FirstName,Mail,PhoneNumber")] BrokerModel brokerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brokerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brokerModel);
        }

        // GET: Broker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Brokers == null)
            {
                return NotFound();
            }

            var brokerModel = await _context.Brokers.FindAsync(id);
            if (brokerModel == null)
            {
                return NotFound();
            }
            return View(brokerModel);
        }

        // POST: Broker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrokerId,LastName,FirstName,Mail,PhoneNumber")] BrokerModel brokerModel)
        {
            if (id != brokerModel.BrokerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brokerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrokerModelExists(brokerModel.BrokerId))
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
            return View(brokerModel);
        }

        // GET: Broker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Brokers == null)
            {
                return NotFound();
            }

            var brokerModel = await _context.Brokers
                .FirstOrDefaultAsync(m => m.BrokerId == id);
            if (brokerModel == null)
            {
                return NotFound();
            }

            return View(brokerModel);
        }

        // POST: Broker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Brokers == null)
            {
                return Problem("Entity set 'GlobalDataContext.Brokers'  is null.");
            }
            var brokerModel = await _context.Brokers.FindAsync(id);
            if (brokerModel != null)
            {
                _context.Brokers.Remove(brokerModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrokerModelExists(int id)
        {
          return (_context.Brokers?.Any(e => e.BrokerId == id)).GetValueOrDefault();
        }
    }
}
