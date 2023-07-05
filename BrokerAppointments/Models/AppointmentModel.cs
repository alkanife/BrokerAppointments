using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokerAppointments.Models;

[Table("appointements")]
public class AppointmentModel
{
    [Key]
    public int AppointmentId { get; set; }
    public DateTime DateHour { get; set; }
    public string Subject { get; set; }
    public int BrokerId { get; set; }
    public int CustomerId { get; set; }

    public AppointmentModel()
    {
    }

    public AppointmentModel(int appointmentId, DateTime dateHour, string subject, int brokerId, int customerId)
    {
        AppointmentId = appointmentId;
        DateHour = dateHour;
        Subject = subject;
        BrokerId = brokerId;
        CustomerId = customerId;
    }
}