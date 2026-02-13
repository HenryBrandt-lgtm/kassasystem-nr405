using System;
using System.Collections.Generic;
using System.Linq;

namespace kassasystem
{
    internal class DoneShopping

    {
        public static void ShowReceipt(List<ShoppingBasket> basket)
        {
            Receipt receipt = new Receipt();
            decimal grandTotal = 0;
            receipt.AddNewRecipt();
            Console.Clear();
            Console.WriteLine("===== KVITTO =====");

            foreach (var item in basket)
            {
                grandTotal += item.Total;
                Console.WriteLine($"{item.Quantity} {item.Name}  {item.Price}  {item.Total}");
                receipt.AddProductsToRecipt(item.Quantity, item.Name, item.Price);
            }

            Console.WriteLine("------------------");
            Console.WriteLine($"TOTAL: {grandTotal}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            receipt.AddReceiptEnd(grandTotal);
            ShowMenu.ShowMainMenu();
        }
    }
}
