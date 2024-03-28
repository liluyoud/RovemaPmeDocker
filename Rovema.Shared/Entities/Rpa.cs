using System.ComponentModel.DataAnnotations;

namespace Rovema.Shared.Entities;

public class Rpa : EntityBase
{
    [Required]
    [StringLength(255)]
    public string? Name { get; set; }

    [StringLength(255)]
    public string? Type { get; set; }

    public int TimeZone { get; set; }

    public int TimeToFail { get; set; }

    public bool Active { get; set; }

}
