using System;
using DwarvenSoftware.Framework.Achievements;
using DwarvenSoftware.Framework.Events;
using NUnit.Framework;

namespace DwarvenSoftware.Framework.Editor.Tests.Achievements
{
    public class CompositeAchievementTests
    {
        [Test]
        public void CompositeAchievement_StartsIncomplete()
        {
            var objective = new StatDSAchievementTest(1);
            var achievement = new DSCompositeAchievement("", objective);

            Assert.IsFalse(achievement.IsCompleted);
        }

        [Test]
        public void CompositeAchievement_CompletesFor1Objective()
        {
            var objective = new StatDSAchievementTest(1);
            var achievement = new DSCompositeAchievement("", objective);

            DSEvents.RaiseEvent(new TestEvent(1));

            Assert.IsTrue(achievement.IsCompleted);
        }

        [Test]
        public void CompositeAchievement_PartialCompletion()
        {
            var objective1 = new StatDSAchievementTest(1);
            var objective2 = new StatDSAchievementTest(2);

            var achievement = new DSCompositeAchievement("", objective1, objective2);

            DSEvents.RaiseEvent(new TestEvent(1));

            Assert.IsTrue(Math.Abs(achievement.Progress - 0.5f) < 0.0001f);
        }

        [Test]
        public void CompositeAchievement_NestedCompletion()
        {
            var objective1 = new StatDSAchievementTest(1);
            var objective2 = new StatDSAchievementTest(2);
            var objective3 = new DSCompositeAchievement("", objective1, objective2);
            var objective4 = new StatDSAchievementTest(3);

            var achievement = new DSCompositeAchievement("", objective3, objective4);

            DSEvents.RaiseEvent(new TestEvent(3));

            Assert.IsTrue(achievement.IsCompleted);
        }

        [Test]
        public void CompositeAchievement_DuplicateObjectives()
        {
            var objective = new StatDSAchievementTest(1);

            Assert.Throws<ArgumentException>(() => { new DSCompositeAchievement("", objective, objective); });
        }

        [Test]
        public void CompositeAchievement_NoObjective()
        {
            Assert.Throws<ArgumentException>(() => { new DSCompositeAchievement(""); });
        }
    }
}