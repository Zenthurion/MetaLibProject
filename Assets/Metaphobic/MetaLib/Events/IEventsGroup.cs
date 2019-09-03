namespace MetaLib.Events
{
    public interface IEventsGroup
    {
        void Add<T>(MEvents.EventDelegate<T> listener) where T : MetaEvent;
        void Remove<T>(MEvents.EventDelegate<T> listener) where T : MetaEvent;
        void Raise<T>(T e) where T : MetaEvent;
    }
}