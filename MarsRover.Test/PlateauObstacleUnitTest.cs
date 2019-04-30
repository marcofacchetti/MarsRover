using System;
using MarsRover.CustomDataType;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Test
{
    [TestClass]
    public class PlateauObstacleUnitTest
    {

        private Plateau plateau = new Plateau();
        private Coords position;
        private Rover rover;


        [TestInitialize]
        public void Initialize()
        {
            plateau.SetSize(new Size(5, 5));
            position = new Coords(0, 0);
            rover = new Rover(plateau, position, CardinalDirection.North);
        }

        [TestMethod]
        public void Test_AddObstacle()
        {
            plateau.AddObstacle(new Coords(0, 2));
            Assert.IsTrue(plateau.GetAllObstacle().Count == 1, "List must contain 1 item");            
        }

        [TestMethod]
        public void Test_AddInvalidObstacle()
        {
            plateau.AddObstacle(new Coords(6, 2));
            Assert.IsTrue(plateau.GetAllObstacle().Count == 0, "List must contain 0 item");
        }

        [TestMethod]
        public void Test_AddRemoveObstacle()
        {
            plateau.AddObstacle(new Coords(0, 2));
            plateau.RemoveObstacle(new Coords(0, 2));
            Assert.IsTrue(plateau.GetAllObstacle().Count == 0, "List must contain 0 item");
        }

        [TestMethod]
        public void Test_AddObstacleRemoveInvalid()
        {
            plateau.AddObstacle(new Coords(0, 2));
            plateau.RemoveObstacle(new Coords(0, 1));
            Assert.IsTrue(plateau.GetAllObstacle().Count == 1, "List must contain 1 item");
        }

        [TestMethod]
        public void Test_AddObstacleTwice()
        {
            plateau.AddObstacle(new Coords(0, 2));
            plateau.AddObstacle(new Coords(0, 2));            
            Assert.IsTrue(plateau.GetAllObstacle().Count == 1, "List must contain 1 item");
        }

        [TestMethod]
        public void Test_RemoveObstacleListEmpty()
        {
            plateau.RemoveObstacle(new Coords(0, 2));            
            Assert.IsTrue(plateau.GetAllObstacle().Count == 0, "List must contain 0 item");
        }


        [TestMethod]
        public void Test_AddTwoObstacles()
        {
            plateau.AddObstacle(new Coords(0, 2));
            plateau.AddObstacle(new Coords(0, 3));
            Assert.IsTrue(plateau.GetAllObstacle().Count == 2, "List must contain 2 items");
        }

        [TestMethod]
        public void Test_AddObstacleAndFound()
        {
            plateau.AddObstacle(new Coords(0, 2));
            Assert.IsTrue(plateau.FoundObstacle(new Coords(0, 2)), "Result must be true");            
        }
    }
}
