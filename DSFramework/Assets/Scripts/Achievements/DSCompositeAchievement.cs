using System;
using System.Collections.Generic;
using System.Linq;

namespace Achievements
{
    public class DSCompositeAchievement : DSAchievement
    {
        private readonly List<DSAchievement> _objectives;

        public DSCompositeAchievement(string name, params DSAchievement[] objectives) : this(name,
            new List<DSAchievement>(objectives))
        {
        }

        public DSCompositeAchievement(string name, List<DSAchievement> objectives) : base(name,
            "Complete the following objectives")
        {
            _objectives = objectives;

            var set = new HashSet<DSAchievement>(objectives);
            if (set.Count != objectives.Count)
            {
                throw new ArgumentException(
                    "Composite Achievement can't contain two or more instances of the same objective!");
            }

            if (objectives.Count == 0)
            {
                throw new ArgumentException("Unable to create Achievement with no objectives!");
            }

            foreach (var o in objectives)
            {
                o.OnCompleted += CheckCompleted;
            }
        }

        public List<DSAchievement> Objectives
        {
            get { return _objectives; }
        }

        public override float Progress
        {
            get { return (float) _objectives.Count(achievement => achievement.IsCompleted) / _objectives.Count; }
        }

        private void CheckCompleted(object obj, EventArgs e)
        {
            if (_objectives.Count(achievement => achievement.IsCompleted) != _objectives.Count) return;

            IsCompleted = true;
        }
    }
}