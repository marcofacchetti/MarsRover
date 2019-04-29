using System;
using MarsRover.CustomDataType;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("Core")]
        [TestProperty("Core", "ReportManagementReview")]
        [Description("Test clinics field. Set All clinic false and then true")]
        public void TestMethod1()
        {

            Plateau plateau = new Plateau();
            plateau.SetSize(new Size(5, 5));
            Coords position = new Coords(0, 0);
            Rover rover = new Rover(plateau, position, CardinalDirection.North);
            
            rover.RunCommands("FFF");
            Coords coords = rover.GetPosition();
            CardinalDirection direction = rover.GetDirection();

            Assert.IsTrue(coords.X == 0,"X = 0");
            Assert.IsTrue(coords.Y == 3, "Y = 3");
            Assert.IsTrue(direction==CardinalDirection.North);
        }
    }
}
