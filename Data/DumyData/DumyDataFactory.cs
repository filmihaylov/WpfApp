using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DumyData
{
    public class DumyDataFactory
    {
        private static Random random = new Random();
        public Adress GenerateAdress()
        {
            return new Adress()
            {
                City = RandomString(4),
                Street = RandomString(4),
                Country = RandomString(5)

            };
        }

        public Customer GenerateCustomer()
        {
            return new Customer()
            {
                Age = RandomNumber(),
                LastName = RandomString(4),
                Name = RandomString(5)
            };
        }

        public Package GeneratePackage()
        {
            return new Package()
            {
                Condition = States.PackageCondition.Unknown,
                Status = States.PackageState.NotDelivered,
                Customer = this.GenerateCustomer()
            };
        }

        public Shipment GenerateShipment()
        {
            return new Shipment()
            {
                Adress = this.GenerateAdress(),
                Status = States.ShipmentState.InTruck,
                Packages = new List<Package> { this.GeneratePackage() }
            };
        }

        public Truck GenerateTruck()
        {
            return new Truck()
            {
                Shipment = new List<Shipment> { this.GenerateShipment() }
            };
        }

        public static int RandomNumber()
        {
            lock (random)
            {
                return random.Next(1, 30);
            }
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            lock (random)
            {
                return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            }
        }
    }
}
