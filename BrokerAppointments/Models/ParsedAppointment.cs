namespace BrokerAppointments.Models;

public class ParsedAppointment
{
    public int AppointmentId { get; set; }
    public string Subject { get; set; }
    public DateTime DateTime { get; set; }
    public string BrokerName { get; set; }
    public string CustomerName { get; set; }

    public ParsedAppointment()
    {
    }

    public ParsedAppointment(int appointmentId, string subject, DateTime dateTime, string brokerName, string customerName)
    {
        AppointmentId = appointmentId;
        Subject = subject;
        DateTime = dateTime;
        BrokerName = brokerName;
        CustomerName = customerName;
    }
}