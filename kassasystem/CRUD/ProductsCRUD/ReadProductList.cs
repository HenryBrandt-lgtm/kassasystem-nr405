using kassasystem.Data;
using System;
using System.Collections.Generic;
using System.IO;
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

                var productList = ProductList.ProductListOutput();

                foreach (var product in productList)
                {
                    Console.WriteLine($"{"",3}{product.ProductID} {product.ProductName} {product.ProductType} {product.ProductPrice}");
                }
                Console.WriteLine();
            }

        }
    }
}
