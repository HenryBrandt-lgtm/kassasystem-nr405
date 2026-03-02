using System;
using System.Collections.Generic;

namespace kassasystem.Shopping
{
    internal class CostumersChoice
    {
        public (string productID, decimal amountBought)? CashersInput(List<ShoppingBasket> basket)
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
                    !decimal.TryParse(amountAndID[1], out decimal amountBought) || amountBought <= 0 || amountBought > 100)
                {
                    Console.WriteLine("You must use the format \"300 1\" \nAmount must be grater than 0 and less than 100");
                    Console.ReadKey();
                    continue;
                }
                return (amountAndID[0], amountBought);

            }
        }
    }
}
