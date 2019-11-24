using System;
using Microsoft.Extensions.DependencyInjection;
using Service.Services.ShipService;
using Service.Services.TruckService;

namespace Challenge2
{
    class Program
    {
            private static IServiceProvider _serviceProvider;
            static void Main(string[] args)
            {
                _serviceProvider = Settings.Settings.RegisterServices();
                var _shipService = _serviceProvider.GetService<IShipService>();
                var _containerService = _serviceProvider.GetService<IContainerService>();
                var _truckService = _serviceProvider.GetService<ITruckService>();


            Console.WriteLine("Current load:");
                var loop = true;
                while (loop)
                {
                    Console.WriteLine("==================================");
                    Console.WriteLine("Menu:");
                    Console.WriteLine("==================================");
                    Console.WriteLine("1.To read list of ships type '1'");
                    Console.WriteLine("2.To read list of containers type '2'");
                    Console.WriteLine("3.To register ship type '3'");
                    Console.WriteLine("4.To load more containers type '4'");
                    Console.WriteLine("5.Transfers between containers and ships. Type '5'");
                    Console.WriteLine("6.Transfers between ships. Type '6'");
                    Console.WriteLine("7.Show trucks: 7");
                    Console.WriteLine("8.Transfers between trucks: 8");
                    Console.WriteLine("9.Initialization: 9");
                    Console.WriteLine("For exit type 'e'");

                    var load = Console.ReadLine();
                    switch (load)
                    {
                        case "1":
                            _shipService.PrintAll();
                            break;
                        case "2":
                            _containerService.PrintAll();
                            break;
                        case "3":
                            _shipService.Register();
                            break;
                        case "4":
                            _containerService.Load();
                            break;
                        case "5":
                            _shipService.TransferContainerToShip();
                            break;
                        case "6":
                            _shipService.TransferBetweenShips();
                            break;
                        case "7":
                            _truckService.PrintAll();
                            break;
                        case "8":
                            _truckService.TransferBetweenGoods();
                            break;
                        case "9":
                            _containerService.Initialization();
                            _truckService.Initialization();
                            _shipService.Initialization();
                            Console.WriteLine("Done");
                        break;
                        case "e":
                            loop = false;
                            break;
                        default:
                            Console.WriteLine("Wrong key. Please, try again.");
                        break;
                    }
            }

            }

    }
    
}
