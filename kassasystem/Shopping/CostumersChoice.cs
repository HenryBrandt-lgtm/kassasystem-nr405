using kassasystem.Data;
using kassasystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace kassasystem.Shopping
{
    internal class CostumersChoice
    {
        public (int productID, decimal amountBought)? CashersInput(List<ShoppingBasket> basket)
        {

            while (true)
            {
                ReadProductList.ListOfProducts();

                ShoppingDisplay.ShowShoppingDisplay(basket);

                string userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    return null;
                }

                var amountAndID = userInput.Split(' ');

                if (amountAndID.Length != 2 ||
                   !int.TryParse(amountAndID[0], out int productID) ||
                   !decimal.TryParse(amountAndID[1], out decimal amountBought) ||
                   amountBought <= 0 || amountBought > 100)

                {
                    Console.WriteLine("You must use the format \"300 1\" " +
                        "\nAmount must be grater than 0 and less than 100." +
                        "\nPress space to try again");
                    Console.ReadKey(); continue;
                }
                var productList = LoadProductList.ProductListOutput();
                bool productExist = productList.Any(p => p.ProductID == productID);

                if (!productExist)
                {
                    Console.WriteLine("Product doesnt exist, press space to try again.");
                    Console.ReadKey(); continue;
                }
                return (productID, amountBought);

            }
        }
    }
}
