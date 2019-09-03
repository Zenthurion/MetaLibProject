using System;
using MetaLib.Events;
using NUnit.Framework;

namespace MetaLib.Editor.Tests.Achievements
{
    public class StatAchievementTests
    {
        [Test]
        public void StatAchievement_StartsIncomplete()
        {
            var achievement = new StatMAchievementTest(1);
            Assert.IsFalse(achievement.IsCompleted);
        }

        [Test]
        public void StatAchievement_CompleteCorrect()
        {
            var achievement = new StatMAchievementTest(1);

            MEvents.RaiseEvent(new TestEvent(1));

            Assert.IsTrue(achievement.IsCompleted);
        }

        [Test]
        public void StatAchievement_NotCompleted()
        {
            var achievement = new StatMAchievementTest(2);

            MEvents.RaiseEvent(new TestEvent(1));

            Assert.IsFalse(achievement.IsCompleted);
        }

        [Test]
        public void StatAchievement_PartCompleted()
        {
            var achievement = new StatMAchievementTest(2);

            MEvents.RaiseEvent(new TestEvent(1));

            Assert.IsTrue(Math.Abs(achievement.Progress - 0.5f) < 0.0001f);
        }

        [Test]
        public void StatAchievement_NegativeTarget()
        {
            Assert.Throws<ArgumentException>(() => { new StatMAchievementTest(-1); });
        }

        [Test]
        public void StatAchievement_ZeroTarget()
        {
            Assert.Throws<ArgumentException>(() => { new StatMAchievementTest(0); });
        }
    }
}