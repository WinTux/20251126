using Microsoft.EntityFrameworkCore;
using Servidor.Contenido;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MiConexionLocalSQLite")));
var app = builder.Build();
app.Run();