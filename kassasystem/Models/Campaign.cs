using System;

namespace kassasystem.BluePrints
{
    internal class Campaign
    {
        public string CampaignName { get; set; }
        public int ProductId { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsActive()
        {
            return DateTime.Now >= StartDate && DateTime.Now <= EndDate;
        }
    }
}
