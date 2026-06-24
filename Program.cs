using ASP.NET_Core_Game_Store.Data;
using ASP.NET_Core_Game_Store.Endpoints;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.Services.AddGameStoreDb();

WebApplication app = builder.Build();

app.MapGameEndpoints();

app.MigrateDb();

app.Run();