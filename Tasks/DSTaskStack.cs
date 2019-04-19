using System.Collections.Generic;

namespace DwarvenSoftware.Framework.Tasks
{
    public class DSTaskStack : ITaskStack
    {
        private readonly List<ITask> _tasks;
        private readonly int _capacity;
        
        public DSTaskStack(int capacity = 2)
        {
            _capacity = capacity;
            _tasks = new List<ITask>(capacity);
        }

        public void Evaluate()
        {
            Current?.Evaluate();
        }

        public void Cancel()
        {
            Current?.Cancel();
        }
        
        public void PushImmediate(ITask task)
        {
            _tasks[0]?.Cancel();
            _tasks[0] = task;
            task.OnEnd += NextTask;
        }

        private void NextTask()
        {
            _tasks.RemoveAt(0);
            if(_tasks.Count > 0) 
                _tasks[0].OnEnd += NextTask;
        }
        
        public void PushQueue(ITask task)
        {
            if (_tasks.Count == 0)
            {
                _tasks.Add(task);
                task.OnEnd += NextTask;
            }
            else if (_tasks.Count == 1)
            {
                _tasks.Add(task);
            }
            else
            {
                _tasks.Insert(1, task);
            }

            CullExcess();
        }

        private void CullExcess()
        {
            while (_tasks.Count > _capacity)
            {
                _tasks.RemoveAt(_tasks.Count - 1);
            }
        }

        public ITask Current => _tasks.Count > 0 ? _tasks[0] : null;
        public ITask Next => _tasks.Count > 1 ? _tasks[1] : null;
        public int Capacity => _capacity;
        public int Count => _tasks.Count;
    }
}