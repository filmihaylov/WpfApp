using Data.Database;
using Data.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.DTOs
{
    class ShipmentDetailDTO
    {
        public Shipment shipment;
        public ShipmentDetailDTO(Shipment shipment)
        {
            this.shipment = shipment;
        }

        public int Indentifier { get { return this.shipment.Id; } }

        public List<Package> Packages { get { return this.shipment.Packages; } }
        
    }
}
