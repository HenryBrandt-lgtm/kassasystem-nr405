using kassasystem.BluePrints;

namespace kassasystem
{
    public class Product : IAvailableProduct
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public decimal ProductPrice { get; set; }
        public bool IsAvailable { get; set; }

        private static int NextID = 300;
        public Product()
        {
            ProductID = NextID++;
        }
        
    }
}
