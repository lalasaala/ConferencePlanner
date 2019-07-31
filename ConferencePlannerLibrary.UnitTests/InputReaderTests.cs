// --------------------------------------------------------------------------------------------------------------------
// Created by - Lalasa Ala
// --------------------------------------------------------------------------------------------------------------------
using ConferencePlannerLibrary.Parts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConferencePlannerLibrary.UnitTests
{
    [TestClass]
    public class InputReaderTests
    {
        [TestMethod]
        public void InputReaderTest()
        {
            var inputReader = new InputReader();
            var items = inputReader.ReadInputFromString(@"EUV Catch me if you Can (Home Expert) 30 min
                Wonder Defects and Where to find them ? (Home Expert) 75 min
                Architecting the Intelligent Apps Engineer (Vignette)
                Quantum Entangled Inspection(Home Expert) 70 min
                Tesla’s Legacy(Vignette)");
            Assert.AreEqual(items.Length, 5);
        }
    }
}
