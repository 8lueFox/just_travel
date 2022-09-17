namespace JT.Domain.ValueObjects;

public class Localization
{
    public float Long { get; set; }
    public float Lat { get; set; }

    public Localization()
    {
        Long = 0;
        Lat = 0;
    }
}
