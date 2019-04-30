using System;
using MarsRover.CustomDataType;
using MarsRover.Exception;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Test
{
    [TestClass]
    public class RoverUnitTestMovementWithObstacle
    {

        private Plateau plateau = new Plateau();
        private Coords position;
        private Rover rover;


        [TestInitialize]
        public void Initialize()
        {
            plateau.SetSize(new Size(5, 5));            
            position = new Coords(0, 0);            
        }

        [TestMethod]        
        [ExpectedException(typeof(RoverInitException), "Invalid initial position")]
        public void Test_InvalidInitialPosition()
        {
            plateau.AddObstacle(new Coords(0, 0));
            rover = new Rover(plateau, position, CardinalDirection.North);
        }


        [TestMethod]        
        public void Test_ValidInitialPosition_NoExcaption()
        {            
            try
            {
                rover = new Rover(plateau, position, CardinalDirection.North);
            }catch (RoverInitException ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }


        [TestMethod]        
        public void Test_Movement_FoundObstacle_Forward()
        {
            plateau.AddObstacle(new Coords(0, 4));
            plateau.AddObstacle(new Coords(1, 4));

            rover = new Rover(plateau, position, CardinalDirection.North);
            try
            {
                rover.RunCommands("FFFF");
            }catch (RoverObstacleException ex)
            {
                Assert.IsTrue(ex.Message == "Found obstacle at position 0 4", "Expected Message Found obstacle at position 0 4");                
            }
            
            Assert.IsTrue(rover.GetPosition().X == 0, "X must be 0");
            Assert.IsTrue(rover.GetPosition().Y == 3, "X must be 3");
        }

        [TestMethod]        
        public void Test_Movement_FoundObstacle_BackWard()
        {
            plateau.AddObstacle(new Coords(0, 4));
            plateau.AddObstacle(new Coords(1, 4));

            rover = new Rover(plateau, position, CardinalDirection.North);
            try
            {
                rover.RunCommands("BBB");
            }
            catch (RoverObstacleException ex)
            {
                Assert.IsTrue(ex.Message == "Found obstacle at position 0 4", "Expected Message Found obstacle at position 0 4");
            }

            Assert.IsTrue(rover.GetPosition().X == 0, "X must be 0");
            Assert.IsTrue(rover.GetPosition().Y == 5, "X must be 0");
        }
    }
}
