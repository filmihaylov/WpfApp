using Data.Database;
using Data.DumyData;
using Data.States;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DbOpp
    {
        private readonly DeliveryContext db;

        public DbOpp()
        {
            this.db = new DeliveryContext();
        }

        public void CreateDummyData(int entities)
        {
            DumyDataFactory fact = new DumyDataFactory();
            for (int i = 0; i < entities; i++)
            {
                db.Trucks.Add(fact.GenerateTruck());
            }

            db.SaveChanges();
        }

        public List<Shipment> GetShipments(Truck truck, int skip=0, int take=25)
        {
            this.db.Configuration.ProxyCreationEnabled = false;

            var shipments = db.Shipments.Where(s => s.Truck.Id == truck.Id).ToList();
            
            return shipments.Skip(skip).Take(take).ToList();
        }

        public void UpdateShipment(Shipment shipment, ShipmentState state)
        {
            var shipmentForUpdate = db.Shipments.Where(s => s.Id == shipment.Id).FirstOrDefault();

            shipmentForUpdate.Status = state;

            db.SaveChanges();

        }
       
    }
}
