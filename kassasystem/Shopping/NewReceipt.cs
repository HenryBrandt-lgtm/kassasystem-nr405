using System;
using System.IO;
using System.Linq;

namespace kassasystem
{
    internal class NewReceipt
    {               
        private static int ReceiptNumber;
        public string Date { get; set; }

        private static string filePath = "../../Shopping/Receipts.csv";

        public NewReceipt()
        {
        }
        
        public void AddNewRecipt()
        {
            ReceiptNumber++;

            DateTime receiptTime = DateTime.Now;
            Date = receiptTime.ToString("RECEIPT_yyyyMMdd");
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
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{quantity} {name}  {price}     {price * quantity}");
                
            }
        }
        public void AddReceiptEnd(decimal grandTotal)
        {
            decimal moms = grandTotal * 0.12m;
            decimal roundedMoms = Math.Round(moms, 2);
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"\nTotal: {grandTotal}");
                writer.WriteLine($"\nMoms: 12%\t{roundedMoms}");
                writer.WriteLine("------------------------------");
            }
        }
        public static void LoadLastReceiptNumber()
        {
            
            if (!File.Exists(filePath))
            {
                ReceiptNumber = 0;
                return;
            }

            string[] receiptArray = File.ReadAllLines(filePath);

            foreach (var line in receiptArray.Reverse())
            {
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

            
        }
    }
}
