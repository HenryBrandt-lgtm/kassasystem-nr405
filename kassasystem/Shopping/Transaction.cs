using kassasystem.Data;
using kassasystem.Shopping;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kassasystem
{
    internal class Transaction
    {
        public void NewTransaction()
        {

            string productsFilePath = "../../Productsfiles/ProductList.csv";

            CostumersChoice pickedProduct = new CostumersChoice();

            List<ShoppingBasket> basket = new List<ShoppingBasket>();

            var shopping = true;

            while (shopping)
            {

                var result = pickedProduct.CashersInput(basket);

                if (result == null)
                {
                    shopping = false;
                    continue;
                }
                string productID = result.Value.productID;
                decimal amountBought = result.Value.amountBought;

                if (File.Exists(productsFilePath))
                {

                    var campaignList = CampaignList.CampaignListOutput();

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
                        }
                    }
                }
            }
            NewReceipt saveReceipt = new NewReceipt();
            saveReceipt.CreateReceipt(basket);
            DoneShopping.ShowReceipt(basket);
        }
    }
}

