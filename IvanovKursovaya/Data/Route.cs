using System.ComponentModel.DataAnnotations;

namespace IvanovKursovaya.Data;

public class Route
{
    public int RouteId { get; set; }

    [Required(ErrorMessage = "Город отправления обязателен")]
    [StringLength(100, ErrorMessage = "Не более 100 символов")]
    public string FromCity { get; set; } = "";

    [Required(ErrorMessage = "Город назначения обязателен")]
    [StringLength(100, ErrorMessage = "Не более 100 символов")]
    public string ToCity { get; set; } = "";

    [Range(1, 100000, ErrorMessage = "Расстояние должно быть от 1 до 100000 км")]
    public int DistanceKm { get; set; }

    public string? ImagePath { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
