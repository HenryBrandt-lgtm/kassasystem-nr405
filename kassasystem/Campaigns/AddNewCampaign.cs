using kassasystem.BluePrints;
using System;
using System.IO;

namespace kassasystem.Campaigns
{
    internal class AddNewCampaign
    {

        public void AddCampaign()
        {
            Console.Clear();
            string productFilePath = "../../Productsfiles/ProductList.csv";
            string campaginFilePath = "../../Campaginfiles/CampaignList.csv";
            while (true)
            {
                CreateCampaignList.CheckCampaignList();

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

                Console.Write("Enter discount percent: ");
                decimal discount = decimal.Parse(Console.ReadLine());

                Console.Write("Enter start date (yyyy-mm-dd): ");
                DateTime startDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter end date (yyyy-mm-dd): ");
                DateTime endDate = DateTime.Parse(Console.ReadLine());

                using (StreamWriter writer = new StreamWriter(campaginFilePath, true))
                {

                    writer.WriteLine($"{campaignName};{productParts[0]};{discount};{startDate};{endDate}");

                }
                Console.WriteLine("\nCampagin added! Press enter to return to main menu...");
                Console.ReadLine();
                break;
            }
            Console.Clear();
            ShowMenu.ShowMainMenu();
        }
    }
}



