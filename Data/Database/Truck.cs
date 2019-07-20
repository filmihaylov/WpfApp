using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class Truck
    {
        public int Id { get; set; }
        public Shipment Shipment { get; set; }
    }
}
