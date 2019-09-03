using System;

namespace MetaLib.Tasks
{
    public class MTask : ITask
    {
        public event TaskEvent OnComplete;
        public event TaskEvent OnEnd;

        private Func<ITask, bool>  _condition;

        public MTask(Func<ITask, bool>  condition)
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