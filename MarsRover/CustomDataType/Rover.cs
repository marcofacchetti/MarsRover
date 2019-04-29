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


        public Rover(Plateau plateau, Coords position, CardinalDirection direction)
        {
            this.Plateau= plateau;
            this.Position = position;
            this.Direction= direction;            
        }

        public void SetPosition(int x, int y, CardinalDirection direction)
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
        }


        /// <summary>
        /// Get Rover position
        /// </summary>
        /// <returns>Rover position (X, Y, Direction) </returns>
        public string GetCurrentPosition()
        {
            return Position.X + " " + Position.Y + " " + Direction;
        }

        public Coords GetPosition()
        {
            return Position;
        }

        public CardinalDirection GetDirection()
        {
            return Direction;
        }

        public void RunCommands(string command)
        {
            for (int i = 0; i < command.Length; i++)
            {
                runSingleCommand(command[i]);
            }
        }

        private bool isValidCommand(char command)
        {
            List<char> commands = new List<char>();
            commands.Add(RoverMovement.Left);
            commands.Add(RoverMovement.Right) ;
            commands.Add(RoverMovement.Forward);
            commands.Add(RoverMovement.Backward);
            return commands.Contains(command);
        }

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
                new RoverCommandException("Wrong parameters " + command);
            }
            
           
        }

        private void raiseObstacleException(int positionX, int positionY)
        {
            throw new RoverObstacleException(String.Format("Found obstacle at position {0} {1}", positionX,positionY));
        }

        private void setNewPosition(int x, int y)
        {
            if (!Plateau.FoundObstacle(new Coords(x, y)))
            {
                Position.X = x;
                Position.Y = y;
            }
            else
                raiseObstacleException(x, y);
        }

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
            setNewPosition(x, y);           
        }

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
            setNewPosition(x, y);
        }

        private void turnLeft()
        {            
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

        private void turnRigth()
        {
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
