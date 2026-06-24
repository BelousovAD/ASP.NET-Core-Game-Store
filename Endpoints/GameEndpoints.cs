using ASP.NET_Core_Game_Store.Dtos;

namespace ASP.NET_Core_Game_Store.Endpoints;

internal static class GameEndpoints
{
    private const string GetGameEndpointName = "GetGame";

    private static readonly List<GameDto> s_games =
    [
        new (1, "Street Fighter II", "Fighting", 19.99M, new DateOnly(1992, 7, 15)),
        new (2, "Final Fantasy VII Rebirth", "RPG", 69.99M, new DateOnly(2024, 2, 29)),
        new (3, "Astro Bot", "Platformer", 59.99M, new DateOnly(2024, 9, 6)),
    ];

    public static void MapGameEndpoints(this WebApplication app)
    {
        RouteGroupBuilder groupGames = app.MapGroup("/games");
        
        // GET /games
        groupGames.MapGet("/", () => s_games);

        // GET /games/1
        groupGames.MapGet("/{id:int}", (int id) =>
        {
            GameDto? game = s_games.Find(game => game.Id == id);

            return game is null ? Results.NotFound() : Results.Ok(game);
        })
        .WithName(GetGameEndpointName);

        // POST /games
        groupGames.MapPost("/", (CreateGameDto newGame) =>
        {
            GameDto game = new (s_games.Count + 1, newGame.Name, newGame.Genre, newGame.Price, newGame.ReleaseDate);
            s_games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        // PUT /games/1
        groupGames.MapPut("/{id:int}", (int id, CreateGameDto updatedGame) =>
        {
            int index = s_games.FindIndex(game => game.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            s_games[index] = s_games[index] with
            {
                Name = updatedGame.Name,
                Genre = updatedGame.Genre,
                Price = updatedGame.Price,
                ReleaseDate = updatedGame.ReleaseDate
            };

            return Results.NoContent();
        });

        // DELETE /games/1
        groupGames.MapDelete("/{id:int}", (int id) =>
        {
            s_games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });
    }
}