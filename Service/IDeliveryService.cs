using Data.Database;
using Data.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDeliveryService
    {

        [OperationContract]
        List<Shipment> GetShipments(Truck truck, int skip = 0, int take = 25);

        [OperationContract]
        void UpdateShipment(Shipment shipment, ShipmentState state);
        [OperationContract]
        List<Package> GetPackages(Shipment shipment);
    }

}
