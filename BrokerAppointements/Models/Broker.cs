namespace BrokerAppointements.Models;

public class Broker
{
    public int BrokerId { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Mail { get; set; }
    public string PhoneNumber { get; set; }

    public Broker()
    {
    }

    public Broker(int brokerId, string lastName, string firstName, string mail, string phoneNumber)
    {
        BrokerId = brokerId;
        LastName = lastName;
        FirstName = firstName;
        Mail = mail;
        PhoneNumber = phoneNumber;
    }
}