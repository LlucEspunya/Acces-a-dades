using Store.Repository;
using Store.Model;
using Store.Services;
using Store.DTO;
using Store.Common;
// using System.Net.Cache;

namespace Store.Endpoints;

public static class EndpointsCarrito
{
    public static void MapCarritoEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        app.MapGet("/Carritos", () =>
        {
            List<Carrito>  carritos = CarritoADO.GetAll(dbConn);
            List<CarritoResponse> carritosResponse = new List<CarritoResponse>();
            foreach (Carrito carrito in carritos) 
            {
                carritosResponse.Add(CarritoResponse.FromCarrito(carrito));
            }
            
            return Results.Ok(carritosResponse);
        });

        // GET Product by id
        app.MapGet("/Carritos/{ID}", (Guid ID) =>
        {
            Carrito carrito = CarritoADO.GetById(dbConn, ID);

            return carrito is not null
                ? Results.Ok(CarritoResponse.FromCarrito(carrito))
                : Results.NotFound(new { message = $"Carrito with ID {ID} not found." });

        });

        // POST /products
        app.MapPost("/Carritos", (CarritoRequest request) =>
        {
            Guid ID;
            ID = Guid.NewGuid();
            Carrito carrito = request.ToCarrito(ID);
            CarritoADO.Insert(dbConn, carrito);

            return Results.Created($"/Carritos/{carrito.ID}", CarritoResponse.FromCarrito(carrito));
        });
    }
}

// public record CarritoRequest(string ID, string name); 