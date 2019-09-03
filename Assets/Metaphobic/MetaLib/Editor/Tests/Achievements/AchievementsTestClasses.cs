using MetaLib.Achievements;
using MetaLib.Events;

namespace MetaLib.Editor.Tests.Achievements
{
    internal class StatMAchievementTest : MStatAchievement
    {
        public StatMAchievementTest(int objectiveTarget, string name = "", string description = "") : base(name,
            description, objectiveTarget)
        {
            MEvents.Add<TestEvent>(AchievementProgressed);
        }

        private void AchievementProgressed(TestEvent e)
        {
            ObjectiveProgress += e.Value;
        }
    }

    internal class TestEvent : MetaEvent
    {
        public readonly int Value;

        public TestEvent(int value)
        {
            Value = value;
        }
    }
}