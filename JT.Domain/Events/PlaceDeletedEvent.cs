namespace JT.Domain.Events;

public class PlaceDeletedEvent : BaseEvent
{
    public PlaceDeletedEvent(Place item)
    {
        Item = item;
    }

    public Place Item { get; }
}
