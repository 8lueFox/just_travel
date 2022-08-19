namespace JT.Domain.Events;

public class PlaceAddedEvent : BaseEvent
{
    public PlaceAddedEvent(Place item)
    {
        Item = item;
    }

    public Place Item { get; }
}
