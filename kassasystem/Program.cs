using kassasystem.BluePrints;
using kassasystem.Data;

namespace kassasystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateProductList.CheckProductList();
            CreateCampaignList.CheckCampaignList();
            LoadReceiptNumber.LoadLastReceiptNumber();
            ShowMenu.ShowMainMenu();
        }
    }
}
