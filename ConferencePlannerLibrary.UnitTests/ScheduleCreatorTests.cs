// --------------------------------------------------------------------------------------------------------------------
// Created by - Lalasa Ala
// --------------------------------------------------------------------------------------------------------------------

using ConferencePlannerLibrary.Contracts;
using ConferencePlannerLibrary.Parts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ConferencePlannerLibrary.UnitTests
{
    [TestClass]
    public class ScheduleCreatorTests
    {
        [TestMethod]
        public void CreateScheduleTest()
        {
            var factory = new Mock<Factory>().Object;
            var klaEvent = new ConferencePlannerEvent(factory);
            var algorithm = new SchedulerAlgorithm(klaEvent, factory);
            string[] items = { "EUV Catch me if you Can (Home Expert) 30 min",
                "Architecting the Intelligent Apps Engineer (Vignette)",
                "Atomic Transistors -> Super Computing in your Palm (5 min)"
            };
            var objScheduleCreator = new ScheduleCreator(klaEvent, algorithm);
            string schedule = objScheduleCreator.CreateSchedule(items);
            Assert.IsTrue(schedule.Length > 0);
        }
    }
}
