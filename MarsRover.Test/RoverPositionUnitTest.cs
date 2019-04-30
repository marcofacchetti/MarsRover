using System;
using MarsRover.CustomDataType;
using MarsRover.Exception;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Test
{
    [TestClass]
    public class RoverPositionUnitTest
    {
        private Plateau plateau = new Plateau();
        private Coords position;
        private Rover rover;


        [TestInitialize]
        public void Initialize()
        {
            plateau.SetSize(new Size(5, 5));
            
        }

        [TestMethod]
        [ExpectedException(typeof(RoverInitException), "Invalid initial position")]
        public void Test_SetInvalidRoverPositionConstructor()
        {
            position = new Coords(6, 0);            
            rover = new Rover(plateau, position, CardinalDirection.North);
        }

        [TestMethod]
        [ExpectedException(typeof(RoverInitException), "Invalid initial position")]
        public void Test_SetValidRoverPosition()
        {
            position = new Coords(0, 0);
            rover = new Rover(plateau, position, CardinalDirection.North);
            rover.SetPosition(9, 0,CardinalDirection.East);
        }

        [TestMethod]      
        public void Test_ValidRoverPosition()
        {
            position = new Coords(0, 0);
            rover = new Rover(plateau, position, CardinalDirection.North);
            rover.SetPosition(5, 5, CardinalDirection.East);
            Assert.IsTrue(rover.GetPosition().X == 5, "X must be 5");
            Assert.IsTrue(rover.GetPosition().Y == 5, "Y must be 5");
            Assert.IsTrue(rover.GetDirection()==CardinalDirection.East, "Direction must be E");
        }


      
    }
}
