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
        public int Id { get; set; }
        public ShipmentState Status { get; set; }
        public Adress Adress { get; set; }
        public List<Package> Packages { get; set; }
        public virtual Truck Truck { get; set; }
    }
}
