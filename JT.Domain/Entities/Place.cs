namespace JT.Domain.Entities;

public class Place : BaseAuditableEntity
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public Localization Localization { get; set; } = new();

    public IList<Review> Reviews { get; private set; } = new List<Review>();
}
