using kassasystem.BluePrints;
using System;
using System.Globalization;
using System.IO;

namespace kassasystem.Campaigns
{
    internal class CreatNewCampaign
    {

        public void AddCampaign()
        {
            Console.Clear();
            string productFilePath = "../../Productsfiles/ProductList.csv";
            string campaginFilePath = "../../Campaginfiles/CampaignList.csv";
            while (true)
            {
                CreateCampaignPath.CheckCampaignList();

                string[] products = File.ReadAllLines(productFilePath);

                if (products.Length <= 1)
                {
                    Console.WriteLine("The productlist is empty. You cant make campaigns if there's no products to give campaigns");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("Products:");
                for (int i = 0; i < products.Length; i++)
                {
                    Console.WriteLine($"{i}: {products[i]}".Replace(";", " "));
                }

                Console.Write("\nChoose product you want to give a Campagin: ");
                if (!int.TryParse(Console.ReadLine(),
                    out int prodcutOfChoice) || prodcutOfChoice < 0 || prodcutOfChoice >= products.Length)
                {
                    Console.WriteLine("Unvallid input. Press enter to try again.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                string[] productParts = products[prodcutOfChoice].Split(';');

                Console.Write("Enter campaign name: ");
                string campaignName = Console.ReadLine();
                if (campaignName == null)
                    campaignName = "Campaign";


                Console.Write("Enter discount percent: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal discount) || discount < 0 || discount > 50)
                {
                    Console.WriteLine("Unvallid input. \nOnly numbers are needed and the discount cant be lowe than 0% " +
                        "or higher than 50%. \nPress space to try again.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                bool settingStartDate = true;
                DateTime startDate = default;
                while (settingStartDate)
                {
                    Console.Write("Enter start date (yyyy-mm-dd): ");
                    if (DateTime.TryParseExact(Console.ReadLine(),
                        "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
                    {
                        if (startDate < DateTime.Today)
                            Console.WriteLine("Date cant be older than todays date");
                        else
                            settingStartDate = false;
                    }
                    else
                        Console.WriteLine("Invalid input, please use yyyy-MM-dd");

                }

                bool settingEndDate = true;
                DateTime endDate = default;
                while (settingEndDate)
                {
                    Console.Write("Enter end date (yyyy-MM-dd): ");
                    if (DateTime.TryParseExact(Console.ReadLine(),
                        "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
                    {
                        if (endDate < startDate)
                            Console.WriteLine("The last date of the campaign cant be before the start.");
                        else
                            settingEndDate = false;
                    }
                    else
                        Console.WriteLine("Invalid input, please use yyyy-MM-dd");
                }
                using (StreamWriter writer = new StreamWriter(campaginFilePath, true))
                {
                    writer.WriteLine($"{campaignName};{productParts[0]};{discount};{startDate};{endDate}");
                }
                Console.WriteLine("\nCampaign created! Press enter to return to main menu...");
                Console.ReadLine();
                break;
            }
            Console.Clear();
            MainMenu.ShowMainMenu();
        }
    }
}



