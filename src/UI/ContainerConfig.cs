using System.Linq;
using System.Reflection;
using Autofac;
using src.Core;
using src.Interface;

namespace src.UI
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<MerchandiseFactory>().As<IMerchandiseFactory>();
            builder.RegisterType<PurchaseTaxes>().As<IPurchaseTaxes>();
            builder.RegisterType<PurchaseProcessor>().As<IPurchaseProcessor>();

            // .FirstOrDefault( i => i.Name == "I" + t.Name)
            builder.RegisterAssemblyTypes( Assembly.Load(nameof(Interface)))
                .Where( t => t.Namespace.Contains("src.Interface") )
                .As( t => t.GetInterfaces());


            return builder.Build();
        }
    }
}
