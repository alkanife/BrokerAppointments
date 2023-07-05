using BrokerAppointements.Models;
using Microsoft.EntityFrameworkCore;

namespace BrokerAppointements.Data;

public class GlobalDataContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(RemoteConnectionString.ConnectionString);
    
    public DbSet<BrokerModel> brokers { get; set; }
    public DbSet<CustomerModel> customers { get; set; }
    public DbSet<AppointmentModel> appointment { get; set; }
}