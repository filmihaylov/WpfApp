using Data.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public ShipmentState Status { get; set; }
        public virtual Adress Adress { get; set; }
        public List<Package> Packages { get; set; }
    }
}
