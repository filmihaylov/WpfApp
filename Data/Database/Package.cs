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
        public int PackageId { get; set; }
        public PackageState Status { get; set; }
        public virtual Customer Customer { get; set; }
        public PackageCondition Condition { get; set; }
    }
}
