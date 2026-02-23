using System;
using System.Globalization;
using System.IO;

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
                int maxID = 0;

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
                decimal price = decimal.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);

                Console.Write("\nType the products price type(kr/kg or kr/st): ");
                var type = Console.ReadLine().Trim();


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
