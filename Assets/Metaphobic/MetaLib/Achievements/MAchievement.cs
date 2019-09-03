using System;

namespace MetaLib.Achievements
{
    public abstract class MAchievement : IAchievement
    {
        private bool _isCompleted;

        private MAchievement _prerequisite;

        protected MAchievement(string name, string description)
        {
            Name = name;
            Description = description;
            IsCompleted = false;
            IsLocked = false;
        }

        public string Name { get; }

        public string Description { get; }

        public event EventHandler OnCompleted;

        public bool IsLocked { get; protected set; }

        public bool IsCompleted
        {
            get => _isCompleted;
            protected set
            {
                if (IsLocked || _isCompleted || !value) return;
                _isCompleted = true;

                if (OnCompleted == null) return;
                OnCompleted.Invoke(this, null);
            }
        }

        public abstract float Progress { get; }

        public virtual void Reset()
        {
            IsCompleted = false;
        }

        public void Lock()
        {
            SetLocked(true);
        }

        public void Unlock()
        {
            SetLocked(false);
        }

        public void SetLocked(bool locked)
        {
            IsLocked = locked;
        }
    }
}