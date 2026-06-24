using ASP.NET_Core_Game_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Game_Store.Data;

internal class GameStoreContext(DbContextOptions<GameStoreContext> options)
    : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Genre> Genres => Set<Genre>();
}