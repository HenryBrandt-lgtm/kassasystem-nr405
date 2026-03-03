using System;
using System.IO;

namespace kassasystem.BluePrints
{
    internal class CreateCampaignPath
    {

        private static string foldPath = "../../Campaginfiles";

        private static string filePath = $"{foldPath}/CampaignList.csv";
        public static void CheckCampaignList()
        {

            if (!Directory.Exists(foldPath))
            {
                Directory.CreateDirectory(foldPath);
            }

            if (!File.Exists(filePath))
            {

                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.WriteLine("CampaignName;ProductID;DiscountPercent;StartDate;EndDate");
                }

            }
            string[] products = File.ReadAllLines(filePath);

            if (products.Length <= 0)
            {
                Console.WriteLine("The campaginlist is empty.");
                Console.ReadLine();
                return;
            }
        }
    }
}
