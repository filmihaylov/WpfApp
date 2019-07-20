using Data.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class Package
    {
        public int Id { get; set; }
        public PackageState Status { get; set; }
        public  Customer Customer { get; set; }
        public PackageCondition Condition { get; set; }
        public virtual Shipment Shipment { get; set; }
        public Adress Adress { get; set; }
    }
}
