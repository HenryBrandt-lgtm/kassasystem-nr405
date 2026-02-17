using kassasystem.Products;
using System;
using System.Threading;

namespace kassasystem
{
    internal class ShowMenu
    {
        public static void ShowMainMenu()
        {                    
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

                Console.WriteLine($"   Welcome to the Brandts frukt och \u001b[32mgrönt!\u001b[0m\n");
                Console.WriteLine($"{(option == 1 ? choiceIndicator : "   ")}\u001b[0mStart New Transaction");
                Console.WriteLine($"{(option == 2 ? choiceIndicator : "   ")}\u001b[0mView and add/remove/change products");
                Console.WriteLine($"{(option == 3 ? choiceIndicator : "   ")}\u001b[0mView and change campaigns");
                Console.WriteLine($"{(option == 4 ? choiceIndicator : "   ")}\u001b[0mExit");

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
                    NewReceipt.LoadLastReceiptNumber();
                    var transaction = new Transaction();
                    transaction.NewTransaction();
                    break;
                case 2:                   
                    ProductMenu.ListOfProductOptions();
                    break;
                case 3:
                    // View and change campaigns
                    break;
                case 4:
                    Console.WriteLine("Terminating...");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}

