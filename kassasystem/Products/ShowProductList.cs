using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace kassasystem
{
    internal class ShowProductList
    {
        public static void ListOfProducts()
        {

            Console.Clear();
            string filePath = "../../Products/ProductList.csv";
            if (File.Exists(filePath))
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n~~~~Brandts frukt och grönt!~~~~\n");
                Console.ResetColor();
                List<Product> productList = new List<Product>();
                string[] products = File.ReadAllLines(filePath);

                foreach (var product in products)
                {

                    var part = product.Split(';');
                    productList.Add(new Product
                    {
                        ProductID = int.Parse(part[0]),
                        ProductName = part[1],
                        ProductType = part[2],
                        ProductPrice = decimal.Parse(part[3])
                    });
                }
                
                foreach (var product in productList)
                {
                    Console.WriteLine($"{"", 3}{product.ProductID} {product.ProductName} {product.ProductType} {product.ProductPrice}");
                }
                Console.WriteLine();
            }

        }
    }
}
