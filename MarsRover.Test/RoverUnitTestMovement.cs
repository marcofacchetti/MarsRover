 rover.RunCommands("FFFFFRFFFFFRFFFFFRFFFFFR");using System;
using MarsRover.CustomDataType;
using MarsRover.Exception;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Test
{
    [TestClass]
    public class RoverUnitTestMovement
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
        public void Test_Go_Forward_1_Step_And_Backward_1_Step()
        {
            rover.RunCommands("FB");
            Coords coords = rover.GetPosition();
            CardinalDirection direction = rover.GetDirection();
            Assert.IsTrue(coords.X == 0 && coords.Y == 0, "Position must be 0,0");
            Assert.IsTrue(direction == CardinalDirection.North, "Direction must be N");
        }


        [TestMethod]
        public void Test_Go_Forward_1_Step_And_Backward_2()
        {
            rover.RunCommands("FBB");
            Coords coords = rover.GetPosition();
            CardinalDirection direction = rover.GetDirection();
            Assert.IsTrue(coords.X == 0 && coords.Y == 5, "Position must be 0,5");
            Assert.IsTrue(direction == CardinalDirection.North, "Direction must be N");
        }

        [TestMethod]
        public void Test_Go_Forward_1_Step_South_Direction()
        {
            rover.SetPosition(0, 0, CardinalDirection.South);
            rover.RunCommands("F");
            Coords coords = rover.GetPosition();
            CardinalDirection direction = rover.GetDirection();
            Assert.IsTrue(coords.X == 0 && coords.Y == 5, "Position must be 0,5");
            Assert.IsTrue(direction == CardinalDirection.South, "Direction must be S");
        }

        [TestMethod]
        public void Test_Go_Backward_5_Step_South_Direction()
        {
            rover.SetPosition(0, 0, CardinalDirection.South);
            rover.RunCommands("BBBBBB");
            Coords coords = rover.GetPosition();
            CardinalDirection direction = rover.GetDirection();
            Assert.IsTrue(coords.X == 0 && coords.Y == 0, "Position must be 0,0");
            Assert.IsTrue(direction == CardinalDirection.South, "Direction must be S");
        }

        [TestMethod]
        public void Test_Perimeter_Plateau_Move_Forward()
        {            
            rover.RunCommands("FFFFF");
            Coords coords = rover.GetPosition();
            CardinalDirection direction = rover.GetDirection();
            Assert.IsTrue(coords.X == 0 && coords.Y == 5, "Position must be 0,5");
            Assert.IsTrue(direction == CardinalDirection.North, "Direction must be N");

            rover.RunCommands("RFFFFF");
            coords = rover.GetPosition();
            direction = rover.GetDirection();
            Assert.IsTrue(coords.X == 5 && coords.Y == 5, "Position must be 5,5");
            Assert.IsTrue(direction == CardinalDirection.East, "Direction must be E");

            rover.RunCommands("RFFFFF");
            coords = rover.GetPosition();
            direction = rover.GetDirection();
            Assert.IsTrue(coords.X == 5 && coords.Y == 0, "Position must be 5,0");
            Assert.IsTrue(direction == CardinalDirection.South, "Direction must be S");

            rover.RunCommands("RFFFFF");
            coords = rover.GetPosition();
            direction = rover.GetDirection();
            Assert.IsTrue(coords.X == 0 && coords.Y == 0, "Position must be 0,0");
            Assert.IsTrue(direction == CardinalDirection.West, "Direction must be W");

            rover.RunCommands("R");
            coords = rover.GetPosition();
            direction = rover.GetDirection();
            Assert.IsTrue(coords.X == 0 && coords.Y == 0, "Position must be 0,0");
            Assert.IsTrue(direction == CardinalDirection.North, "Direction must be N");
        }

        [TestMethod]
        public void Test_Perimeter_Plateau_Move_Backward()
        {            
            rover.RunCommands("LBBBBB");
            Coords coords = rover.GetPosition();
            CardinalDirection direction = rover.GetDirection();
            Assert.IsTrue(coords.X == 5 && coords.Y == 0, "Position must be 5,0");
            Assert.IsTrue(direction == CardinalDirection.West, "Direction must be W");

            rover.RunCommands("LBBBBB");
            coords = rover.GetPosition();
            direction = rover.GetDirection();
            Assert.IsTrue(coords.X == 5 && coords.Y == 5, "Position must be 5,5");
            Assert.IsTrue(direction == CardinalDirection.South, "Direction must be S");

            rover.RunCommands("LBBBBB");
            coords = rover.GetPosition();
            direction = rover.GetDirection();
            Assert.IsTrue(coords.X == 0 && coords.Y == 5, "Position must be 0,5");
            Assert.IsTrue(direction == CardinalDirection.East, "Direction must be E");

            rover.RunCommands("LBBBBB");
            coords = rover.GetPosition();
            direction = rover.GetDirection();
            Assert.IsTrue(coords.X == 0 && coords.Y == 0, "Position must be 0,0");
            Assert.IsTrue(direction == CardinalDirection.North, "Direction must be W");           
        }

        [TestMethod]
        [ExpectedException(typeof(RoverCommandException))]
        public void Test_InvalidCommand()
        {
            rover.RunCommands("X");
        }

    }
}
