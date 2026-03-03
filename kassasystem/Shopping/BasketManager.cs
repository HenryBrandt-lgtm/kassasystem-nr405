using kassasystem.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kassasystem.Shopping
{
    internal class BasketManager
    {
        public void AddProductToBasket(List<ShoppingBasket> basket, string productID, decimal amountBought)
        {
            string productsFilePath = "../../Productsfiles/ProductList.csv";


            if (File.Exists(productsFilePath))
            {

                var campaignList = LoadCampaignList.CampaignListOutput();

                string[] products = File.ReadAllLines(productsFilePath);
                foreach (string product in products)
                {
                    var productParts = product.Split(';');

                    if (productParts[0] == productID)
                    {
                        decimal originalPrice = decimal.Parse(productParts[3]);

                        var finalPrice = CalculateFinalPrice.FinalPriceCalculator(productID, originalPrice);
                        
                        basket.Add(new ShoppingBasket
                        {
                            Name = productParts[1],
                            Description = productParts[2],
                            Price = finalPrice,
                            Quantity = amountBought
                        });
                        return;
                    }
                }
            }
            throw new Exception("Couldnt find the product");

        }
    }
}
