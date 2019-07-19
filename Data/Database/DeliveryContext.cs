using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class DeliveryContext : DbContext
    {
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Adress> Adresess { get; set; }
    }
}
