using BrokerAppointements.Models;
using Microsoft.EntityFrameworkCore;

namespace BrokerAppointements.Data;

public class GlobalDataContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(RemoteConnectionString.ConnectionString);
    
    public DbSet<Broker> brokers { get; set; }
    public DbSet<Customer> customers { get; set; }
}