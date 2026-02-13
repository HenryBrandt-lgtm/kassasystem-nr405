using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kassasystem
{
    internal class Transaction
    {
        public void NewTransaction()
        {
            
            List<ShoppingBasket> basket = new List<ShoppingBasket>();
            decimal amountBought = 0;
            var shopping = true;
            while (shopping)
            {

                ShowProductList.ListOfProducts();
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
                string userInput = Console.ReadLine();
                if (userInput == "" ) 
                {
                    shopping = false;
                    continue;
                }
                var amountAndID = userInput.Split(' ');
                var productID = amountAndID[0];
                amountBought = Convert.ToDecimal(amountAndID[1]);

                string filePath = "../../Products/ProductList.csv";
                if (File.Exists(filePath))
                {
                    string[] products = File.ReadAllLines(filePath);
                    foreach (string product in products)
                    {
                        var parts = product.Split(';');
                        if (parts[0] == productID)
                        {
                            basket.Add(new ShoppingBasket
                            {
                                Name = parts[1],
                                Description = parts[2],
                                Price = decimal.Parse(parts[3]),
                                Quantity = amountBought
                            });
                        }                       
                    }
                }

                Console.Clear();
            }
            DoneShopping.ShowReceipt(basket);

        }
    }
}
