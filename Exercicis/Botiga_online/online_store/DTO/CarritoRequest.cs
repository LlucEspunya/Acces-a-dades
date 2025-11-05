using Store.Model;

namespace Store.DTO;

public record CarritoRequest(string name) 
{
    // Guanyem CONTROL sobre com es fa la conversió

    public Carrito ToCarrito(Guid ID)   // Conversió a model
    {
        return new Carrito
        {
            ID = ID,
            name = name
        };
    }
}