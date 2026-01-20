using Store.Model;

namespace Store.DTO;

public record ProductResponse(Guid ID, string Name, float Price) 
{
    public static ProductResponse FromProduct(Product product)   
    {
        return new ProductResponse(product.ID, product.Name, product.Price);
    }
}