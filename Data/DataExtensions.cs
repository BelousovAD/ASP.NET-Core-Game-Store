using ASP.NET_Core_Game_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Game_Store.Data;

internal static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();
        GameStoreContext dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbContext.Database.Migrate();
    }

    public static void AddGameStoreDb(this IServiceCollection services)
    {
        const string ConnString = "Data Source=GameStore.db";

        services.AddSqlite<GameStoreContext>(ConnString, optionsAction: options =>
            options.UseSeeding((context, _) =>
            {
                if (context.Set<Genre>().Any() == false)
                {
                    context.Set<Genre>().AddRange(
                        new Genre { Name = "Fighting" },
                        new Genre { Name = "RPG" },
                        new Genre { Name = "Platformer" },
                        new Genre { Name = "Racing" },
                        new Genre { Name = "Sports" }
                    );

                    context.SaveChanges();
                }
            })
        );
    }
}