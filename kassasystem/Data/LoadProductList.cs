using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;

namespace kassasystem.Data
{
    internal class LoadProductList
    {
        public static List<Product> ProductListOutput()
        {
            string filePath = "../../Productsfiles/ProductList.csv";

            List<Product> productList = new List<Product>();
            string[] products = File.ReadAllLines(filePath);

            foreach (var product in products)
            {
                if (string.IsNullOrWhiteSpace(product))
                    continue;

                var part = product.Split(';');
                if (product.Length < 5)
                    continue;

                bool isAvailable = true;
                bool.TryParse(part[4], out isAvailable);

                productList.Add(new Product
                {
                    ProductID = int.Parse(part[0]),
                    ProductName = part[1],
                    ProductType = part[2],
                    ProductPrice = decimal.Parse(part[3]),
                    IsAvailable = isAvailable
                });
            }
            return productList;
        }

    }
}
