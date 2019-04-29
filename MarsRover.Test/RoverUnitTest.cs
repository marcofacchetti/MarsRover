using System;
using MarsRover.CustomDataType;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Test
{
    [TestClass]
    public class UnitTestMovement
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
        public void Test_TurnRight_One_Once()
        {           
            rover.RunCommands("R");
            Coords coords = rover.GetPosition();
            CardinalDirection direction = rover.GetDirection();
            Assert.IsTrue(coords.X == position.X && coords.Y == position.Y, "Position must be 0,0");
            Assert.IsTrue(direction == CardinalDirection.East, "Direction must be E");
        }

        [TestMethod]
        public void Test_TurnRight_Twice()
        {            
            rover.RunCommands("RR");
            Coords coords = rover.GetPosition();
            CardinalDirection direction = rover.GetDirection();
            Assert.IsTrue(coords.X == position.X && coords.Y == position.Y, "Position must be 0,0");
            Assert.IsTrue(direction == CardinalDirection.South, "Direction must be S");
        }

        [TestMethod]       
        public void Test_TurnRight_StartPositionNorth_After_4R_Return_North()
        {                
            rover.RunCommands("RRRR");
            Coords coords = rover.GetPosition();
            CardinalDirection direction = rover.GetDirection();
            Assert.IsTrue(coords.X == position.X && coords.Y == position.Y, "Position must be 0,0");
            Assert.IsTrue(direction == CardinalDirection.North, "Direction must be N");            
        }

        [TestMethod]
        public void Test_TurnRight_StartPositionNorth_TurnRigthAndLeft()
        {
            rover.RunCommands("RL");
            Coords coords = rover.GetPosition();
            CardinalDirection direction = rover.GetDirection();
            Assert.IsTrue(coords.X == position.X && coords.Y == position.Y, "Position must be 0,0");
            Assert.IsTrue(direction == CardinalDirection.North, "Direction must be N");
        }


        [TestMethod]
        public void Test_GotoUpperLeft()
        {
            rover.RunCommands("FFFFF");
            Coords coords = rover.GetPosition();
            CardinalDirection direction = rover.GetDirection();
            Assert.IsTrue(coords.X == 0 && coords.Y == 5, "Position must be 0,5");
            Assert.IsTrue(direction == CardinalDirection.North, "Direction must be N");
        }

        [TestMethod]
        public void Test_Go_forward_1_Step_and_backward_1_Step()
        {
            rover.RunCommands("FB");
            Coords coords = rover.GetPosition();
            CardinalDirection direction = rover.GetDirection();
            Assert.IsTrue(coords.X == 0 && coords.Y == 0, "Position must be 0,0");
            Assert.IsTrue(direction == CardinalDirection.North, "Direction must be N");
        }


        [TestMethod]
        public void Test_Go_forward_1_Step_and_backward_2_Step()
        {
            rover.RunCommands("FBB");
            Coords coords = rover.GetPosition();
            CardinalDirection direction = rover.GetDirection();
            Assert.IsTrue(coords.X == 0 && coords.Y == 5, "Position must be 0,5");
            Assert.IsTrue(direction == CardinalDirection.North, "Direction must be N");
        }
    }
}
