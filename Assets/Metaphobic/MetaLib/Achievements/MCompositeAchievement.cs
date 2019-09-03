using System;
using System.Collections.Generic;
using System.Linq;

namespace MetaLib.Achievements
{
    public class MCompositeAchievement : MAchievement
    {
        public MCompositeAchievement(string name, params MAchievement[] objectives) : this(name,
            new List<MAchievement>(objectives))
        {
        }

        public MCompositeAchievement(string name, List<MAchievement> objectives) : base(name,
            "Complete the following objectives")
        {
            Objectives = objectives;

            var set = new HashSet<MAchievement>(objectives);
            if (set.Count != objectives.Count)
                throw new ArgumentException(
                    "Composite Achievement can't contain two or more instances of the same objective!");

            if (objectives.Count == 0) throw new ArgumentException("Unable to create Achievement with no objectives!");

            foreach (var o in objectives) o.OnCompleted += CheckCompleted;
        }

        public List<MAchievement> Objectives { get; }

        public override float Progress
        {
            get { return (float) Objectives.Count(achievement => achievement.IsCompleted) / Objectives.Count; }
        }

        private void CheckCompleted(object obj, EventArgs e)
        {
            if (Objectives.Count(achievement => achievement.IsCompleted) != Objectives.Count) return;

            IsCompleted = true;
        }
    }
}