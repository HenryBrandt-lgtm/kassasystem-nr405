using kassasystem.BluePrints;
using System;
using System.Collections.Generic;
using System.IO;
namespace kassasystem.Campaigns
{
    internal class ShowCampaigns
    {

        public static void ListOfCampaigns()
        {

            Console.Clear();
            string filePath = "../../Campaginfiles/CampaignList.csv";
            if (!File.Exists(filePath))
            {
                CreateCampaignList.CheckCampaignList();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n~~~~Brandts frukt och grönt!~~~~\n");
            Console.ResetColor();
            List<Campaign> campaginList = new List<Campaign>();
            var campaigns = File.ReadAllLines(filePath);

            for (int i = 1; i < campaigns.Length; i++)
            {
                var part = campaigns[i].Split(';');

                if (part.Length < 5)
                    continue;

                campaginList.Add(new Campaign
                {
                    CampaignName = (part[0]),
                    ProductId = int.Parse(part[1]),
                    DiscountPercent = decimal.Parse(part[2]),
                    StartDate = DateTime.Parse(part[3]),
                    EndDate = DateTime.Parse(part[4])
                });
            }

            foreach (var campaign in campaginList)
            {
                Console.WriteLine($"{"",3}{campaign.CampaignName} ProductID: {campaign.ProductId} " +
                    $"Discount%: {campaign.DiscountPercent} StartDate: {campaign.StartDate.ToShortDateString()} EndDate:{campaign.EndDate.ToShortDateString()}");
            }
            Console.WriteLine();
        }

    }
}



