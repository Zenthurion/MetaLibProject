using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DwarvenSoftware.Framework.Tasks
{
    public delegate void TaskEvent();

    public interface ITask
    {
        event TaskEvent OnComplete;
        event TaskEvent OnEnd;

        void SetCompletionCondition(Func<bool> condition);
        
        void Evaluate();
        void Cancel();
    }
}