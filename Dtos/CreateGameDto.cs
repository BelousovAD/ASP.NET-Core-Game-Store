namespace ASP.NET_Core_Game_Store.Dtos;

internal record struct CreateGameDto(
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
    );