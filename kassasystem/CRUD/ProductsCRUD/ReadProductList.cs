using kassasystem.Data;
using System;
using System.IO;
using System.Linq;
namespace kassasystem
{
    internal class ReadProductList
    {
        public static void ListOfProducts()
        {

            Console.Clear();
            string filePath = "../../Productsfiles/ProductList.csv";
            if (File.Exists(filePath))
            {
                CreateProductList.CheckProductList();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n~~~~Brandts frukt och grönt!~~~~\n");
                Console.ResetColor();

                var productList = LoadProductList.ProductListOutput();

                var availableProducts = productList.Where(p => p.IsAvailable).ToList();

                if (availableProducts.Count == 0)
                {
                    Console.WriteLine("There are no available products");
                    return;
                }

                foreach (var product in availableProducts)
                {
                    Console.WriteLine($"{"",3}{product.ProductID} {product.ProductName} {product.ProductType} {product.ProductPrice}");
                }
                Console.WriteLine();
            }

        }
    }
}
