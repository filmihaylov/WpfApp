using Data.Database;
using Data.DumyData;
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
        DeliveryContext db;

        public DbOpp()
        {
            this.db = new DeliveryContext();

        }


        public void CreateDummyData(int entities)
        {
        //    DumyDataFactory fact = new DumyDataFactory();
       //     for(int i = 0; i<entities; i++)
       //     {
      //          db.Trucks.Add(fact.GenerateTruck());
      //      }

      //      db.SaveChanges();

            
            var a = db.Trucks.Where(t=>t.Id == 1).Include(s=>s.Shipment).FirstOrDefault();

            var p = a.Shipment;

        }
    }
}
