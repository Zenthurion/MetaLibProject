using System;

namespace Achievements
{
    public abstract class DSStatAchievement : DSAchievement
    {
        private readonly int _objectiveTarget;

        public int ObjectiveTarget
        {
            get { return _objectiveTarget; }
        }

        private int _objectiveProgress;

        public int ObjectiveProgress
        {
            get { return _objectiveProgress; }
            protected set
            {
                if (IsLocked || IsCompleted) return;

                _objectiveProgress = value;

                if (_objectiveProgress < _objectiveTarget) return;

                _objectiveProgress = _objectiveTarget;
                IsCompleted = true;
            }
        }

        public override float Progress
        {
            get { return (float) ObjectiveProgress / _objectiveTarget; }
        }

        protected DSStatAchievement(string name, string description, int objectiveTarget) : base(name, description)
        {
            _objectiveTarget = objectiveTarget;

            if (objectiveTarget <= 0)
            {
                throw new ArgumentException("Unable to create achievement with target less than or equal to 0!");
            }
        }
    }
}