namespace JT.Domain.Entities;

public class Place : BaseAuditableEntity
{
    public string? Title { get; set; }

    public string? Description { get; set; }
}
