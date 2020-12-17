using System;
using System.Collections.Generic;
using System.Text;
using src.Core;
using src.Interface;

namespace src.UI
{
    public class Application : IApplication
    {
        IMerchandiseFactory _factory;
        IPurchaseProcessor  _processor;

        public Application(IMerchandiseFactory factory, IPurchaseProcessor processor)
        {
            _factory = factory;
            _processor = processor;
        }

        public void Run()
        {
            while( true)
            {
                char selection = PurchaseSelector.SelectInput();
                var purchaseInput = PurchaseSelector.GetInput( selection);
                if (purchaseInput is null)
                {
                    return;
                }

                var purchase = _factory.BuildPurchase(new InputReader(purchaseInput));
                _processor.PrintReceipt(purchase);
    
                Console.WriteLine("-----------------------------------");
                Console.WriteLine();
            }            
        }
    }
}
