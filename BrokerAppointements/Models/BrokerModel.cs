using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokerAppointements.Models;

[Table("brokers")]
public class BrokerModel
{
    [Key]
    public int BrokerId { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Mail { get; set; }
    public string PhoneNumber { get; set; }

    public BrokerModel()
    {
    }

    public BrokerModel(int brokerId, string lastName, string firstName, string mail, string phoneNumber)
    {
        BrokerId = brokerId;
        LastName = lastName;
        FirstName = firstName;
        Mail = mail;
        PhoneNumber = phoneNumber;
    }
}