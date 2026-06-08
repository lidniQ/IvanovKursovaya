using System.ComponentModel.DataAnnotations;

namespace IvanovKursovaya.Data;

public class City
{
    public int CityId { get; set; }

    [Required(ErrorMessage = "Название города обязательно")]
    [StringLength(100, ErrorMessage = "Не более 100 символов")]
    public string CityName { get; set; } = "";

    public virtual ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
}
