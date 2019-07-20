using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public List<Package> Packages { get; set; }
        [DataMember]
        public Adress Adresses { get; set; }
    }
}
