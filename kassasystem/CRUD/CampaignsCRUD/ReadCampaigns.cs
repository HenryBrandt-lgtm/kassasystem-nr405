using kassasystem.BluePrints;
using kassasystem.Data;
using System;
using System.IO;
namespace kassasystem.Campaigns
{
    internal class ReadCampaigns
    {

        public static void ListOfCampaigns()
        {

            Console.Clear();
            string filePath = "../../Campaginfiles/CampaignList.csv";
            if (!File.Exists(filePath))
            {
                CreateCampaignPath.CheckCampaignList();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n~~~~Brandts frukt och grönt!~~~~\n");
            Console.ResetColor();

            var listOfCampaigns = LoadCampaignList.CampaignListOutput();

            foreach (var campaign in listOfCampaigns)
            {
                Console.WriteLine($"{"",3}{campaign.CampaignName} ProductID: {campaign.ProductId} " +
                    $"Discount%: {campaign.DiscountPercent} StartDate: {campaign.StartDate.ToShortDateString()} EndDate:{campaign.EndDate.ToShortDateString()}");
            }
            Console.WriteLine();
        }

    }
}



