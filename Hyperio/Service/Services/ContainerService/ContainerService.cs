using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Service.Dto;

namespace Service.Services.TruckService
{
    public interface IContainerService
    {
        ContainerDTO ReadAll();
        void PrintAll();
        void Load();
        void Save(string json);
        void Initialization();
    }
    public class ContainerService : IContainerService
    {
        public const string containerPath = "../../../db/container.json";

        public void Load()
        {
            var container = ReadAll();
            Console.WriteLine("New container:");
            var load = Console.ReadLine();
            var exist = container.newContainers.Any(x => x == load);
            if (exist)
            {
                Console.WriteLine("Container already exist.");
            }
            else
            {
                container.newContainers.Add(load);
                container.isUsed = new List<string>();
                var containerJson = JsonConvert.SerializeObject(container);
                Save(containerJson);
            }


        }

        public void PrintAll()
        {
            var containers = ReadAll();
            if (containers != null)
            {
                    foreach (var container in containers.newContainers)
                    {
                        Console.WriteLine(String.Join(", ", container));
                    }
            }
            
        }

        public ContainerDTO ReadAll()
        {
            var containers = File.ReadAllText(containerPath);
            return JsonConvert.DeserializeObject<ContainerDTO>(containers);
        }

        public void Save(string json)
        {
            try
            {
                System.IO.File.WriteAllText(containerPath, json);
                Console.WriteLine("Saved");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Initialization()
        {
            var item = new ContainerDTO
            {
                isUsed = new List<string>(),
                newContainers = new List<string>()
                {
                    "Container A", "Container B", "Container C", "Container D", "Container E"
                }
            };
            var containerJson = JsonConvert.SerializeObject(item);
            System.IO.File.WriteAllText(containerPath, containerJson);

        }
    }
}
