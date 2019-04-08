using System;

namespace DwarvenSoftware.Framework.Achievements
{
    public interface IAchievement
    {
        string Name { get; }
        string Description { get; }
        bool IsLocked { get; }
        bool IsCompleted { get; }
        float Progress { get; }
        event EventHandler OnCompleted;
        void Reset();
        void Lock();
        void Unlock();
        void SetLocked(bool locked);
    }
}