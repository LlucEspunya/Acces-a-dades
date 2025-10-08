using Store.Repository;
//using Store.Services;
using Store.Model;
using Store.Services;

namespace Store.Endpoints;

public static class Endpoints
{
    public static void MapCarritoEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // GET /products
        app.MapGet("/Carritos", () =>
        {
            List<Carrito> Carritos = CarritoADO.GetAll(dbConn);
            return Results.Ok(Carritos);
        });

        // GET Product by id
        app.MapGet("/Carritos/{ID}", (Guid ID) =>
        {
            Carrito carrito = CarritoADO.GetById(dbConn, ID);

            return carrito is not null
                ? Results.Ok(carrito)
                : Results.NotFound(new { message = $"Carrito with ID {ID} not found." });

        });

        // POST /products
        app.MapPost("/Carritos", (CarritoRequest req) =>
        {
            Carrito carrito = new Carrito
            {
                ID = Guid.NewGuid(),
                name = req.name,
            };

            CarritoADO.Insert(dbConn, carrito);

            return Results.Created($"/Carritos/{carrito.ID}", carrito);
        });
    }
}

public record CarritoRequest(string ID, string name); 