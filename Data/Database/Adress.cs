using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    [DataContract]
    public class Adress
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string City { get; set; }

    }
}
