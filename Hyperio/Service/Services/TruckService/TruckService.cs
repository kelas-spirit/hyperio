using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Service.Dto;

namespace Service.Services.TruckService
{
    public interface ITruckService
    {
        List<TruckDTO> ReadAll();
        void PrintAll();
        void Save(string json);
        void TransferBetweenGoods();
        void Initialization();
    }
    public class TruckService : ITruckService
    {
        public const string truckPath = "../../../db/truck.json";

        public void Initialization()
        {
            var items = new List<TruckDTO>();
            var item1 = new TruckDTO
            {
                name = "goods1",
                goods = new List<string>()
                {
                    "Goods A","Goods B","Goods C"
                }
            };
            items.Add(item1);
            var item2 = new TruckDTO
            {
                name = "goods1",
                goods = new List<string>()
                {
                    "Goods A","Goods B","Goods C"
                }
            };
            items.Add(item2);
            var truckJson = JsonConvert.SerializeObject(items);
            System.IO.File.WriteAllText(truckPath, truckJson);
        }

        public void PrintAll()
        {
            var trucks = ReadAll();
            if (trucks != null)
            {
                foreach (var truck in trucks)
                {
                    Console.WriteLine(truck.name+ ": "+ String.Join(", ", truck.goods));
                }
            }
        }

        public List<TruckDTO> ReadAll()
        {
            var shipJson = File.ReadAllText(truckPath);
            return JsonConvert.DeserializeObject<List<TruckDTO>>(shipJson);
        }

        public void Save(string json)
        {
            try
            {
                System.IO.File.WriteAllText(truckPath, json);
                Console.WriteLine("Saved.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void TransferBetweenGoods()
        {
            var trucks = ReadAll();
            var goods = trucks.FirstOrDefault().goods;
            if (!goods.Any())
            {
                Console.WriteLine("Truck is empty");
            }
            else
            {
                try
                {
                    var item = goods.FirstOrDefault();
                    trucks[0].goods.Remove(item);
                    trucks[1].goods.Add(item);
                    var truckJson = JsonConvert.SerializeObject(trucks);
                    Save(truckJson);
                    PrintAll();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
