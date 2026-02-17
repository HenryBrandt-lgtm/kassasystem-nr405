using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kassasystem.Products
{
    internal class RemoveProducts
    {
        public void Deleteproduct()
        {
            Console.Clear();
            string filePath = "../../Products/ProductList.csv";
            while (true)
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("There is no file of products.");
                    Console.ReadLine();
                    return;
                }

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

                productList.RemoveAt(choice);

                File.WriteAllLines(filePath, productList);

                //sätta produkterna som inactive istället för raderade?

                Console.WriteLine("\nProduct deleted! Press enter to return to main menu...");
                Console.ReadLine();
                break;
            }
            Console.Clear();
            ShowMenu.ShowMainMenu();
        }
    }
}
