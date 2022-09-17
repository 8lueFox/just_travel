namespace JT.Domain.Entities;

public class Review : BaseAuditableEntity
{
    public int Stars { get; set; }
    public string Description { get; set; }

    public int PlaceId { get; set; }
}
