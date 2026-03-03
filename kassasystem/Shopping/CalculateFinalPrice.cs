using kassasystem.Data;
using System.Linq;

namespace kassasystem.Shopping
{
    internal class CalculateFinalPrice
    {
        public static decimal FinalPriceCalculator(string productID, decimal originalPrice)
        {
            var campaignList = LoadCampaignList.CampaignListOutput();

            decimal finalPrice = originalPrice;

            foreach (var campaign in campaignList.Where(campaign => campaign.ProductId.ToString() == productID
                        && campaign.IsActive()))
            {
                finalPrice *= (1 - campaign.DiscountPercent / 100);
            }
            return finalPrice;
        }
    }
}
