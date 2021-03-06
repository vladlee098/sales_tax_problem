using System;
using System.Collections.Generic;
using src.Interface;

namespace src.Core
{
    public class PurchaseProcessor
    {
        readonly IPurchase _purchase;
        readonly List<ITax> _taxes;

        public PurchaseProcessor( IPurchase purchase, List<ITax> taxes )
        {
            _purchase = purchase;
            _taxes = taxes;
        }

        public virtual void PrintReceipt()
        {
            var goods = _purchase.GetGoods();
            if ( goods is null || goods.Count == 0)
            {
                return;
            }
            
            decimal taxTotal = 0M;
            decimal purchaseTotal = 0M;
            foreach( var merchandise in goods )
            {
                decimal merchTax = 0M;
                foreach( var tax in _taxes)
                {
                    merchTax += tax.Estimate(merchandise);
                }
                PrintText( merchandise, merchTax);
                taxTotal += merchTax;
                purchaseTotal += (merchTax + merchandise.Price);
            }
            Console.WriteLine( $"Sales Taxes: {taxTotal:####.#0} Total: {purchaseTotal:####.#0}" );
        }

        private void PrintText( IMerchandise merchandise, decimal tax)
        {
            var priceTotal = merchandise.Price + tax;
            Console.WriteLine( $"{merchandise.Amount} {merchandise.Name}: {priceTotal:####.#0}" );
        }
    }
}
