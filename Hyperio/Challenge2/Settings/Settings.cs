using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Service.Services.ShipService;
using Service.Services.TruckService;

namespace Challenge2.Settings
{
    public static class Settings
    {
        private static IServiceProvider _serviceProvider;
        public static IServiceProvider RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IShipService, ShipService>();
            collection.AddScoped<IContainerService, ContainerService>();
            collection.AddScoped<ITruckService, TruckService>();
            // ...
            // Add other services
            // ...
            _serviceProvider = collection.BuildServiceProvider();
            return _serviceProvider;
        }
        public static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}

