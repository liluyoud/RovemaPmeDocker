using System.ComponentModel.DataAnnotations;

namespace Rovema.Shared.Entities;

public class Powerplant : EntityBase
{
    [Required]
    [StringLength(255)]
    public string? Name { get; set; }

    [Required]
    [StringLength(255)]
    public string? Type { get; set; }

    [Required]
    public double Power { get; set; }

    [StringLength(255)]
    public string? City { get; set; }

    [StringLength(100)]
    public string? State { get; set; }

    [StringLength(100)]
    public string? Coordinate { get; set; }

    public bool Active { get; set; }

}
