using System;
using DwarvenSoftware.Framework.Utils;

namespace DwarvenSoftware.Framework.Tasks
{
    public class DSTimerTask : DSTask
    {
        private DSTimer _timer;
        public DSTimer Timer => _timer;
        
        public DSTimerTask(Func<ITask, bool> condition) : base(condition)
        {
            _timer = new DSTimer();
        }
    }
}