using Store.Repository;
using Store.Model;
using Store.Services;
using Store.DTO;
using Store.Common;
// using System.Net.Cache;

namespace Store.Endpoints;

public static class EndpointsProductFamily
{
    public static void MapFamilyEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        app.MapGet("/Familias", () =>
        {
            List<ProductFamily>  productsFamily = ProductFamilyADO.GetAll(dbConn);
            List<ProductFamilyResponse> productFamilyResponses = new List<ProductFamilyResponse>();
            foreach (ProductFamily productFamily in productsFamily) 
            {
                productFamilyResponses.Add(ProductFamilyResponse.FromFamily(productFamily));
            }
            
            return Results.Ok(productFamilyResponses);
        });

        // GET Product by id
        app.MapGet("/Familias/{ID}", (Guid ID) =>
        {
            ProductFamily productFamily = ProductFamilyADO.GetById(dbConn, ID);

            return productFamily is not null
                ? Results.Ok(ProductFamilyResponse.FromFamily(productFamily))
                : Results.NotFound(new { message = $"Carrito with ID {ID} not found." });

        });

        // POST /products
        app.MapPost("/Familias", (ProductFamilyRequest request) =>
        {
            Guid ID;
            ID = Guid.NewGuid();
            ProductFamily productFamily = request.ToFamily(ID);
            ProductFamilyADO.Insert(dbConn, productFamily);

            return Results.Created($"/Familias/{productFamily.ID}", ProductFamilyResponse.FromFamily(productFamily));
        });
    }
}

// public record CarritoRequest(string ID, string name); 