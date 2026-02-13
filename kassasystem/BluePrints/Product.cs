namespace kassasystem
{
    internal class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public decimal ProductPrice { get; set; }

        private static int NextID = 300;
        public Product()
        {
            ProductID = NextID++;
        }
    }
}
