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

                SetDiscountedPrice addingToBasket = new SetDiscountedPrice();

                addingToBasket.AddProductToBasket(basket, productID, amountBought);
               
            }
            NewReceipt saveReceipt = new NewReceipt();
            saveReceipt.CreateReceipt(basket);
            DoneShopping.ShowReceipt(basket);
        }
    }
}

