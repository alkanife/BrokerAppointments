using BrokerAppointments.Models;
using Microsoft.EntityFrameworkCore;

namespace BrokerAppointments.Data;

public class GlobalDataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(RemoteConnectionString.ConnectionString);
    
    public DbSet<BrokerModel> Brokers { get; set; }
    public DbSet<CustomerModel> Customers { get; set; }
    public DbSet<AppointmentModel> Appointments { get; set; }
}