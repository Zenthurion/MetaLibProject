using System;
using System.Collections.Generic;

namespace MetaLib.Events
{
    public class DSEventsGroup : IEventsGroup
    {
        private readonly Dictionary<Type, Delegate> _delegates = new Dictionary<Type, Delegate>();

        internal DSEventsGroup()
        {
        }

        public void Add<T>(MEvents.EventDelegate<T> listener) where T : MetaEvent
        {
            Remove(listener); // Questionable - Though, seems to have done the trick... Performance impact likely... Short story: prevents the same function from being added multiple times as a listener
            if (_delegates.TryGetValue(typeof(T), out var currentDelegate))
                _delegates[typeof(T)] = Delegate.Combine(currentDelegate, listener);
            else
                _delegates[typeof(T)] = listener;
        }

        public void Remove<T>(MEvents.EventDelegate<T> listener) where T : MetaEvent
        {
            if (!_delegates.TryGetValue(typeof(T), out _)) return;

            var resultingDelegate = Delegate.Remove(_delegates[typeof(T)], listener);
            if (resultingDelegate == null)
                _delegates.Remove(typeof(T));
            else
                _delegates[typeof(T)] = resultingDelegate;
        }

        public void Raise<T>(T e) where T : MetaEvent
        {
            if (e == null) throw new ArgumentNullException();

            if (!_delegates.TryGetValue(e.GetType(), out var del)) return;
            var target = del as MEvents.EventDelegate<T>;

            target?.Invoke(e);
        }
    }
}