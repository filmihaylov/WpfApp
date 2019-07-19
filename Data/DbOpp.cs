using Data.Database;
using Data.DumyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DbOpp
    {
        DeliveryContext db = new DeliveryContext();
        public void CreateDummyData(int entities)
        {
            DumyDataFactory fact = new DumyDataFactory();
            for(int i = 0; i<entities; i++)
            {
                db.Shipments.Add(fact.GenerateShipment());
            }

            db.SaveChanges();

            var a = db.Shipments.SingleOrDefault<Shipment>(x => x.ShipmentId == 1);

            foreach(var p in a.Packages)
            {
                var c = p.Status;
            }
        }
    }
}
