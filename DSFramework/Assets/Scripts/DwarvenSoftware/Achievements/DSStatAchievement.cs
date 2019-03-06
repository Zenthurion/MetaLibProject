using System;

namespace DwarvenSoftware.Achievements
{
    public abstract class DSStatAchievement : DSAchievement
    {
        private int _objectiveProgress;

        protected DSStatAchievement(string name, string description, int objectiveTarget) : base(name, description)
        {
            ObjectiveTarget = objectiveTarget;

            if (objectiveTarget <= 0)
                throw new ArgumentException("Unable to create achievement with target less than or equal to 0!");
        }

        public int ObjectiveTarget { get; }

        public int ObjectiveProgress
        {
            get => _objectiveProgress;
            protected set
            {
                if (IsLocked || IsCompleted) return;

                _objectiveProgress = value;

                if (_objectiveProgress < ObjectiveTarget) return;

                _objectiveProgress = ObjectiveTarget;
                IsCompleted = true;
            }
        }

        public override float Progress => (float) ObjectiveProgress / ObjectiveTarget;
    }
}