using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_Game_Store.Dtos;

internal record struct CreateGameDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Required][Range(1, 100)] decimal Price,
    [Required] DateOnly ReleaseDate
    );