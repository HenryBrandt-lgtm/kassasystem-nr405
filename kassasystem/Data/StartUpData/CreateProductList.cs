using kassasystem.BluePrints;
using System;
using System.IO;

namespace kassasystem
{
    internal class CreateProductList
    {
        private static string foldPath = "../../Productsfiles";

        private static string filePath = $"{foldPath}/ProductList.csv";
        public static void CheckProductList()
        {

            if (!Directory.Exists(foldPath))
            {
                Directory.CreateDirectory(foldPath);
            }

            if (!File.Exists(filePath))
            {

                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.WriteLine("300;Tangerines;kr/st;5,25");
                    writer.WriteLine("301;Grapes;kr/st;49");
                    writer.WriteLine("302;Pears;kr/kg;18,90");
                    writer.WriteLine("303;Bananas;kr/kg;29,90");
                    writer.WriteLine("304;Melons;kr/st;45,50");
                    writer.WriteLine("305;Oranges;kr/kg;39,90");
                    writer.WriteLine("306;Apples;kr/kg;29,90");
                    writer.WriteLine("307;Chestnuts;kr/kg;25");
                }

            }
            string[] products = File.ReadAllLines(filePath);

            if (products.Length <= 0)
            {
                Console.WriteLine("The productlist is empty.");
                Console.ReadLine();
                return;
            }
        }
    }
}
