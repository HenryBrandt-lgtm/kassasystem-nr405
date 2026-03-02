using kassasystem.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kassasystem
{
    internal class NewReceipt
    {               
        public void CreateReceipt(List<ShoppingBasket> basket)
        {
            int receiptNumber = LoadReceiptNumber.GetNextReceiptNumber();
            string date = DateTime.Now.ToString("yyyyMMdd");
            string filePath = $"../../Receipts/RECEIPT_{date}.csv";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("------------------------------");
                writer.WriteLine("Brandts frukt och grönt");
                writer.WriteLine($"{date}");
                writer.WriteLine($"Kvitto: Nr.{receiptNumber}");

                decimal grandTotal = 0;

                foreach (var item in basket)
                {
                    grandTotal += item.Total;
                    writer.WriteLine($"{item.Quantity} {item.Name}  {item.Price}  {item.Total}");
                }

                decimal moms = Math.Round(grandTotal * 0.12m, 2);
                writer.WriteLine($"Total: {grandTotal}");
                writer.WriteLine($"Moms: 12%  {moms}");
                writer.WriteLine("------------------------------");
            }
        }        
    }
}
