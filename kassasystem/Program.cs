using kassasystem.BluePrints;
using kassasystem.Data;

namespace kassasystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateProductList.CheckProductList();
            CreateCampaignPath.CheckCampaignList();
            LoadReceiptNumber.LoadLastReceiptNumber();
            MainMenu.ShowMainMenu();
        }
    }
}
