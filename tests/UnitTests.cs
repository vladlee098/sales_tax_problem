using System;
using src.Core;
using src.Interface;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace tests
{
    [TestFixture]
    public class UnitTests
    {

        [Test]
        public void ParseInputs1()
        {
            var purchaseInput = new List<string>()
            {
                "1 book at 12.49",
                "1 music CD at 14.99",
                "1 chocolate bar at 0.85"
            };

            var factory = new MerchandiseFactory();
            var purchase = factory.BuildPurchase(new InputReader(purchaseInput));

            Assert.AreEqual( 3, purchase.GetGoods().Count);
            Assert.AreEqual( "book", purchase.GetGoods()[0].Name );
            Assert.AreEqual( "music CD", purchase.GetGoods()[1].Name );
            Assert.AreEqual( "chocolate bar", purchase.GetGoods()[2].Name );

            Assert.AreEqual( 12.49, purchase.GetGoods()[0].Price );
            Assert.AreEqual( 14.99, purchase.GetGoods()[1].Price );
            Assert.AreEqual( 0.85, purchase.GetGoods()[2].Price );
        }

        [Test]
        public void ParseInputs_Imported1()
        {
            var purchaseInput = new List<string>()
            {
                "1 imported box of chocolates at 10.00",
                "1 imported bottle of perfume at 47.50"
            };

            var factory = new MerchandiseFactory();
            var purchase = factory.BuildPurchase(new InputReader(purchaseInput));

            Assert.AreEqual( 2, purchase.GetGoods().Count);
            Assert.AreEqual( "imported box of chocolates", purchase.GetGoods()[0].Name );
            Assert.AreEqual( "imported bottle of perfume", purchase.GetGoods()[1].Name );

            Assert.AreEqual( 10.00, purchase.GetGoods()[0].Price );
            Assert.AreEqual( 47.50, purchase.GetGoods()[1].Price );

            Assert.AreEqual( true, purchase.GetGoods()[0].Import );
            Assert.AreEqual( true, purchase.GetGoods()[1].Import );
        }

        [Test]
        public void RoundingRules_FromInput2()
        {
            var purchaseInput = new List<string>()
            {
                "1 imported box of chocolates at 10.00",
                "1 imported bottle of perfume at 47.50"
            };

            var factory = new MerchandiseFactory();
            var purchase = factory.BuildPurchase(new InputReader(purchaseInput));
            
            var output = new StringBuilder();
            var saved = Console.Out;
            try
            {
                using (var writer = new StringWriter(output))
                {
                    Console.SetOut(writer);

                    var processor = new PurchaseProcessor( new PurchaseTaxes() );
                    processor.PrintReceipt(purchase);

                    string expected = "Sales Taxes: 7.65 Total: 65.15";
                    var text = output.ToString();
                    Assert.IsTrue(text.Contains(expected));
                }
            }
            finally
            {
                Console.SetOut(saved);
            }
        }

        [Test]
        public void RoundingRules_FromInput3()
        {
            var purchaseInput = new List<string>()
            {
                "1 imported bottle of perfume at 27.99 1",
                "1 bottle of perfume at 18.99",
                "1 packet of headache pills at 9.75",
                "1 box of imported chocolates at 11.25",
            };

            var factory = new MerchandiseFactory();
            var purchase = factory.BuildPurchase(new InputReader(purchaseInput));
            
            var output = new StringBuilder();
            var saved = Console.Out;
            try
            {
                using (var writer = new StringWriter(output))
                {
                    Console.SetOut(writer);

                    var processor = new PurchaseProcessor( new PurchaseTaxes() );
                    processor.PrintReceipt(purchase);

                    string expected = "Sales Taxes: 6.70 Total: 74.68";
                    var text = output.ToString();
                    Assert.IsTrue(text.Contains(expected));
                }
            }
            finally
            {
                Console.SetOut(saved);
            }
        }        

    }
}
