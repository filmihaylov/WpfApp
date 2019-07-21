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
        private Shipment shipment;
        public ShipmentDetailDTO(Shipment shipment)
        {
            this.shipment = shipment;
        }

        public int Indentifier { get { return this.shipment.Id; } }
        public ShipmentState Status { get { return this.shipment.Status; } }
        public string DestinationAdress
        {
            get
            {
                return $"Adress Country: {shipment.AdressDelivery.Country}" +
                    $" City: {shipment.AdressDelivery.City} Street: {shipment.AdressDelivery.Street}";
            }
        }
    }
}
