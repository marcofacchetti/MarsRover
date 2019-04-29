using MarsRover.CustomDataType;
using MarsRover.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {

            Plateau plateau = new Plateau();
            plateau.SetSize(new Size(5, 5));            
            Coords position = new Coords(0, 0);
            
            Rover rover = new Rover(plateau, position, CardinalDirection.North);
            try
            {
                rover.RunCommands("FFFFFRFFFFFRFFFFFRFFFFFR");
            }
            catch (RoverCommandException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (RoverObstacleException ex)
            {
                System.Console.WriteLine(ex.Message);
            }catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            
            System.Console.WriteLine(rover.GetCurrentPosition());
            System.Console.ReadLine();

        }
    }
}
