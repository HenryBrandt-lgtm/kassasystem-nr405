using kassasystem.BluePrints;
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

                string campaginFilePath = "../../Campaginfiles/CampaignList.csv";

                string productsFilePath = "../../Productsfiles/ProductList.csv";
                if (File.Exists(productsFilePath) && amountBought > 0)
                {
                    string[] campaigns = File.ReadAllLines(productsFilePath);
                    List<Campaign> campaignList = new List<Campaign>();

                    foreach (var line in campaigns.Skip(1))
                    {
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        var parts = line.Split(';');

                        if (parts.Length < 5)
                            continue;

                        campaignList.Add(new Campaign
                        {
                            CampaignName = parts[0],
                            ProductId = int.Parse(parts[1]),
                            DiscountPercent = decimal.Parse(parts[2]),
                            StartDate = DateTime.Parse(parts[3]),
                            EndDate = DateTime.Parse(parts[4])
                        });
                    }
                    string[] products = File.ReadAllLines(productsFilePath);
                    foreach (string product in products)
                    {
                        var productParts = product.Split(';');

                        if (productParts[0] == productID)
                        {
                            decimal originalPrice = decimal.Parse(productParts[3]);
                            decimal finalPrice = originalPrice;

                            foreach (var campaign in campaignList.Where(campaign => campaign.ProductId.ToString() == productID 
                            && campaign.IsActive()))
                            {
                                finalPrice *= (1 - campaign.DiscountPercent / 100);
                            }

                            basket.Add(new ShoppingBasket
                            {   
                                Name = productParts[1],
                                Description = productParts[2],
                                Price = finalPrice,
                                Quantity = amountBought
                            });
                            break;
                        }

                    }

                }
                DoneShopping.ShowReceipt(basket);

            }
        }
    }
}

