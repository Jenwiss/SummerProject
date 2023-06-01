namespace maneroSub.Models.Interfaces.Products
{
    public interface IProductSchema
    {
        string? Description { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
    }
}