using System;

namespace DwarvenSoftware.Framework.Tasks
{
    public class DSTask : ITask
    {
        public event TaskEvent OnComplete;
        public event TaskEvent OnEnd;

        private Func<bool>  _condition;

        public DSTask(Func<bool>  condition)
        {
            SetCompletionCondition(condition);
        }
        
        public void SetCompletionCondition(Func<bool> condition)
        {
            _condition = condition;
        }

        public void Evaluate()
        {
            if(!_condition.Invoke()) return;
            
            OnComplete?.Invoke();
            OnEnd?.Invoke();
        }

        public void Cancel()
        {
            OnEnd?.Invoke();
        }
    }
}