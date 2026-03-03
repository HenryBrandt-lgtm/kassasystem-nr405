using kassasystem.Data;
using System.Linq;

namespace kassasystem.Shopping
{
    internal class CalculateFinalPrice
    {
        public static decimal FinalPriceCalculator(int productID, decimal originalPrice)
        {
            var campaignList = LoadCampaignList.CampaignListOutput();

            decimal finalPrice = originalPrice;

            foreach (var campaign in campaignList.Where(campaign => campaign.ProductId == productID
                        && campaign.IsActive()))
            {
                finalPrice *= (1 - campaign.DiscountPercent / 100);
            }
            return finalPrice;
        }
    }
}
