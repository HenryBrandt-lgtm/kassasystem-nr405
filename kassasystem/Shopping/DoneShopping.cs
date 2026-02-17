using System;
using System.Collections.Generic;

namespace kassasystem
{
    internal class DoneShopping

    {
        public static void ShowReceipt(List<ShoppingBasket> basket)
        {
            NewReceipt receipt = new NewReceipt();
            decimal grandTotal = 0;
            receipt.AddNewRecipt();
            Console.Clear();
            Console.WriteLine("===== KVITTO =====");

            foreach (var item in basket)
            {
                grandTotal += item.Total;
                Console.WriteLine($"{item.Quantity} {item.Name}  {item.Price}  {item.Total}");
                receipt.AddProductsToReceipt(item.Quantity, item.Name, item.Price);
            }
            decimal moms = grandTotal * 0.12m;
            decimal roundedMoms = Math.Round(moms, 2);
            Console.WriteLine("------------------");
            Console.WriteLine($"TOTAL: {grandTotal}");
            Console.WriteLine($"\nMoms: 12%\t{roundedMoms}");
            Console.WriteLine("Press anykey to return to main menu.");
            Console.ReadKey();
            Console.Clear();

            receipt.AddReceiptEnd(grandTotal);

            ShowMenu.ShowMainMenu();
        }
    }
}
