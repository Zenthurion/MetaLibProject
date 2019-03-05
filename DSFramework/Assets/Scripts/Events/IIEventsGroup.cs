namespace Events
{
    public interface IEventsGroup
    {
        void Add<T>(DSEvents.EventDelegate<T> listener) where T : GameEvent;
        void Remove<T>(DSEvents.EventDelegate<T> listener) where T : GameEvent;
        void Raise<T>(T e) where T : GameEvent;
    }
}