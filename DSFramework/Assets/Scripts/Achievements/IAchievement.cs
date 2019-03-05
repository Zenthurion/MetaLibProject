using System;

namespace Achievements
{
    public interface IAchievement
    {
        string Name { get; }
        string Description { get; }
        event EventHandler OnCompleted;
        bool IsLocked { get; }
        bool IsCompleted { get; }
        float Progress { get; }
        void Reset();
        void Lock();
        void Unlock();
        void SetLocked(bool locked);
    }
}