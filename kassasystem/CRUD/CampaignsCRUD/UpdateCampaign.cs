using kassasystem.BluePrints;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
namespace kassasystem.Campaigns
{
    internal class UpdateCampaign
    {
        public void ChangeCampaign()
        {
            Console.Clear();
            string filePath = "../../Campaginfiles/CampaignList.csv";
            while (true)
            {
                CreateCampaignPath.CheckCampaignList();

                string[] campaigns = File.ReadAllLines(filePath);

                if (campaigns.Length <= 1)
                {
                    Console.WriteLine("The Campaignlist is empty.");
                    Console.ReadLine();
                    return;
                }

                for (int i = 1; i < campaigns.Length; i++)
                {
                    Console.WriteLine($"{i}: {campaigns[i]}".Replace(";", " "));
                }

                Console.Write("\nChoose campaign to change: ");
                if (!int.TryParse(Console.ReadLine(),
                    out int campaignOfChoice) || campaignOfChoice < 0 || campaignOfChoice >= campaigns.Length)
                {
                    Console.WriteLine("Unvallid input. Press enter to try again.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                string[] campaignParts = campaigns[campaignOfChoice].Split(';');
                Console.WriteLine("what part of the campaign do you want to change?");

                var option1 = "Name";
                var option2 = "Discount";
                var option3 = "Start date";
                var option4 = "End date";
                KeyMenu menuOf4 = new KeyMenu(option1, option2, option3, option4);
                ScrollMenu chooseWhatToChange = new ScrollMenu();

                var partToChange = chooseWhatToChange.ScrollMenuOptionOf4WithoutExit(menuOf4);

                List<Product> toTakeInVariables = new List<Product>();
                DateTime startDate = default;

                switch (partToChange)
                {
                    case 1:
                        Console.Clear();
                        Console.Write($"Current name is {campaignParts[0]}. Please type the new name: ");
                        var newCampaignName = Console.ReadLine();
                        if (newCampaignName == null)
                            newCampaignName = "Campaign";
                        campaignParts[1] = newCampaignName;
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write($"{campaignParts[0]} current discount is {campaignParts[2]}. Please type the new discount: ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal discount) || discount < 0 || discount > 50)
                        {
                            Console.WriteLine("Unvallid input. Only numbers are needed and the discount cant be lowe than 0% " +
                                "or higher than 50%. Press space to try again.");
                        }
                        campaignParts[2] = discount.ToString();
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write($"{campaignParts[0]} current start date is {campaignParts[3]}. Please type the new start date: ");
                        if (DateTime.TryParseExact(Console.ReadLine(),
                        "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
                        {
                            if (startDate < DateTime.Today)
                                Console.WriteLine("Date cant be older than todays date");
                            else
                            {
                                campaignParts[3] = startDate.ToString();
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, please use yyyy-MM-dd");
                            continue;
                        }
                        break;

                    case 4:
                        Console.Clear();
                        DateTime endDate = default;
                        Console.Write($"{campaignParts[0]} current end date is {campaignParts[4]}. Please type the new end date: ");
                        if (DateTime.TryParseExact(Console.ReadLine(),
                        "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
                        {
                            if (endDate < startDate)
                                Console.WriteLine("Date cant be older than todays date");
                            else
                            {
                                campaignParts[4] = endDate.ToString();
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, please use yyyy-MM-dd");
                            continue;
                        }
                        break;

                    default:
                        Console.WriteLine("Please pick a valid option. Press space to try again.");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                }
                campaigns[campaignOfChoice] = string.Join(";", campaignParts);

                File.WriteAllLines(filePath, campaigns);


                Console.WriteLine("\nCampaign changed! Press enter to return to main menu...");
                Console.ReadLine();
                break;
            }
            Console.Clear();
            MainMenu.ShowMainMenu();
        }
    }
}





