using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;

namespace kassasystem
{
    internal class AddNewProducts
    {
        public void AddProduct()
        {

            Console.Clear();
            string filePath = "../../Productsfiles/ProductList.csv";
            int newID = 300;
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Couldnt find the file.");
                Console.ReadLine();
                return;
            }

            var lines = File.ReadAllLines(filePath);

            if (lines.Length != 0)
            {
                int maxID = 300;

                foreach (var line in lines)
                {
                    int id = int.Parse(line.Split(';')[0]);

                    if (id > maxID)
                        maxID = id;
                }

                newID = maxID + 1;
            }

            bool addingNewProducts = true;
            while (addingNewProducts)
            {
                ShowProductList.ListOfProducts();

                Console.Write("To add a new product. " +
                    "\nFirst type the products name: ");
                var name = Console.ReadLine().Trim();

                Console.Write("\nType the products price: ");
                if (!decimal.TryParse(Console.ReadLine().Replace(',', '.'), out decimal price))
                {
                    Console.WriteLine("Unvalid inout of price.");
                    Console.ReadKey();
                    continue;
                }
                //CultureInfo.InvariantCulture;

                Console.WriteLine("\nType 1 or 2 followed by enter to choose products price type: \n1 kr/kg  \n2 kr/st ");
                var type = Console.ReadLine().Trim();
                if (type != "1" || type != "2")
                {
                    Console.WriteLine("please only choose between 1 or 2");
                    Console.ReadKey();
                    continue;
                }

                Product newProduct = new Product
                {
                    ProductName = name,
                    ProductType = type,
                    ProductPrice = price
                };


                using (StreamWriter writer = new StreamWriter(filePath, true))
                {

                    writer.WriteLine($"{newID};{newProduct.ProductName};{newProduct.ProductType};{newProduct.ProductPrice}");

                }
                Console.WriteLine($"\n{newProduct.ProductName} added with ID: {newID}");
                Console.ReadKey();
                addingNewProducts = false;

            }
            Console.Clear();
            ShowMenu.ShowMainMenu();

        }
    }
}
