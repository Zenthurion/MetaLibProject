using System;
using System.Collections.Generic;
using System.Linq;

namespace DwarvenSoftware.Framework.Achievements
{
    public class DSCompositeAchievement : DSAchievement
    {
        public DSCompositeAchievement(string name, params DSAchievement[] objectives) : this(name,
            new List<DSAchievement>(objectives))
        {
        }

        public DSCompositeAchievement(string name, List<DSAchievement> objectives) : base(name,
            "Complete the following objectives")
        {
            Objectives = objectives;

            var set = new HashSet<DSAchievement>(objectives);
            if (set.Count != objectives.Count)
                throw new ArgumentException(
                    "Composite Achievement can't contain two or more instances of the same objective!");

            if (objectives.Count == 0) throw new ArgumentException("Unable to create Achievement with no objectives!");

            foreach (var o in objectives) o.OnCompleted += CheckCompleted;
        }

        public List<DSAchievement> Objectives { get; }

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