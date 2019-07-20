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
    public class Shipment
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public ShipmentState Status { get; set; }
        [DataMember]
        public Adress Adress { get; set; }
        [DataMember]
        public List<Package> Packages { get; set; }
        [DataMember]
        public virtual Truck Truck { get; set; }
    }
}
