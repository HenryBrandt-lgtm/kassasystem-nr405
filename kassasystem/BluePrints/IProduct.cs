namespace kassasystem.BluePrints
{
    public interface IProduct
    {
        int ProductID { get; set; }
        string ProductName { get; set; }
        string ProductType { get; set; }
        decimal ProductPrice { get; set; }
    }
}
