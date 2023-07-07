using System.Diagnostics;
using BrokerAppointments.Data;
using Microsoft.AspNetCore.Mvc;
using BrokerAppointments.Models;

namespace BrokerAppointments.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly GlobalDataContext _context;

    public HomeController(ILogger<HomeController> logger, GlobalDataContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        if (_context.Appointments == null)
            return Problem("Entity set 'GlobalDataContext.appointment'  is null.");

        var dataObj = _context.Appointments
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
            .OrderBy(appointment => appointment.DateHour).Take(5).ToList();

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

            if (splited.EndsWith(" "))
                splited = splited.Remove(splited.Length - 1, 1);
            
            parsedAppointment.Subject = splited + "<i>...</i>";
            
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}