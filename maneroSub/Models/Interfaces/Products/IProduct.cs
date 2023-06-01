namespace maneroSub.Models.Interfaces.Products
{
    public interface IProduct
    {
        string? Description { get; set; }
        int? Id { get; set; }
        string? Name { get; set; }
        decimal? Price { get; set; }
    }
}