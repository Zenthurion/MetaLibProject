using System;
using DwarvenSoftware.Events;
using NUnit.Framework;

namespace Editor.Tests.Achievements
{
    public class StatAchievementTests
    {
        [Test]
        public void StatAchievement_StartsIncomplete()
        {
            var achievement = new StatDSAchievementTest(1);
            Assert.IsFalse(achievement.IsCompleted);
        }

        [Test]
        public void StatAchievement_CompleteCorrect()
        {
            var achievement = new StatDSAchievementTest(1);

            DSEvents.RaiseEvent(new TestEvent(1));

            Assert.IsTrue(achievement.IsCompleted);
        }

        [Test]
        public void StatAchievement_NotCompleted()
        {
            var achievement = new StatDSAchievementTest(2);

            DSEvents.RaiseEvent(new TestEvent(1));

            Assert.IsFalse(achievement.IsCompleted);
        }

        [Test]
        public void StatAchievement_PartCompleted()
        {
            var achievement = new StatDSAchievementTest(2);

            DSEvents.RaiseEvent(new TestEvent(1));

            Assert.IsTrue(Math.Abs(achievement.Progress - 0.5f) < 0.0001f);
        }

        [Test]
        public void StatAchievement_NegativeTarget()
        {
            Assert.Throws<ArgumentException>(() => { new StatDSAchievementTest(-1); });
        }

        [Test]
        public void StatAchievement_ZeroTarget()
        {
            Assert.Throws<ArgumentException>(() => { new StatDSAchievementTest(0); });
        }
    }
}