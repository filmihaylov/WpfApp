using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    [DataContract]
    public class Truck
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public List<Shipment> Shipment { get; set; }
    }
}
