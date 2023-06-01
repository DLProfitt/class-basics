using System;
using System.Collections.Generic;

namespace Classes
{
    public class Customer
    {
        // Public Properties
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsLocal { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }

    public class DeliveryService
    {
        /*
          Properties
        */
        public string Name { get; set; }

        public string TransitType { get; set; }

        /*
          Methods
        */
        public void Deliver(Product product, Customer customer)
        {
            Console.WriteLine($"Product delivered by {TransitType} to {customer.FullName}");
        }
    }

    public class Product
    {
        /*
          Properties
        */
        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        /*
          Methods
        */
        public void Ship(Customer customer, DeliveryService service)
        {
            if (!customer.IsLocal)
            {
                service.Deliver(this, customer);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product tinkerToys = new Product()
            {
                Title = "Tinker Toys",
                Description = "You can build anything you want",
                Price = 32.49,
                Quantity = 25
            };

            Customer marcus = new Customer()
            {
                FirstName = "Marcus",
                LastName = "Fulbright",
                IsLocal = false
            };

            DeliveryService UPS = new DeliveryService()
            {
                Name = "UPS",
                TransitType = "train"
            };

            // Ship the tinker toys to Marcus using UPS
            tinkerToys.Ship(marcus, UPS);

            Box secret = new Box();
            Console.WriteLine(secret.GetSecret("please"));

            List<string> inventoryItems = new List<string>();
            inventoryItems.Add("Apples");
            inventoryItems.Add("Bananas");
            inventoryItems.Add("Pears");
            inventoryItems.Add("Peaches");
            inventoryItems.Add("Kiwis");

            Store fruitStand = new Store("Fruits Available", inventoryItems);
            Console.WriteLine($"{fruitStand.Name}: ");
            foreach (string fruit in fruitStand.Inventory.OrderBy(fruit => fruit))
            {
                Console.WriteLine(fruit);
            }
        }
    }

    public class Box
    {
        private string _secret = "Sometimes I sing Aretha Franklin songs in the shower.";

        public string GetSecret(string magicWord)
        {
            if (magicWord == "please")
            {
                return _secret;
            }
            else
            {
                return "I'm not telling you!";
            }
        }
    }

    public class Store
    {
        public Store(string name, List<string> initialInventory)
        {
            Name = name;
            Inventory = initialInventory;
        }

        public string Name { get; set; }
        public List<string> Inventory { get; set; }
    }
}

