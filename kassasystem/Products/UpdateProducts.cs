
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
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("There is no file of products.");
                    Console.ReadLine();
                    return;
                }

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
                Console.WriteLine("1. Name\n2. Price Type\n3. Price");
                var partToChange = Console.ReadLine();
                List<Product> toTakeInVariables = new List<Product>();
                switch (partToChange)
                {
                    case "1":
                        Console.Clear();
                        Console.Write($"Current name is {productParts[1]}. Please type the new name: ");
                        var newProductName = Console.ReadLine();
                        productParts[1] = newProductName;
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write($"{productParts[1]} current price type is {productParts[2]}. Please type the new price type: ");
                        var newProductPriceType = Console.ReadLine();
                        productParts[2] = newProductPriceType;
                        break;
                    case "3":
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
            ShowMenu.ShowMainMenu();
        }
    }
}


