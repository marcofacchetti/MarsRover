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
}
