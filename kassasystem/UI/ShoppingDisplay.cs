using System;
using System.Collections.Generic;

namespace kassasystem.Shopping
{
    internal class ShoppingDisplay
    {
        public static void ShowShoppingDisplay(List<ShoppingBasket> basket)
        {
            DateTime kvittoTid = DateTime.Now;
            decimal grandTotal = 0;
            foreach (var item in basket)
            {
                grandTotal += item.Total;
                Console.WriteLine($"{item.Quantity} {item.Name}  {item.Price}{item.Description}  {item.Total}");
            }
            Console.WriteLine($"TOTAL: {grandTotal}");
            Console.WriteLine();
            Console.WriteLine($"\nKÖP {kvittoTid}");
            Console.WriteLine("Insert product ID followed by amount. (300 1)");
            Console.WriteLine("Tryck Enter för att betala");

            Console.Write("Product: ");
        }
    }
}
