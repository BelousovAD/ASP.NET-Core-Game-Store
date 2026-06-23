namespace ASP.NET_Core_Game_Store.Dtos;

internal record struct GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
    );