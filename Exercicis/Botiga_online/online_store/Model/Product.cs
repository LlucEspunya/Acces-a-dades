namespace Store.Model;

public class Product
{
    public Guid ID { get; set; }
    public string Name { get; set; } = "";
    public float Price { get; set; } 
    public Guid Family_id { get; set; }
}