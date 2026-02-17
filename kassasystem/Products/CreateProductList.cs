using System.IO;

namespace kassasystem
{
    internal class CreateProductList
    {
        public static void CeckProductList()
        {
            string filePath = "../../Products/ProductList.csv";

            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.WriteLine("300;Mandariner;kr/st;2,25");
                    writer.WriteLine("301;Vindruvor;kr/st;49");
                    writer.WriteLine("302;Päron;kr/kg;18,90");
                    writer.WriteLine("303;Bananer;kr/kg;29,90");
                    writer.WriteLine("304;Meloner;kr/st;45,50");
                    writer.WriteLine("305;Apelsiner;kr/kg;39,90");
                    writer.WriteLine("306;Äpplen;kr/kg;29,90");
                    writer.WriteLine("307;Kastanjer;kr/kg;25");
                }

            }
        }
    }
}
