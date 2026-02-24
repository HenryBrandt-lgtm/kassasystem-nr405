using System;
using System.Collections.Generic;
using System.IO;

namespace kassasystem
{
    internal class Transaction
    {
        public void NewTransaction()
        {
            string productID = "";
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
                if (userInput == "")
                {
                    shopping = false;
                    continue;
                }
                var amountAndID = userInput.Split(' ');
                if (amountAndID.Length != 2 ||
                    !decimal.TryParse(amountAndID[1], out amountBought) ||
                    amountBought <= 0)
                {
                    Console.WriteLine("You must use the format \"300 1\" and amount must be grater than 0");
                    Console.ReadKey();
                    continue; 
                }

                productID = amountAndID[0];

                string filePath = "../../Productsfiles/ProductList.csv";
                if (File.Exists(filePath) )
                {
                    string[] products = File.ReadAllLines(filePath);
                    foreach (string product in products)
                    {
                        var parts = product.Split(';');
                        if (parts[0] == productID && amountBought > 0)
                        {
                            basket.Add(new ShoppingBasket
                            {
                                Name = parts[1],
                                Description = parts[2],
                                Price = decimal.TryParse(parts[3], out var price) ? price : 0,
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
