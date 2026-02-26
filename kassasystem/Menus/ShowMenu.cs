using kassasystem.Campaigns;
using kassasystem.Menus;
using kassasystem.Products;
using System;
using System.Threading;

namespace kassasystem
{
    internal class ShowMenu
    {
        public static void ShowMainMenu()
        {
            
            string option1 = "Start New Transaction";
            string option2 = "View and add/remove/update products";
            string option3 = "View and change campaigns";

            KeyMenu optionsOf3 = new KeyMenu(option1, option2, option3);
            ScrollMenu mainMenu = new ScrollMenu();

            TextOutputs.Header();
            var option = mainMenu.ScrollMenuOptionOf3(optionsOf3);
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
                    CampaignMenu.ListOfCampaignOptions();
                    break;
                case 4:
                    Console.WriteLine("Terminating...");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}

