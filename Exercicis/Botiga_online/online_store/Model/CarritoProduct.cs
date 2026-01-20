namespace Store.Model;

public class CarritoProduct
{
    public Guid ID { get; set; }
    public Guid Carrito_id { get; set; } 

    public Guid Product_id { get; set; }

    public int Quantity { get; set; } 
};