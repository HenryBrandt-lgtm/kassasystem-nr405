using kassasystem.BluePrints;
using System;
using System.Threading;

namespace kassasystem.Products
{
    internal static class ProductMenu
    {
        public static void ListOfProductOptions()
        {
            ReadProductList.ListOfProducts();

            var option1 = "Add new product";
            var option2 = "Remove product";
            var option3 = "Update a product";
            var option4 = "Go back to main menu";

            KeyMenu optionOf4 = new KeyMenu(option1, option2, option3, option4);
            ScrollMenu productMenu = new ScrollMenu();

            var option = productMenu.ScrollMenuOptionOf4WithoutExit(optionOf4);

            Console.CursorVisible = true;

            switch (option)
            {
                case 1:
                    CreateNewProducts addProduct = new CreateNewProducts();
                    addProduct.AddProduct();
                    break;
                case 2:
                    DeleteProducts removeProduct = new DeleteProducts();
                    removeProduct.DeleteProduct();
                    break;
                case 3:
                    UpdateProducts changeProduct = new UpdateProducts();
                    changeProduct.ChangeProduct();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Returning to main menu in:");
                    for (int i = 3; i > 0; i--)
                    {
                        Console.Write($"{i}... ");
                        Thread.Sleep(750);
                    }
                    Console.Clear();
                    ShowMenu.ShowMainMenu();
                    break;

            }
        }
    }
}
