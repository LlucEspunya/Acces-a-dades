using Store.Model;

namespace Store.DTO;

public record ProductFamilyRequest(string family, string desc) 
{
    // Guanyem CONTROL sobre com es fa la conversió

    public ProductFamily ToFamily(Guid ID)   // Conversió a model
    {
        return new ProductFamily
        {
            ID = ID,
            family = family,
            desc = desc
        };
    }
}