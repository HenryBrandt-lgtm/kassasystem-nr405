using kassasystem.Shopping;
using System.Collections.Generic;

namespace kassasystem
{
    internal class Transaction
    {
        public void NewTransaction()
        {

            CostumersChoice pickedProduct = new CostumersChoice();

            List<ShoppingBasket> basket = new List<ShoppingBasket>();

            BasketManager addingToBasket = new BasketManager();

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

                addingToBasket.AddProductToBasket(basket, productID, amountBought);

            }
            NewReceipt saveReceipt = new NewReceipt();
            saveReceipt.CreateReceipt(basket);
            DoneShopping.ShowReceipt(basket);
        }
    }
}