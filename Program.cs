using ASP.NET_Core_Game_Store.Endpoints;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

app.MapGameEndpoints();

app.Run();