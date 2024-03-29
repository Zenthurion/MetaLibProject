using MetaLib.Core;
using MetaLib.Tasks;
using NUnit.Framework;

namespace MetaLib.Editor.Tests.Tasks
{
    public class TaskTests
    {
        [Test]
        public void Task_Completed()
        {
            var num = new MInt(5);
            var a = new MTask((t) => num.Value == 4);
            a.OnComplete += () => { num.Value = 2; };

            a.Evaluate();
            Assert.That(num.Value == 5);

            num.Value--;
            a.Evaluate();
            Assert.That(num.Value == 2);
        }

        [Test]
        public void Task_Cancelled()
        {
            var num = new MInt(5);
            var a = new MTask((t) => num.Value == 4);
            a.OnComplete += () => { num.Value = 2; };
            a.OnEnd += () => { num.Value = 3; };
            a.Cancel();

            Assert.That(num.Value == 3);
        }

        [Test]
        public void TaskStack_SingleCompleted()
        {
            var taskStack = new MTaskStack();
            var num = new MInt(5);
            var a = new MTask((t) => num.Value == 4);
            a.OnComplete += () => num.Value = 0;
            taskStack.PushQueue(a);
            num.Value--;
            taskStack.Evaluate();

            Assert.That(num.Value == 0);
            Assert.AreEqual(0, taskStack.Count);
        }

        [Test]
        public void TaskStack_TwoTasks()
        {
            var taskStack = new MTaskStack();
            var num = new MInt(5);
            var a = new MTask((t) => num.Value == 4);
            var b = new MTask((t) => num.Value == 3);
            b.OnComplete += () => num.Value = 0;
            taskStack.PushQueue(a);
            taskStack.PushQueue(b);
            
            num.Value--;
            taskStack.Evaluate();

            Assert.AreSame(b, taskStack.Current);
            
            num.Value--;
            taskStack.Evaluate();

            Assert.AreEqual(0, num.Value);
            Assert.AreEqual(0, taskStack.Count);
        }

        [Test]
        public void TaskStack_TwoTasksThenOne()
        {
            var taskStack = new MTaskStack();
            var num = new MInt(5);
            var a = new MTask((t) => num.Value == 4);
            var b = new MTask((t) => num.Value == 3);
            var c = new MTask((t) => num.Value == 2);
            c.OnComplete += () => num.Value = 0;
            taskStack.PushQueue(a);
            taskStack.PushQueue(b);
            
            num.Value--;
            taskStack.Evaluate();

            Assert.AreSame(b, taskStack.Current);
            
            num.Value--;
            taskStack.Evaluate();
            taskStack.Evaluate();
            
            taskStack.PushQueue(c);
            taskStack.Evaluate();
            num.Value = 2;
            taskStack.Evaluate();

            Assert.AreEqual(0, num.Value);
            Assert.AreEqual(0, taskStack.Count);
        }

        [Test]
        public void TaskStack_ThreeQueuedTwoCapacity()
        {
            var taskStack = new MTaskStack();
            var num = new MInt(5);
            var a = new MTask((t) => num.Value == 4);
            var b = new MTask((t) => num.Value == 3);
            var c = new MTask((t) => num.Value == 2);
            c.OnComplete += () => num.Value = 0;
            taskStack.PushQueue(a);
            taskStack.PushQueue(b);
            taskStack.PushQueue(c);
            
            Assert.AreSame(c, taskStack.Next);
            
            Assert.AreEqual(2, taskStack.Count);
        }

        [Test]
        public void TaskStack_ThreeQueuedThreeCapacity()
        {
            var taskStack = new MTaskStack(3);
            var num = new MInt(5);
            var a = new MTask((t) => num.Value == 4);
            var b = new MTask((t) => num.Value == 3);
            var c = new MTask((t) => num.Value == 2);
            c.OnComplete += () => num.Value = 0;
            taskStack.PushQueue(a);
            taskStack.PushQueue(b);
            taskStack.PushQueue(c);
            
            Assert.AreSame(c, taskStack.Next);
            
            Assert.AreEqual(3, taskStack.Count);
        }

        [Test]
        public void TaskStack_TwoTasksImmediateOne()
        {
            var taskStack = new MTaskStack();
            var num = new MInt(5);
            var a = new MTask((t) => num.Value == 4);
            var b = new MTask((t) => num.Value == 3);
            var c = new MTask((t) => num.Value == 2);
            c.OnComplete += () => num.Value = 0;
            taskStack.PushQueue(a);
            taskStack.PushQueue(b);
            
            num.Value--;
            taskStack.Evaluate();

            Assert.AreSame(b, taskStack.Current);
            
            num.Value--;
            taskStack.Evaluate();
            taskStack.Evaluate();
            
            taskStack.PushQueue(c);
            taskStack.Evaluate();
            num.Value = 2;
            taskStack.Evaluate();

            Assert.AreEqual(0, num.Value);
            Assert.AreEqual(0, taskStack.Count);
        }
    }
}