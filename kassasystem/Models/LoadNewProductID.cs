using System.IO;
namespace kassasystem.Models
{
    internal class LoadNewProductID
    {
        public static int GetNextPorductID()
        {
            string filePath = "../../Productsfiles/ProductList.csv";
            int newID = 300;

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
            return newID;

        }
    }
}
