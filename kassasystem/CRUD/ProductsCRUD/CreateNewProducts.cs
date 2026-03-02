using System;
using System.Globalization;
using System.IO;

namespace kassasystem
{
    internal class CreateNewProducts
    {
        public void AddProduct()
        {

            Console.Clear();
            string filePath = "../../Productsfiles/ProductList.csv";
            int newID = 300;
            CreateProductList.CheckProductList();

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
                ReadProductList.ListOfProducts();

                Console.Write("To add a new product. \nFirst type the products name: ");
                var name = Console.ReadLine().Trim();
                if (name == null)
                    name = "Product";

                Console.Write("\nType the products price: ");
                if (!decimal.TryParse(Console.ReadLine()?.Replace(',', '.'),
                    NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price))
                {
                    Console.WriteLine("Unvalid input of price.");
                    Console.ReadKey();
                    continue;
                }
                var option1 = "kr/kg";
                var option2 = "kr/st";
                string type = "";
                Console.WriteLine("\nType 1 or 2 followed by enter to choose products price type:");
                KeyMenu optionOf2 = new KeyMenu(option1, option2);
                ScrollMenu productType = new ScrollMenu();

                var option = productType.ScrollMenuOptionOf2WithoutExit(optionOf2);
                if (option == 1)
                    type = option1;

                else if (option == 2)
                    type = option2;

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
                Console.WriteLine($"\n{newProduct.ProductName} added with ID: {newID}\nPlease press space to return to the main menu");
                Console.ReadKey();
                addingNewProducts = false;

            }
            Console.Clear();
            ShowMenu.ShowMainMenu();

        }
    }
}
