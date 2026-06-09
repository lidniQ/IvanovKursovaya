using System.ComponentModel.DataAnnotations;

namespace IvanovKursovaya.Data;

public class Ticket
{
    public int TicketId { get; set; }

    public int ScheduleId { get; set; }

    [Required(ErrorMessage = "Имя пассажира обязательно")]
    [StringLength(200, ErrorMessage = "Не более 200 символов")]
    public string PassengerName { get; set; } = "";

    [Required(ErrorMessage = "Email пассажира обязателен")]
    [StringLength(200, ErrorMessage = "Не более 200 символов")]
    [DataType(DataType.EmailAddress)]
    public string PassengerEmail { get; set; } = "";

    [StringLength(100)]
    public string PassengerSurname { get; set; } = "";

    [StringLength(100)]
    public string PassengerIma { get; set; } = "";

    [StringLength(100)]
    public string PassengerPatronymic { get; set; } = "";

    public DateTime? PassengerBirthDate { get; set; }

    [StringLength(20)]
    public string PassengerGender { get; set; } = "";

    [StringLength(100)]
    public string PassengerCitizenship { get; set; } = "РОССИЯ";

    [StringLength(100)]
    public string DocumentType { get; set; } = "Паспорт гражданина РФ";

    [StringLength(50)]
    public string DocumentNumber { get; set; } = "";

    [StringLength(50)]
    public string Tariff { get; set; } = "Пассажирский";

    [Range(1, 200, ErrorMessage = "Номер места от 1 до 200")]
    public int SeatNumber { get; set; }

    public DateTime PurchaseDate { get; set; }

    [Range(0.01, 1000000, ErrorMessage = "Цена должна быть больше 0")]
    public decimal TotalPrice { get; set; }

    public virtual Schedule Schedule { get; set; } = null!;
}
