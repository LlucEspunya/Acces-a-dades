using Store.Repository;
using Store.Model;
using Store.Services;
using Store.DTO;
using Store.Common;
// using System.Net.Cache;

namespace Store.Endpoints;

public static class EndpointsProduct
{
    public static void MapProductEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        app.MapGet("/Products", () =>
        {
            List<Product>  products = ProductADO.GetAll(dbConn);
            List<ProductResponse> productsResponse = new List<ProductResponse>();
            foreach (Product product in products) 
            {
                productsResponse.Add(ProductResponse.FromProduct(product));
            }
            
            return Results.Ok(productsResponse);
        });

        app.MapGet("/Products/{ID}", (Guid ID) =>
        {
            Product product = ProductADO.GetById(dbConn, ID);

            return product is not null
                ? Results.Ok(ProductResponse.FromProduct(product))
                : Results.NotFound(new { message = $"Product with ID {ID} not found." });
        });

        app.MapPost("/Products", (ProductRequest request) =>
        {
            Guid ID;
            ID = Guid.NewGuid();
            Product product = request.ToProduct(ID);
            ProductADO.Insert(dbConn, product);

            return Results.Created($"/Products/{product.ID}", ProductResponse.FromProduct(product));
        });
    }
}