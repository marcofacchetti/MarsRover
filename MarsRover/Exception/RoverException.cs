using System;


namespace MarsRover.Exception
{    
    public class RoverCommandException : System.Exception
    {
        public RoverCommandException(string message) : base(message) { }
    }

    public class RoverMovementException : System.Exception
    {
        public RoverMovementException(string message) : base(message) { }
    }

    public class RoverObstacleException : System.Exception
    {
        public RoverObstacleException(string message) : base(message) { }
    }

    public class RoverInitException : System.Exception
    {
       public RoverInitException(string message) : base(message) { }
    }
}
