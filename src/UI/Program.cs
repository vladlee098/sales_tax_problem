using System;
using Autofac;
namespace src.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("       Sales Taxes Problem         ");
            Console.WriteLine("-----------------------------------");
    
            var container = ContainerConfig.Configure();
            using( var scope = container.BeginLifetimeScope() )
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }

        }
    }
}
