using System;

namespace DwarvenSoftware.Framework.Tasks
{
    public class DSTask : ITask
    {
        public event TaskEvent OnComplete;
        public event TaskEvent OnEnd;

        private Func<ITask, bool>  _condition;

        public DSTask(Func<ITask, bool>  condition)
        {
            SetCompletionCondition(condition);
        }
        
        public void SetCompletionCondition(Func<ITask, bool> condition)
        {
            _condition = condition;
        }

        public virtual void Evaluate()
        {
            if(!_condition.Invoke(this)) return;
            
            OnComplete?.Invoke();
            OnEnd?.Invoke();
        }

        public void Cancel()
        {
            OnEnd?.Invoke();
        }
    }
}