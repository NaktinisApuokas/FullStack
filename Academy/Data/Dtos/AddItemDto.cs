using System.ComponentModel.DataAnnotations;

namespace Academy.Data.Dtos
{
    public record CreateCinemaDto([Required] string Name, [Required] string Information);
}
