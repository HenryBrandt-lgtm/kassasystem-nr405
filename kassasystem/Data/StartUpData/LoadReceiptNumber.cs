using System.IO;
using System.Linq;

namespace kassasystem.Data
{

    internal class LoadReceiptNumber
    {
        private static int ReceiptNumber;
        public static void LoadLastReceiptNumber()
        {
            string folderPath = "../../Receipts/";

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

            string latestFile = files.OrderByDescending(r => r).FirstOrDefault();

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
        public static int GetNextReceiptNumber()
        {
            ReceiptNumber++;
            return ReceiptNumber;
        }
    }
}
