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
                Country = RandomString(5),
            };
        }

        public Customer GenerateCustomer(Adress adress)
        {
            return new Customer()
            {
                Age = RandomNumber(),
                LastName = RandomString(4),
                Name = RandomString(5),
                Adresses = adress
            };
        }

        public Package GeneratePackage(Adress adressSender, Adress adressReceiver)
        {
            return new Package()
            {            
                CustomerSender = this.GenerateCustomer(adressSender),
                CustomerReceiver = this.GenerateCustomer(adressReceiver)
                
            };
        }

        public Shipment GenerateShipment( Customer customer, Adress adressDelivery, Adress adressSender)
        {
            return new Shipment()
            {           
                AdressDelivery = adressDelivery,
                AdressSender = adressSender,
                Status = States.ShipmentState.OutForDelivery,
                Packages = new List<Package> { this.GeneratePackage(adressDelivery, adressSender), this.GeneratePackage(adressDelivery, adressSender) }
            };
        }

        public Truck GenerateTruck()
        {
            List<Shipment> shipments = new List<Shipment>();
            for (int i=0; i < 150; i++)
            {
                Adress adressDelivery = this.GenerateAdress();
                Adress adressSender = this.GenerateAdress();
                Customer customer = this.GenerateCustomer(adressDelivery);
                shipments.Add(this.GenerateShipment(customer, adressDelivery, adressSender));
            }
            return new Truck()
            {
                Shipment = shipments
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
