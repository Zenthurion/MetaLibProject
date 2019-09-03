using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetaLib.Tasks
{
    public delegate void TaskEvent();

    public interface ITask
    {
        event TaskEvent OnComplete;
        event TaskEvent OnEnd;

        void SetCompletionCondition(Func<ITask, bool> condition);
        
        void Evaluate();
        void Cancel();
    }
}