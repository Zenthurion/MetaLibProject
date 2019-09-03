using System;
using System.Collections.Generic;
using UnityEngine;

namespace MetaLib.Events
{
    public abstract class MetaEvent
    {
    }

    // Code based on gist by wmiller:
    // https://gist.github.com/wmiller/3903205#file-events-cs
    public class MEvents
    {
        public delegate void EventDelegate<T>(T gameEvent) where T : MetaEvent;

        private static MEvents _instance;

        public static readonly string CATEGORY_GENERAL;
        public static readonly string CATEGORY_UI;

        private readonly Dictionary<string, IEventsGroup> _eventsGroups;

        static MEvents()
        {
            CATEGORY_GENERAL = "General";
            CATEGORY_UI = "UI";
        }


        private MEvents()
        {
            _eventsGroups = new Dictionary<string, IEventsGroup>
            {
                {CATEGORY_GENERAL, new DSEventsGroup()}, {CATEGORY_UI, new DSEventsGroup()}
            };
        }

        public static MEvents Instance => _instance ?? (_instance = new MEvents());

        public static IEventsGroup General => Instance[CATEGORY_GENERAL];
        public static IEventsGroup UI => Instance[CATEGORY_UI];

        public IEventsGroup this[string category]
        {
            get
            {
                IEventsGroup eventsGroup;
                return _eventsGroups.TryGetValue(category, out eventsGroup) ? eventsGroup : null;
            }
            set => AddEventsCategory(category, value);
        }

        public void AddEventsCategory(string category, IEventsGroup eventsGroup = null)
        {
            if (_eventsGroups.ContainsKey(category))
            {
                Debug.Log($"Events category [{category}] already exists!");
                return;
            }

            _eventsGroups.Add(category, eventsGroup ?? new DSEventsGroup());
        }

        public void AddListener<T>(EventDelegate<T> listener, string category = "General")
            where T : MetaEvent
        {
            this[category].Add(listener);
        }

        public static void Add<T>(EventDelegate<T> listener, string category = "General")
            where T : MetaEvent
        {
            Instance.AddListener(listener, category);
        }

        public void RemoveListener<T>(EventDelegate<T> listener, string category = "General")
            where T : MetaEvent
        {
            this[category].Remove(listener);
        }

        public static void Remove<T>(EventDelegate<T> listener, string category = "General")
            where T : MetaEvent
        {
            Instance.RemoveListener(listener, category);
        }

        public void Raise<T>(T e, string category = "General") where T : MetaEvent
        {
            if (e == null) throw new ArgumentNullException();

            this[category].Raise(e);
        }

        public static void RaiseEvent<T>(T e, string category = "General") where T : MetaEvent
        {
            Instance.Raise(e, category);
        }
    }
}