using System;
using MetaLib.Utils;

namespace MetaLib.Tasks
{
    public class MTimerTask : MTask
    {
        private MTimer _timer;
        public MTimer Timer => _timer;
        
        public MTimerTask(Func<ITask, bool> condition) : base(condition)
        {
            _timer = new MTimer();
        }
    }
}