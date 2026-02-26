using kassasystem.Campaigns;
using System;
using System.Threading;

namespace kassasystem.Menus
{
    internal class CampaignMenu
    {

        public static void ListOfCampaignOptions()
        {
            ShowCampaigns.ListOfCampaigns();

            var option1 = "Add new campaign";
            var option2 = "Remove campaign";
            var option3 = "Go back to main menu";

            KeyMenu optionOf3 = new KeyMenu(option1, option2, option3);
            ScrollMenu campaginMenu = new ScrollMenu();

            var option = campaginMenu.ScrollMenuOptionOf3WithoutExit(optionOf3);

            Console.CursorVisible = true;

            switch (option)
            {
                case 1:
                    AddNewCampaign addNewCampaign = new AddNewCampaign();
                    addNewCampaign.AddCampaign();
                    break;
                case 2:
                    RemoveCampaign removeCampaign = new RemoveCampaign();
                    removeCampaign.DeleteCampaign();
                    break;
                case 3:
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


