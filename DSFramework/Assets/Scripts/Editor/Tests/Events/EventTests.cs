using Events;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Utils;

namespace Editor.Tests.Events
{
    public class EventTests
    {
        private class TestEvent : GameEvent
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
            var category = DSUtils.GetRandomString();
            DSEvents.Instance.AddEventsCategory(category);

            DSEvents.Instance[category].Raise(new TestEvent(0));
            LogAssert.NoUnexpectedReceived();
            DSEvents.Instance[category].Add<TestEvent>(TestEventListener);
            DSEvents.Instance[category].Raise(new TestEvent(0));
            
            LogAssert.Expect(LogType.Log, "TestEvent0");
            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        public void AddingEventListener_Multiple()
        {
            var category = DSUtils.GetRandomString();
            DSEvents.Instance.AddEventsCategory(category);

            DSEvents.Instance[category].Raise(new TestEvent(0));
            LogAssert.NoUnexpectedReceived();
            DSEvents.Instance[category].Add<TestEvent>(TestEventListener);
            DSEvents.Instance[category].Add<TestEvent>(TestEventListener);
            DSEvents.Instance[category].Add<TestEvent>(TestEventListener);
            DSEvents.Instance[category].Raise(new TestEvent(0));
            
            LogAssert.Expect(LogType.Log, "TestEvent0");
            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        public void RemovingEventListener()
        {
            DSEvents.Add<TestEvent>(TestEventListener);

            DSEvents.RaiseEvent(new TestEvent(1));
            LogAssert.Expect(LogType.Log, "TestEvent" + 1);
            
            DSEvents.Remove<TestEvent>(TestEventListener);
            DSEvents.RaiseEvent(new TestEvent(1));

            LogAssert.NoUnexpectedReceived();
        }

        [Test]
        public void RaisingEvent()
        {
            DSEvents.Add<TestEvent>(TestEventListener);
            DSEvents.RaiseEvent(new TestEvent(0));
            LogAssert.Expect(LogType.Log, "TestEvent0");
        }

        [Test]
        public void AddingEventCategory_Multiple()
        {
            var name = DSUtils.GetRandomString();
            DSEvents.Instance.AddEventsCategory(name);
            DSEvents.Instance.AddEventsCategory(name);
            
            LogAssert.Expect(LogType.Log, $"Events category [{name}] already exists!");
        }

        private void TestEventListener(TestEvent e)
        {
            Debug.Log("TestEvent" + e.Value);
        }
    }
}