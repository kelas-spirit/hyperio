using System;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace Hyperio
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            _serviceProvider = Settings.Settings.RegisterServices();
            var _service = _serviceProvider.GetService<IUnreadableService>();
            var arr = new string[] { "arr","test","element","Nikos","sport" };
            /*
             * It takes two parameter. The first one is a string and the second
             * is an array of string and tries and this method tries to remove
             * the first parameter from array if exists
             */
            //_service.Do("element", ref arr);
            // Just make it readable 
            _service.MakeItReadable("element", arr);

            Settings.Settings.DisposeServices();
            Console.ReadLine();
        }
    }
}
