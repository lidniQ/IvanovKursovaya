using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace IvanovKursovaya.Data;

public class ApplicationUser : IdentityUser
{
    [Required(ErrorMessage = "Фамилия обязательна")]
    [StringLength(100, ErrorMessage = "Не более 100 символов")]
    public string Surname { get; set; } = "";

    [Required(ErrorMessage = "Имя обязательно")]
    [StringLength(100, ErrorMessage = "Не более 100 символов")]
    public string Ima { get; set; } = "";

    [Required(ErrorMessage = "Отчество обязательно")]
    [StringLength(100, ErrorMessage = "Не более 100 символов")]
    public string SecSurname { get; set; } = "";

    public int? CityId { get; set; }

    [StringLength(100)]
    public string DocumentType { get; set; } = "Паспорт гражданина РФ";

    [StringLength(50)]
    public string DocumentNumber { get; set; } = "";

    public virtual City? City { get; set; }
}
