using Microsoft.EntityFrameworkCore;
using Servidor.Contenido;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MiConexionLocalSQLite")));
var app = builder.Build();
app.MapGet("api/v1/plato", async (AppDbContext contexto) => { 
    var platos = await contexto.Platos.ToListAsync();
    return Results.Ok(platos);
});
app.MapPost("api/v1/plato", async (AppDbContext contexto, Servidor.Models.Plato plato) => {
    var elementos = await contexto.Platos.AddAsync(plato);
    await contexto.SaveChangesAsync();
    return Results.Created($"/api/v1/plato/{plato.Id}", plato);// HTTP 201, URI y el objeto
});
app.MapPut("api/v1/plato/{id}", async (AppDbContext contexto, int id, Servidor.Models.Plato platoActualizado) => {
    var platoExistente = await contexto.Platos.FindAsync(id);
    if (platoExistente == null)
    {
        return Results.NotFound();
    }
    platoExistente.Nombre = platoActualizado.Nombre;
    await contexto.SaveChangesAsync();
    return Results.NoContent(); // HTTP 204
});
app.MapDelete("api/v1/plato/{id}", async (AppDbContext contexto, int id) => {
    var platoExistente = await contexto.Platos.FindAsync(id);
    if (platoExistente == null)
    {
        return Results.NotFound();
    }
    contexto.Platos.Remove(platoExistente);
    await contexto.SaveChangesAsync();
    return Results.NoContent(); // HTTP 204
});
app.Run();