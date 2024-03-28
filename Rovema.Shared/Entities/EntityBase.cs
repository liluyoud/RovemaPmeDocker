using System.ComponentModel.DataAnnotations;

namespace Rovema.Shared.Entities;

public abstract class EntityBase
{
    [Key]
    public Guid Id { get; set; }
}
