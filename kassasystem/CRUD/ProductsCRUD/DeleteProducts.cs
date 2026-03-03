using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kassasystem.Products
{
    internal class DeleteProducts
    {
        public void DeleteProduct()
        {
            Console.Clear();
            string filePath = "../../Productsfiles/ProductList.csv";
            while (true)
            {
                CreateProductList.CheckProductList();

                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length <= 0)
                {
                    Console.WriteLine("The productlist is empty.");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("Products:");
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine($"{i}: {lines[i]}".Replace(";", " "));
                }

                Console.Write("\nChoose product to remove: ");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice >= lines.Length)
                {
                    Console.WriteLine("Unvallid input. Press enter to try again.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                List<string> productList = lines.ToList();

                var parts = productList[choice].Split(';');
                parts[4] = "false"; 
                productList[choice] = string.Join(";", parts);
                File.WriteAllLines(filePath, productList);

                Console.WriteLine("\nProduct Inactive! Press enter to return to main menu...");
                Console.ReadLine();
                break;
            }
            Console.Clear();
            ShowMenu.ShowMainMenu();
        }
    }
}
