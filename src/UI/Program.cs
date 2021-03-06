﻿using System;
using System.Collections.Generic;
using System.Text;
using src.Core;
using src.Interface;

namespace UI
{
    class Program
    {
        
        static char SelectInput()
        {
            try
            {
                Console.WriteLine();
                Console.Write($">> Select purchase input (1,2 or 3), ESC to quit: ");
                while (true)
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        return '0';
                    }
                    if (key.KeyChar == '1' || key.KeyChar == '2' || key.KeyChar == '3')
                    {
                        return key.KeyChar;
                    }
                }
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine();
            }
        } 

        static List<string> GetInput( char selection)
        {
            if (selection == '1')
            {
                var purchaseInput1 = new List<string>()
                {
                    "1 book at 12.49",
                    "1 music CD at 14.99",
                    "1 chocolate bar at 0.85"
                };
                return purchaseInput1;
            }
            if (selection == '2')
            {
                var purchaseInput2 = new List<string>()
                {
                    "1 imported box of chocolates at 10.00",
                    "1 imported bottle of perfume at 47.50"
                };
                return purchaseInput2;
            }
            if (selection == '3')
            {
                var purchaseInput3 = new List<string>()
                {
                    "1 imported bottle of perfume at 27.99 1",
                    "1 bottle of perfume at 18.99",
                    "1 packet of headache pills at 9.75",
                    "1 box of imported chocolates at 11.25",
                };
                return purchaseInput3;
            }

            return null;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("       Sales Taxes Problem         ");
            Console.WriteLine("-----------------------------------");
    

            while( true)
            {
                char selection = SelectInput();
                var purchaseInput = GetInput( selection);
                
                if (purchaseInput is null)
                {
                    return;
                }
                var factory = new MerchandiseFactory();
                var merchandises = factory.Create(new InputReader(purchaseInput));

                var availableTaxes = new List<ITax>
                {
                    new SalesTax( new Exemptions() ),
                    new ImportTax()
                };

                var processor = new PurchaseProcessor(new Purchase(merchandises), availableTaxes);
                processor.PrintReceipt();
    
                Console.WriteLine("-----------------------------------");
                Console.WriteLine();
            }


            //Console.WriteLine(">> Press ENTER to quit.");
            //Console.ReadLine();

        }
    }
}
