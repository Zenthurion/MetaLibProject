using DwarvenSoftware.Framework.Achievements;
using DwarvenSoftware.Framework.Events;

namespace DwarvenSoftware.Framework.Editor.Tests.Achievements
{
    internal class StatDSAchievementTest : DSStatAchievement
    {
        public StatDSAchievementTest(int objectiveTarget, string name = "", string description = "") : base(name,
            description, objectiveTarget)
        {
            DSEvents.Add<TestEvent>(AchievementProgressed);
        }

        private void AchievementProgressed(TestEvent e)
        {
            ObjectiveProgress += e.Value;
        }
    }

    internal class TestEvent : GameEvent
    {
        public readonly int Value;

        public TestEvent(int value)
        {
            Value = value;
        }
    }
}