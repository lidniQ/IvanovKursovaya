using System.ComponentModel.DataAnnotations;

namespace IvanovKursovaya.Data;

public class Schedule
{
    public int ScheduleId { get; set; }

    public int RouteId { get; set; }

    [Required(ErrorMessage = "Дата отправления обязательна")]
    [DataType(DataType.Date)]
    public DateTime DepartureDate { get; set; }

    [Required(ErrorMessage = "Время отправления обязательно")]
    public TimeSpan DepartureTime { get; set; }

    [Required(ErrorMessage = "Время прибытия обязательно")]
    public TimeSpan ArrivalTime { get; set; }

    [Required(ErrorMessage = "Перевозчик обязателен")]
    [StringLength(200, ErrorMessage = "Не более 200 символов")]
    public string Carrier { get; set; } = "";

    [Range(1, 200, ErrorMessage = "Количество мест от 1 до 200")]
    public int TotalSeats { get; set; }

    [Range(0.01, 1000000, ErrorMessage = "Цена должна быть больше 0")]
    public decimal Price { get; set; }

    public virtual Route Route { get; set; } = null!;
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
