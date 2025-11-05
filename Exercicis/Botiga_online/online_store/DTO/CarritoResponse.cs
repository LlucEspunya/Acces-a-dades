using Store.Model;

namespace Store.DTO;

public record CarritoResponse(Guid ID, string name) 
{
    public static CarritoResponse FromCarrito(Carrito carrito)   
    {
        return new CarritoResponse(carrito.ID, carrito.name);
    }
}