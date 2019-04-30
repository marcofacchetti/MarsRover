using MarsRover.CustomDataType.Interface;
using MarsRover.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.CustomDataType
{
    public class Rover: IRover
    {
        private Coords Position { get; set; }
        private CardinalDirection Direction { get; set; }
        private Plateau Plateau { get; set; }
        private List<char> CommandsAvaible = new List<char> { RoverMovement.Left, RoverMovement.Right, RoverMovement.Forward, RoverMovement.Backward };
        
        
        public Rover(Plateau plateau, Coords position, CardinalDirection direction)
        {
            if (isValidRoverPosition(plateau, position))
            {
                this.Plateau = plateau;
                this.Position = position;
                this.Direction = direction;
            }
            else
                throw new RoverInitException("Invalid initial position");
            
        }

        /// <summary>
        /// Check if rover position is valid. verify that the point is contained in the grid. Also check if in coord there'is not a obstacle.
        /// </summary>
        /// <param name="plateau"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        private bool isValidRoverPosition(Plateau plateau, Coords position)
        {
            bool validPoint = position.X >= plateau.GetSize().MinWidth && position.X <= plateau.GetSize().Width && position.Y >= plateau.GetSize().MinHeight && position.Y <= plateau.GetSize().Height;
            bool foundObstacle = plateau.FoundObstacle(position);
            return validPoint && !foundObstacle;
        }


        /// <summary>
        /// Set rover position. If position is invalid throw RoverInitException
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        public void SetPosition(int x, int y, CardinalDirection direction)
        {
            if (isValidRoverPosition(Plateau,new Coords(x, y)))
            {
                if (Position == null)
                {
                    Position = new Coords(x, y);
                }
                else
                {
                    Position.X = x;
                    Position.Y = y;
                }
                Direction = direction;
            }else
            {
                throw new RoverInitException("Invalid initial position");
            }            
        }



        /// <summary>
        /// Get rover position
        /// </summary>
        /// <returns>Rover position (X, Y, Direction) </returns>
        public string GetCurrentPosition()
        {
            return Position.X + " " + Position.Y + " " + Direction;
        }

        /// <summary>
        /// Get rover position
        /// </summary>
        /// <returns></returns>
        public Coords GetPosition()
        {
            return Position;
        }

        /// <summary>
        /// Get rover direction
        /// </summary>
        /// <returns></returns>
        public CardinalDirection GetDirection()
        {
            return Direction;
        }


        /// <summary>
        /// Run command
        /// </summary>
        /// <returns></returns>
        public void RunCommands(string command)
        {
            for (int i = 0; i < command.Length; i++)
            {
                runSingleCommand(command[i]);
            }
        }

        /// <summary>
        /// Check if command is valid
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private bool isValidCommand(char command)
        {            
            return CommandsAvaible.Contains(command);
        }


        /// <summary>
        /// Run single command. Firs check if command is valid.
        /// </summary>
        /// <param name="command"></param>
        private void runSingleCommand(char command)
        {
            if (isValidCommand(command)){
                switch (command)
                {
                    case RoverMovement.Left:                                                   
                        turnLeft();
                        break;                        
                    case RoverMovement.Right:                    
                        turnRigth();
                        break;                       
                    case RoverMovement.Forward:                        
                        moveForward();                            
                        break;                        
                    case RoverMovement.Backward:
                        moveBackward();
                        break;
                    default:
                        {
                            break;

                        }
                }
            }
            else
            {
                throw new RoverCommandException("Wrong parameters " + command);
            }                       
        }

        private void raiseObstacleException(int positionX, int positionY)
        {
            throw new RoverObstacleException(String.Format("Found obstacle at position {0} {1}", positionX,positionY));
        }

        /// <summary>
        /// Set new position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void setNewPosition(int x, int y)
        {      
            // if found obstacle raise exception.
            if (!Plateau.FoundObstacle(new Coords(x, y)))
            {
                Position.X = x;
                Position.Y = y;
            }
            else
                raiseObstacleException(x, y);
        }

        /// <summary>
        /// Move forward
        /// </summary>
        private void moveForward()
        {
            int x=Position.X;
            int y=Position.Y;
            switch (Direction)
            {
                case CardinalDirection.North:
                    y= Position.Y < Plateau.GetSize().Height ? Position.Y + 1 : Plateau.GetSize().MinHeight;                    
                    break;
                case CardinalDirection.East:
                    x= Position.X < Plateau.GetSize().Width ? Position.X + 1 : Plateau.GetSize().MinWidth;                    
                    break;                                        
                case CardinalDirection.South:
                    y= Position.Y > Plateau.GetSize().MinHeight ? Position.Y - 1 : Plateau.GetSize().Height;                    
                    break;
                case CardinalDirection.West:
                    x = Position.X > Plateau.GetSize().MinWidth ? Position.X - 1 : Plateau.GetSize().Width;                    
                    break;
            }
            // try to set new position.
            setNewPosition(x, y);           
        }

        /// <summary>
        /// Move backward
        /// </summary>
        private void moveBackward()
        {
            int x=Position.X;
            int y=Position.Y;
            switch (Direction)
            {
                case CardinalDirection.North:
                    y = Position.Y > Plateau.GetSize().MinHeight ? Position.Y - 1 : Plateau.GetSize().Height;                    
                    break;
                case CardinalDirection.East:
                    x= Position.X> Plateau.GetSize().MinWidth? Position.X-1:Plateau.GetSize().Width;                    
                    break;
                case CardinalDirection.South:
                    y = Position.Y < Plateau.GetSize().Height ? Position.Y + 1 : Plateau.GetSize().MinHeight;                    
                    break;
                case CardinalDirection.West:
                    x = Position.X < Plateau.GetSize().Width ? Position.X + 1 : Plateau.GetSize().MinWidth;                    
                    break;
            }
            // try to set new position.
            setNewPosition(x, y);
        }

        /// <summary>
        /// Turn left
        /// </summary>
        private void turnLeft()
        {            
            /*
             *    N
             * W     E
             *    S
             */
            switch (this.Direction)
            {
                case CardinalDirection.North:
                    this.Direction = CardinalDirection.West;
                    break;
                case CardinalDirection.West:
                    this.Direction = CardinalDirection.South;
                    break;
                case CardinalDirection.South:
                    this.Direction = CardinalDirection.East;
                    break;
                case CardinalDirection.East:
                    this.Direction = CardinalDirection.North;
                    break;                
                default:
                    break;
            }
        }


        /// <summary>
        /// Turn Rigth
        /// </summary>
        private void turnRigth()
        {
            /*
             *    N
             * W     E
             *    S
             */
            switch (this.Direction)
            {
                case CardinalDirection.North:
                    this.Direction = CardinalDirection.East;
                    break;
                case CardinalDirection.East:
                    this.Direction = CardinalDirection.South;
                    break;
                case CardinalDirection.South:
                    this.Direction = CardinalDirection.West;
                    break;
                case CardinalDirection.West:
                    this.Direction = CardinalDirection.North;
                    break;
                default:
                    break;
            }
        }                        
    }
}
