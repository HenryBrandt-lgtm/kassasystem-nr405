using kassasystem.Campaigns;
using System;
using System.Threading;

namespace kassasystem.Menus
{
    internal class CampaignMenu
    {

        public static void ListOfCampaignOptions()
        {
            ReadCampaigns.ListOfCampaigns();

            var option1 = "Add new campaign";
            var option2 = "Delete campaign";
            var option3 = "Update campaign";
            var option4 = "Go back to main menu";

            KeyMenu optionOf4 = new KeyMenu(option1, option2, option3, option4);
            ScrollMenu campaginMenu = new ScrollMenu();

            var option = campaginMenu.ScrollMenuOptionOf4WithoutExit(optionOf4);

            Console.CursorVisible = true;

            switch (option)
            {
                case 1:
                    CreatNewCampaign addNewCampaign = new CreatNewCampaign();
                    addNewCampaign.AddCampaign();
                    break;
                case 2:
                    DeleteCampaigns removeCampaign = new DeleteCampaigns();
                    removeCampaign.DeleteCampaign();
                    break;

                case 3:
                    UpdateCampaign updateCampaign = new UpdateCampaign();
                    updateCampaign.ChangeCampaign();
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


