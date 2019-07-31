// --------------------------------------------------------------------------------------------------------------------
// Created by - Lalasa Ala
// --------------------------------------------------------------------------------------------------------------------
using ConferencePlannerLibrary.Constants;
using ConferencePlannerLibrary.Contracts;
using ConferencePlannerLibrary.Parts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ConferencePlannerLibrary.UnitTests
{
    [TestClass]
    public class ConferencePlannerEventTests
    {
        [TestMethod]
        public void ConferencePlannerEventTest()
        {
            var mockFactory = new Mock<Factory>();
            var klaEvent = new ConferencePlannerEvent(mockFactory.Object);

            string[] items = { "EUV Catch me if you Can (Home Expert) 30 min",
                "Architecting the Intelligent Apps Engineer (Vignette)" ,
                "Atomic Transistors -> Super Computing in your Palm (5 min)"
            };
            klaEvent.CreateEvent(items);
            Assert.AreEqual(klaEvent.Items.Count, 3);
            Assert.AreEqual(klaEvent.Items[0].TalkType, ConferencePlannerConstants.Homeexpert);
            Assert.IsTrue(klaEvent.Items[0] is IConferencePlannerHomeExpert);
            Assert.IsFalse(klaEvent.Items[0] is IConferencePlannerVingette);
            Assert.IsTrue(klaEvent.Items[0] is IConferencePlannerTalk);

            Assert.AreEqual(klaEvent.Items[1].TalkType, ConferencePlannerConstants.Vignette);
            Assert.IsTrue(klaEvent.Items[1] is IConferencePlannerVingette);
            Assert.IsFalse(klaEvent.Items[1] is IConferencePlannerHomeExpert);
            Assert.IsTrue(klaEvent.Items[1] is IConferencePlannerTalk);
        }

    }
}
