using System;

namespace Achievements
{
    public abstract class DSAchievement : IAchievement
    {
        private readonly string _name;

        public string Name
        {
            get { return _name; }
        }

        private readonly string _description;

        public string Description
        {
            get { return _description; }
        }

        public event EventHandler OnCompleted;

        private DSAchievement _prerequisite;

        public bool IsLocked { get; protected set; }

        private bool _isCompleted = false;

        public bool IsCompleted
        {
            get { return _isCompleted; }
            protected set
            {
                if (IsLocked || _isCompleted || !value) return;
                _isCompleted = true;

                if (OnCompleted == null) return;
                OnCompleted.Invoke(this, null);
            }
        }

        public abstract float Progress { get; }

        protected DSAchievement(string name, string description)
        {
            _name = name;
            _description = description;
            IsCompleted = false;
            IsLocked = false;
        }

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