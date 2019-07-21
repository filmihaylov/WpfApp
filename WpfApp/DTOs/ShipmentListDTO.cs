using Data.Database;
using Data.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.DTOs
{
    public class ShipmentListDTO
    {
        private Shipment shipment;
        private List<Package> packages;
        public ShipmentListDTO(Shipment shipment, List<Package> packages)
        {
            this.shipment = shipment;
            this.packages = packages;
        }

        public int Indentifier { get { return this.shipment.Id; } }
        public ShipmentState Status { get { return this.shipment.Status; } }
        public string DestinationAdress { get {
                return $"Adress Country: {shipment.AdressDelivery.Country}" +
                    $" City: {shipment.AdressDelivery.City} Street: {shipment.AdressDelivery.Street}";
            } }
        public string CustomerNames
        {
            get
            {
                string packagesNames = "";
                foreach(var package in this.packages)
                {
                    packagesNames = packagesNames + "|" + package.CustomerReceiver.Name;
                }
                return packagesNames;
            }
        }

        public int Packages { get { return packages.Count; } }



    }
}
