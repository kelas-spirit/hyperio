using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace Hyperio.Settings
{
    public static class Settings
    {
        private static IServiceProvider _serviceProvider;
        public static IServiceProvider RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IUnreadableService, UnreadableService>();
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
