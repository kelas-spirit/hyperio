using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Newtonsoft.Json;
using Service.Dto;
using Service.Services.TruckService;

namespace Service.Services.ShipService
{
    public interface IShipService
    {
        List<ShipDTO> ReadAll();
        void PrintAll();
        void Register();
        void Save(string json);
        void TransferContainerToShip();
        void TransferBetweenShips();
        void Initialization();
    }
    public class ShipService : IShipService
    {
        public const string shipPath = "../../../db/ship.json";
        public void Register()
        {
            Console.WriteLine("Capacity(optionally, by default is 4):");
            var load = Console.ReadLine();
            int n;
            bool isNumeric = int.TryParse(load, out n);
            if (!isNumeric || n > 4)
            {
                n = 4;
                Console.WriteLine("Wrong input. Ship will be registered with capacity = 4");
            }
            var ship = new ShipDTO
            {
                Capacity = n,
                Containers = new List<string>()
            };
            var ships = ReadAll();
            ships.Add(ship);
            var shipJson = JsonConvert.SerializeObject(ships);
            Save(shipJson);
            
        }

        string ShipOutputs(List<string> data)
        {
            
            return data.Any() ? String.Join(", ", data) : "empty";
        }
        public void PrintAll()
        {
            var ships = ReadAll();
            var index = 0;
            foreach (var ship in ships)
            {
                index++;
                Console.WriteLine("Ship "+index+": " + ShipOutputs(ship.Containers) + " . Capacity: "+ ship.Capacity);
            }
        }

        public List<ShipDTO> ReadAll()
        {
            var shipJson = File.ReadAllText(shipPath);
            return JsonConvert.DeserializeObject<List<ShipDTO>>(shipJson);
        }

        public void Save(string json)
        {
            try
            {
                System.IO.File.WriteAllText(shipPath, json);
                Console.WriteLine("Ship was registered.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public bool CheckForContainer(string load)
        {
            var ships = ReadAll();           
            var found = ships.Any(x => x.Containers.Contains(load));
            return found;
        }

        public void SaveContainerToShip(string load)
        {
            var ships = ReadAll();
            foreach (var ship in ships)
            {
                if (ship.Capacity > ship.Containers.Count())
                {
                    ship.Containers.Add(load);
                    break;
                }
            }
            var shipJson = JsonConvert.SerializeObject(ships);
            Save(shipJson);
        }
        public void TransferContainerToShip()
        {
            var containerService = new ContainerService();
            var containers = containerService.ReadAll();
            Console.WriteLine("Container Name: ");
            var load = Console.ReadLine();
            if (string.IsNullOrEmpty(load))
            {
                Console.WriteLine("Invalid Input");
            }
            else
            {
                var exist = containers.newContainers.Any(x => x == load);
                if (!exist)
                {
                    Console.WriteLine(load+" doesn't exist");
                }
                else
                {
                    var inShip = CheckForContainer(load);
                    if (inShip)
                    {
                        Console.WriteLine("Already in ship");
                    }
                    else
                    {
                        try
                        {
                            SaveContainerToShip(load);
                            Console.WriteLine("fleet was updated");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }

        }

        public void TransferBetweenShips()
        {
            var transfered = false;
            var wasDeleted = false;
            var ships = ReadAll();
            var container = ships.FirstOrDefault(x => x.Containers.Any()).Containers.FirstOrDefault();
            foreach (var ship in ships)
            {
                var exist = ship.Containers.Contains(container);
                if (exist)
                {
                    wasDeleted = true;
                    ship.Containers.Remove(container);
                    continue;
                }

                if (ship.Capacity > ship.Containers.Count && wasDeleted)
                {
                    transfered = true;
                    ship.Containers.Add(container);
                    break;
                }
            }

            if (!transfered)
            {
                Console.WriteLine("Container was unloaded");
            }
            else
            {
                var shipJson = JsonConvert.SerializeObject(ships);
                Save(shipJson);
                Console.WriteLine("Done");

            }
        }

        public void Initialization()
        {
            var items = new List<ShipDTO>();
            var item1 = new ShipDTO
            {
                Capacity = 4,
                Containers = new List<string>()
                {
                    "Container A", "Container B", "Container C"
                }
            };
            items.Add(item1);
            var item2 = new ShipDTO
            {
                Capacity = 4,
                Containers = new List<string>()
                {
                    "Container D", "Container E"
                }
            };
            items.Add(item2);
            var truckJson = JsonConvert.SerializeObject(items);
            System.IO.File.WriteAllText(shipPath, truckJson);

        }
    }
}
