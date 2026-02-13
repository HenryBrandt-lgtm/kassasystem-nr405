using System;
using System.IO;

namespace kassasystem
{
    internal class Receipt
    {
        
        
        private static int ReceiptNumber = 0;
        public string Date { get; set; }

        
        public Receipt()
        {
        }
        public void AddNewRecipt()
        {
            ReceiptNumber++;

            DateTime receiptTime = DateTime.Now;
            Date = receiptTime.ToString("yyyyMMdd");
            var filePath = $"../../Shopping/Receipts.csv";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("------------------------------");
                writer.WriteLine("Brandts frukt och grönt\n");
                writer.WriteLine($"Datum: RECEIPT_{Date}\n");
                writer.WriteLine($"Kvitto: Nr.{ReceiptNumber}\n");
            }
        }
        public void AddProductsToRecipt(decimal quantity, string name, decimal price)
        {
            var filePath = $"../../Shopping/Receipts.csv";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{quantity} {name}  {price}     {price * quantity}");
                
            }
        }
        public void AddReceiptEnd(decimal grandTotal)
        {
            var filePath = $"../../Shopping/Receipts.csv";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"\nTotal: {grandTotal}");
                writer.WriteLine("------------------------------");
            }
        }
    }
}
