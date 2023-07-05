using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokerAppointments.Models;

[Table("customers")]
public class CustomerModel
{
    [Key]
    public int CustomerId { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Mail { get; set; }
    public string PhoneNumber { get; set; }
    public int Budget { get; set; }

    public CustomerModel()
    {
    }

    public CustomerModel(int customerId, string lastName, string firstName, string mail, string phoneNumber, int budget)
    {
        CustomerId = customerId;
        LastName = lastName;
        FirstName = firstName;
        Mail = mail;
        PhoneNumber = phoneNumber;
        Budget = budget;
    }
}