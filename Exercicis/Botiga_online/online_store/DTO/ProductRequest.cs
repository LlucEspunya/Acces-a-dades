using Store.Model;

namespace Store.DTO;

public record ProductRequest(string Name, float Price, Guid Family_id) 
{

    public Product ToProduct(Guid ID)   // Conversió a model
    {
        return new Product
        {
            ID = ID,
            Name = Name,
            Price = Price,
            Family_id = Family_id
        };
    }
}