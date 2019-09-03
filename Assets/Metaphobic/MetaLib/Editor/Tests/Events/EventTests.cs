using MetaLib.Events;
using MetaLib.Utils;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace MetaLib.Editor.Tests.Events
{
    public class EventTests
    {
        private class TestEvent : MetaEvent
        {
            public int Value { get; }

            public TestEvent(int value)
            {
                Value = value;
            }
        }

        [Test]
        public void AddingEventListener()
        {
            var category = MUtils.GetRandomString();
            MEvents.Instance.AddEventsCategory(category);

            MEvents.Instance[category].Raise(new TestEvent(0));
            LogAssert.NoUnexpectedReceived();
            MEvents.Instance[category].Add<TestEvent>(TestEventListener);
            MEvents.Instance[category].Raise(new TestEvent(0));
            
            LogAssert.Expect(LogType.Log, "TestEvent0");
            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        public void AddingEventListener_Multiple()
        {
            var category = MUtils.GetRandomString();
            MEvents.Instance.AddEventsCategory(category);

            MEvents.Instance[category].Raise(new TestEvent(0));
            LogAssert.NoUnexpectedReceived();
            MEvents.Instance[category].Add<TestEvent>(TestEventListener);
            MEvents.Instance[category].Add<TestEvent>(TestEventListener);
            MEvents.Instance[category].Add<TestEvent>(TestEventListener);
            MEvents.Instance[category].Raise(new TestEvent(0));
            
            LogAssert.Expect(LogType.Log, "TestEvent0");
            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        public void RemovingEventListener()
        {
            MEvents.Add<TestEvent>(TestEventListener);

            MEvents.RaiseEvent(new TestEvent(1));
            LogAssert.Expect(LogType.Log, "TestEvent" + 1);
            
            MEvents.Remove<TestEvent>(TestEventListener);
            MEvents.RaiseEvent(new TestEvent(1));

            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        public void RaisingEvent()
        {
            MEvents.Add<TestEvent>(TestEventListener);
            MEvents.RaiseEvent(new TestEvent(0));
            LogAssert.Expect(LogType.Log, "TestEvent0");
        }

        [Test]
        public void AddingEventCategory_Multiple()
        {
            var name = MUtils.GetRandomString();
            MEvents.Instance.AddEventsCategory(name);
            MEvents.Instance.AddEventsCategory(name);
            
            LogAssert.Expect(LogType.Log, $"Events category [{name}] already exists!");
        }

        private void TestEventListener(TestEvent e)
        {
            Debug.Log("TestEvent" + e.Value);
        }
    }
}