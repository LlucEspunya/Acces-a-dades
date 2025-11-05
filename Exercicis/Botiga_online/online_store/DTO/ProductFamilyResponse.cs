using Store.Model;

namespace Store.DTO;

public record ProductFamilyResponse(Guid ID, string family, string desc) 
{
    public static ProductFamilyResponse FromFamily(ProductFamily productFamily)   
    {
        return new ProductFamilyResponse(productFamily.ID, productFamily.family, productFamily.desc);
    }
}