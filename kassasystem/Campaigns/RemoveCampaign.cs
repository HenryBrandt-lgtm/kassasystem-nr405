using kassasystem.BluePrints;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace kassasystem.Campaigns
{
    internal class RemoveCampaign
    {

        public void DeleteCampaign()
        {
            Console.Clear();
            string filePath = "../../Campaginfiles/CampaignList.csv";
            while (true)
            {
                CreateCampaignList.CheckCampaignList();

                string[] campaigns = File.ReadAllLines(filePath);

                if (campaigns.Length <= 1)
                {
                    Console.WriteLine("The campaignlist is empty.");
                    Console.ReadLine();
                    return;
                }

                for (int i = 0; i < campaigns.Length; i++)
                {
                    Console.WriteLine($"{i}: {campaigns[i]}".Replace(";", " "));
                }

                Console.Write("\nChoose campaign to remove: ");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice <= 0 || choice >= campaigns.Length)
                {
                    Console.WriteLine("Unvallid input. Press space to try again.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                List<string> campaignList = campaigns.ToList();

                campaignList.RemoveAt(choice);

                File.WriteAllLines(filePath, campaignList);

                Console.WriteLine("\nCampaign deleted! Press enter to return to main menu...");
                Console.ReadLine();
                break;
            }
            Console.Clear();
            ShowMenu.ShowMainMenu();
        }
    }
}