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
    public class AppointmentController : Controller
    {
        private readonly GlobalDataContext _context;

        public AppointmentController(GlobalDataContext context)
        {
            _context = context;
        }

        public IActionResult Index(DateTime? startDate)
        {
            if (_context.Appointments == null)
                return Problem("Entity set 'GlobalDataContext.appointment'  is null.");

            startDate ??= DateTime.Parse("2000-01-01 00:00:00.000");

            var dataObj = _context.Appointments
                .Where(appointment => appointment.DateHour >= startDate)
                .Join(
                    _context.Brokers,
                    appointment => appointment.BrokerId,
                    broker => broker.BrokerId,
                    (appointmentModel, brokerModel) => new
                    {
                        Appointment = appointmentModel,
                        Broker = brokerModel
                    }
                )
                .Join(
                    _context.Customers,
                    combined => combined.Appointment.CustomerId,
                    customer => customer.CustomerId,
                    (combined, customerModel) => new
                    {
                        combined.Appointment.AppointmentId,
                        combined.Appointment.DateHour,
                        combined.Appointment.Subject,
                        BrokerName = combined.Broker.LastName + " " + combined.Broker.FirstName,
                        CustomerName = customerModel.LastName + " " + customerModel.FirstName
                    }
                )
                .OrderBy(appointment => appointment.DateHour).ToList();

            List<ParsedAppointment> parsedAppointments = new List<ParsedAppointment>();
            
            foreach (var data in dataObj)
            {
                var parsedAppointment = new ParsedAppointment();
                parsedAppointment.AppointmentId = data.AppointmentId;
                
                //crop subject
                var split = data.Subject.Split(" ");
                var splited = data.Subject;
                if (split.Length > 10)
                {
                    splited = "";
                    for (var i = 0; i < 5; i++)
                        splited += split[i] + " ";
                }
                parsedAppointment.Subject = splited + "(...)";
                
                // date et heure
                // todo

                parsedAppointment.DateTime = data.DateHour;
                parsedAppointment.BrokerName = data.BrokerName;
                parsedAppointment.CustomerName = data.CustomerName;
                
                parsedAppointments.Add(parsedAppointment);
            }
            
            // todo: j'ai dû retirer le model de la view car il voulait pas le prendre en argument
            return View(parsedAppointments);
        }

        // GET: Appointment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointmentModel = await _context.Appointments
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

        // GET: Appointment/Create
        /*public IActionResult CreateFromClient(string? clientName)
        {
            return View("Create", clientName);
        }*/

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
                return RedirectToAction("Details", new { id = appointmentModel.AppointmentId});
            }
            return View(appointmentModel);
        }

        // GET: Appointment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointmentModel = await _context.Appointments.FindAsync(id);
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
                return RedirectToAction("Details", new { id = appointmentModel.AppointmentId});
            }
            return View(appointmentModel);
        }

        // GET: Appointment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointmentModel = await _context.Appointments
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
            if (_context.Appointments == null)
            {
                return Problem("Entity set 'GlobalDataContext.Appointments'  is null.");
            }
            var appointmentModel = await _context.Appointments.FindAsync(id);
            if (appointmentModel != null)
            {
                _context.Appointments.Remove(appointmentModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool AppointmentModelExists(int id)
        {
          return (_context.Appointments?.Any(e => e.AppointmentId == id)).GetValueOrDefault();
        }
    }
}
