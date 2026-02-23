using System;
using System.IO;
using System.Linq;

namespace kassasystem
{
    internal class NewReceipt
    {               
        private static int ReceiptNumber;
        public string Date { get; set; }
        public NewReceipt()
        {
        }
        
        public void AddNewRecipt()
        {
            ReceiptNumber++;

            DateTime receiptTime = DateTime.Now;
            Date = receiptTime.ToString("yyyyMMdd");
            string filePath = $"../../Shopping/RECEIPT_{Date}.csv";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("------------------------------");
                writer.WriteLine("Brandts frukt och grönt\n");
                writer.WriteLine($"{Date}\n");
                writer.WriteLine($"Kvitto: Nr.{ReceiptNumber}\n");
            }
        }
        public void AddProductsToReceipt(decimal quantity, string name, decimal price)
        {
            DateTime receiptTime = DateTime.Now;
            Date = receiptTime.ToString("yyyyMMdd");
            string filePath = $"../../Shopping/RECEIPT_{Date}.csv";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{quantity} {name}  {price}     {price * quantity}");       
            }
        }
        public void AddReceiptEnd(decimal grandTotal)
        {
            decimal moms = grandTotal * 0.12m;
            DateTime receiptTime = DateTime.Now;
            Date = receiptTime.ToString("yyyyMMdd");
            string filePath = $"../../Shopping/RECEIPT_{Date}.csv";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"\nTotal: {grandTotal}");
                writer.WriteLine($"\nMoms: 12%\t{moms:f2}");
                writer.WriteLine("------------------------------");
            }
        }
        public static void LoadLastReceiptNumber()
        {
            string folderPath = "../../Shopping/";

            if (!Directory.Exists(folderPath)) 
            {
                Directory.CreateDirectory(folderPath);
                ReceiptNumber = 0;
                return;
            }

            string[] files = Directory.GetFiles(folderPath, "RECEIPT_*.csv");
            if (files.Length == 0)
            {
                ReceiptNumber = 0;
                return;
            }

            string latestFile = files.OrderByDescending(r => r).First();

            string[] receiptArray = File.ReadAllLines(latestFile);

            for (int i = receiptArray.Length - 1; i >= 0; i--)
            {
                string line = receiptArray[i].Trim();
                if (line.StartsWith("Kvitto: Nr.")) 
                {
                    string numberPart = line.Replace("Kvitto: Nr.", "").Trim();
                    if (int.TryParse(numberPart, out int lastReceiptNumber))
                    {
                        ReceiptNumber = lastReceiptNumber;
                        return;
                    }
                }
            }
            ReceiptNumber = 0;
        }
    }
}
