using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrokerAppointements.Data;
using BrokerAppointements.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace BrokerAppointements.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly GlobalDataContext _context;

        public AppointmentController(GlobalDataContext context)
        {
            _context = context;
        }

        // GET: Appointment
        public async Task<IActionResult> Index()
        {
            if (_context.appointment == null)
                return Problem("Entity set 'GlobalDataContext.appointment'  is null.");

            /*
             select a.DateHour,
                   a.Subject,
                   b.LastName + ' ' + b.LastName as 'Broker',
                   c.LastName + ' ' + c.LastName as 'Customer'
            from appointements a
            join brokers b on a.BrokerId = b.BrokerId
            join customers c on a.CustomerId = c.CustomerId
            order by a.DateHour;
             */

            /*var dataObj = _context.appointment.Join(
                _context.brokers,
                appointment => appointment.AppointmentId,
                broker => broker.BrokerId,
                (appoModel, brokerModel) => new
                {
                    Appointment = appoModel,
                    BrokerName = brokerModel.LastName + brokerModel.FirstName
                }
            );*/
            
            
            /*var dataObj = _context.appointment.Join(
                _context.brokers,
                appointment => appointment.AppointmentId,
                broker => broker.BrokerId,
                (appointmentModel, brokerModel) => new
                {
                    Appointment = appointmentModel,
                    Broker = brokerModel
                }
            ).ToList();*/
            
            // I don't really understand how these joins works,
            // I'll see tomorrow
            var dataObj = _context.appointment
                .Join(
                    _context.brokers,
                    appointment => appointment.BrokerId,
                    broker => broker.BrokerId,
                    (appointmentModel, brokerModel) => new
                    {
                        Appointment = appointmentModel,
                        Broker = brokerModel
                    }
                )
                .Join(
                    _context.customers,
                    combined => combined.Appointment.CustomerId,
                    customer => customer.CustomerId,
                    (combined, customerModel) => new
                    {
                        combined.Appointment.DateHour,
                        combined.Appointment.Subject,
                        BrokerName = combined.Broker.LastName + " " + combined.Broker.FirstName,
                        CustomerName = customerModel.LastName + " " + customerModel.FirstName
                    }
                )
                .OrderBy(appointment => appointment.DateHour).ToList();
            
            /*var dataObj = _context.appointment
                .GroupJoin(
                    _context.brokers,
                    appointment => appointment.AppointmentId,
                    broker => broker.BrokerId,
                    (appointmentModel, brokerModel) => new
                    {
                        Appointment = appointmentModel,
                        Brokers = brokerModel
                    }
                )
                .SelectMany(
                    x => x.Brokers.DefaultIfEmpty(),
                    (appointmentModel, brokerModel) => new
                    {
                        Appointment = appointmentModel,
                        Broker = brokerModel
                    }
                ).ToList();*/
            
            /*foreach (var d in dataObj)
            {
                Console.WriteLine(d.Subject);
                Console.WriteLine(d.BrokerName + " / " + d.CustomerName);
                Console.WriteLine("---------------");
            }*/
            
            /*var query = _context.appointment
                    .GroupJoin(_context.brokers, 
                    appo => appo.AppointmentId,
                    brok => brok.BrokerId,
                        (appoModel, brokerModel) => new { appoModel, brokerModel })
                    .OrderBy(appo => appo.appoModel.DateHour);

                var l = new List<ExpandoObject>();

                Console.Write(query.ToList().Count);

                dynamic test = new ExpandoObject();
                test.Appointement = query.ToList()[0].appoModel;
                test.Broker = query.ToList()[0].brokerModel;
                l.Add(test);

                return View(l);*/

                            /*return View(await _context.appointment.FromSql($"select * from appointements order by DateHour;")
                .ToListAsync());*/

            return View(dataObj);
        }

        // GET: Appointment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.appointment == null)
            {
                return NotFound();
            }

            var appointmentModel = await _context.appointment
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointmentModel == null)
            {
                return NotFound();
            }

            return View(appointmentModel);
        }

        // GET: Appointment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appointment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentId,DateHour,Subject,BrokerId,CustomerId")] AppointmentModel appointmentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointmentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appointmentModel);
        }

        // GET: Appointment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.appointment == null)
            {
                return NotFound();
            }

            var appointmentModel = await _context.appointment.FindAsync(id);
            if (appointmentModel == null)
            {
                return NotFound();
            }
            return View(appointmentModel);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId,DateHour,Subject,BrokerId,CustomerId")] AppointmentModel appointmentModel)
        {
            if (id != appointmentModel.AppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentModelExists(appointmentModel.AppointmentId))
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
            return View(appointmentModel);
        }

        // GET: Appointment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.appointment == null)
            {
                return NotFound();
            }

            var appointmentModel = await _context.appointment
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointmentModel == null)
            {
                return NotFound();
            }

            return View(appointmentModel);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.appointment == null)
            {
                return Problem("Entity set 'GlobalDataContext.appointment'  is null.");
            }
            var appointmentModel = await _context.appointment.FindAsync(id);
            if (appointmentModel != null)
            {
                _context.appointment.Remove(appointmentModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentModelExists(int id)
        {
          return (_context.appointment?.Any(e => e.AppointmentId == id)).GetValueOrDefault();
        }
    }
}
