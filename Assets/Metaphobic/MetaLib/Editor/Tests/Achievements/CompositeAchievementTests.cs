using System;
using MetaLib.Achievements;
using MetaLib.Events;
using NUnit.Framework;

namespace MetaLib.Editor.Tests.Achievements
{
    public class CompositeAchievementTests
    {
        [Test]
        public void CompositeAchievement_StartsIncomplete()
        {
            var objective = new StatMAchievementTest(1);
            var achievement = new MCompositeAchievement("", objective);

            Assert.IsFalse(achievement.IsCompleted);
        }

        [Test]
        public void CompositeAchievement_CompletesFor1Objective()
        {
            var objective = new StatMAchievementTest(1);
            var achievement = new MCompositeAchievement("", objective);

            MEvents.RaiseEvent(new TestEvent(1));

            Assert.IsTrue(achievement.IsCompleted);
        }

        [Test]
        public void CompositeAchievement_PartialCompletion()
        {
            var objective1 = new StatMAchievementTest(1);
            var objective2 = new StatMAchievementTest(2);

            var achievement = new MCompositeAchievement("", objective1, objective2);

            MEvents.RaiseEvent(new TestEvent(1));

            Assert.IsTrue(Math.Abs(achievement.Progress - 0.5f) < 0.0001f);
        }

        [Test]
        public void CompositeAchievement_NestedCompletion()
        {
            var objective1 = new StatMAchievementTest(1);
            var objective2 = new StatMAchievementTest(2);
            var objective3 = new MCompositeAchievement("", objective1, objective2);
            var objective4 = new StatMAchievementTest(3);

            var achievement = new MCompositeAchievement("", objective3, objective4);

            MEvents.RaiseEvent(new TestEvent(3));

            Assert.IsTrue(achievement.IsCompleted);
        }

        [Test]
        public void CompositeAchievement_DuplicateObjectives()
        {
            var objective = new StatMAchievementTest(1);

            Assert.Throws<ArgumentException>(() => { new MCompositeAchievement("", objective, objective); });
        }

        [Test]
        public void CompositeAchievement_NoObjective()
        {
            Assert.Throws<ArgumentException>(() => { new MCompositeAchievement(""); });
        }
    }
}