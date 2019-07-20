using Data.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    [DataContract]
    public class Package
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public PackageState Status { get; set; }
        [DataMember]
        public  Customer Customer { get; set; }
        [DataMember]
        public PackageCondition Condition { get; set; }
        [DataMember]
        public virtual Shipment Shipment { get; set; }
    }
}
