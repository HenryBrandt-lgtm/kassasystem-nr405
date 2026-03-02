using kassasystem.BluePrints;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace kassasystem.Data
{
    internal class CampaignList
    {
        public static List<Campaign> CampaignListOutput()
        {
            string filePath = "../../Campaginfiles/CampaignList.csv";
            List<Campaign> campaginList = new List<Campaign>();

            var campaigns = File.ReadAllLines(filePath);

            foreach (string campaign in campaigns.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(campaign))
                    continue;

                var part = campaign.Split(';');

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
            return campaginList;
        }
    }
}
