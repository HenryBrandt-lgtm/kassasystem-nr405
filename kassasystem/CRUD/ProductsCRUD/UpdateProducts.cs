
using System;
using System.Collections.Generic;
using System.IO;

namespace kassasystem.Products
{
    internal class UpdateProducts
    {
        public void ChangeProduct()
        {
            Console.Clear();
            string filePath = "../../Productsfiles/ProductList.csv";
            while (true)
            {
                CreateProductList.CheckProductList();

                string[] products = File.ReadAllLines(filePath);

                if (products.Length <= 0)
                {
                    Console.WriteLine("The productlist is empty.");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("Products:");
                for (int i = 0; i < products.Length; i++)
                {
                    Console.WriteLine($"{i}: {products[i]}".Replace(";", " "));
                }

                Console.Write("\nChoose product to change: ");
                if (!int.TryParse(Console.ReadLine(),
                    out int prodcutOfChoice) || prodcutOfChoice < 0 || prodcutOfChoice >= products.Length)
                {
                    Console.WriteLine("Unvallid input. Press enter to try again.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                string[] productParts = products[prodcutOfChoice].Split(';');
                Console.WriteLine("what part of the product do you want to change?");

                var productOption1 = "Name";
                var productOption2 = "Price Type";
                var productOption3 = "Price";
                var productOption4 = "Availability";
                KeyMenu menuOf4 = new KeyMenu(productOption1, productOption2, productOption3, productOption4);
                ScrollMenu chooseWhatToChange = new ScrollMenu();

                var partToChange = chooseWhatToChange.ScrollMenuOptionOf4WithoutExit(menuOf4);

                List<Product> toTakeInVariables = new List<Product>();
                switch (partToChange)
                {
                    case 1:
                        Console.Clear();
                        Console.Write($"Current name is {productParts[1]}. Please type the new name: ");
                        var newProductName = Console.ReadLine();
                        productParts[1] = newProductName;
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write($"{productParts[1]} current price type is {productParts[2]}. Please type the new price type: ");
                        var newProductPriceType = Console.ReadLine();
                        productParts[2] = newProductPriceType;
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write($"{productParts[1]} current price is {productParts[3]}kr. Please type the new price: ");
                        if (!decimal.TryParse(Console.ReadLine(),
                            out decimal newProductPrice) || newProductPrice <= 0)
                        {
                            Console.WriteLine("Invalid price!");
                            Console.WriteLine("Press space to try again");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }
                        productParts[3] = newProductPrice.ToString();
                        break;
                    case 4:
                        Console.Clear();
                        var availabillity = "";
                        if (productParts[4] == "true")
                        {
                            Console.WriteLine("Please go to Delete products to inactivate the product.");
                            Console.ReadKey();
                            break;
                        }
                        else if (productParts[4] == "false")
                            availabillity = "not available";
                        else
                            availabillity = "undecisive";

                        Console.Write($"{productParts[1]} is currently {availabillity}.\nDo you want to set it to Aailable?\n");
                        var availabillityOption1 = "yes";
                        var availabillityOption2 = "no";
                        KeyMenu menuOf2 = new KeyMenu(availabillityOption1, availabillityOption2);
                        ScrollMenu availableOrNot = new ScrollMenu();
                        var yesOrNo = availableOrNot.ScrollMenuOptionOf2(menuOf2);
                        if (yesOrNo == 1)
                        {
                            productParts[4] = "true";
                            Console.WriteLine($"{productParts[1]} is now available. Press any key to continue.");
                            Console.ReadKey();
                            break;
                        }
                        else if (yesOrNo == 2)
                        {
                            productParts[4] = "false";
                            Console.WriteLine($"{productParts[1]} is now unavailable. Press any key to continue.");
                            Console.ReadKey();
                            break;
                        }
                        break;

                    default:
                        Console.WriteLine("Please pick a valid option. Press space to try again.");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                }
                products[prodcutOfChoice] = string.Join(";", productParts);

                File.WriteAllLines(filePath, products);


                Console.WriteLine("\nProduct changed! Press enter to return to main menu...");
                Console.ReadLine();
                break;
            }
            Console.Clear();
            MainMenu.ShowMainMenu();
        }
    }
}


