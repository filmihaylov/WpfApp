using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class Adress
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public virtual List<Shipment> Shipments { get; set; }

        public virtual List<Customer> Customers { get; set; }
    }
}
