using System.ComponentModel.DataAnnotations;

namespace IvanovKursovaya.Data;

public class RouteStop
{
    public int RouteStopId { get; set; }

    public int RouteId { get; set; }

    public int StopNumber { get; set; }

    [Required]
    [StringLength(200)]
    public string StationName { get; set; } = "";

    [StringLength(200)]
    public string Region { get; set; } = "";

    public string? TravelTime { get; set; }

    public int? DistanceKm { get; set; }

    public virtual Route Route { get; set; } = null!;
}
