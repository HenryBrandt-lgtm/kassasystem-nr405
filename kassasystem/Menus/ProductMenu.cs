using System;
using System.Threading;

namespace kassasystem.Products
{
    internal static class ProductMenu
    {
        public static void ListOfProductOptions()
        {
            ShowProductList.ListOfProducts();

            ConsoleKeyInfo key;
            int option = 1;
            bool isSelected = false;
            string choiceIndicator = "\u001b[32m-> ";
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            Console.CursorVisible = false;

            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine("Choose an option:");
                Console.WriteLine($"{(option == 1 ? choiceIndicator : "   ")}1. \u001b[0mAdd new product");
                Console.WriteLine($"{(option == 2 ? choiceIndicator : "   ")}2. \u001b[0mRemove product");
                Console.WriteLine($"{(option == 3 ? choiceIndicator : "   ")}3. \u001b[0mUpdate a product");
                Console.WriteLine($"{(option == 4 ? choiceIndicator : "   ")}4. \u001b[0mGo back to main menu");


                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        option = option == 4 ? 1 : option + 1;
                        break;

                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 4 : option - 1;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }

            Console.CursorVisible = true;

            switch (option)
            {
                case 1:
                    AddNewProducts addProduct = new AddNewProducts();
                    addProduct.AddProduct();
                    break;
                case 2:
                    RemoveProducts removeProduct = new RemoveProducts();
                    removeProduct.Deleteproduct();
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
