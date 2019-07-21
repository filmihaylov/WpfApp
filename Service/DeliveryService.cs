using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Data;
using Data.Database;
using Data.States;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class DeliveryService : IDeliveryService
    {
        public List<Shipment> GetShipments(Truck truck, int skip = 0, int take = 25)
        {
            if (truck == null)
            {
                throw new ArgumentNullException("truck");
            }

            DbOpp db = new DbOpp();

            return db.GetShipments(truck, skip, take);
        }

        public List<Package> GetPackages(Shipment shipment)
        {
            if (shipment == null)
            {
                throw new ArgumentNullException("truck");
            }

            DbOpp db = new DbOpp();

            return db.GetPackages(shipment);
        }

        public void UpdatePackageState(ShipmentState state,PackageCondition packageCondition, PackageState packageState, string notes, Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("shipment");
            }

            DbOpp db = new DbOpp();

            db.UpdatePackageState(state, packageCondition, packageState, notes, package);
        }
    }
}
