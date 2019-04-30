using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.CustomDataType.Interface
{
    public interface IRover
    {
        
        /// <summary>
        /// Set rover position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        void SetPosition(int x, int y, CardinalDirection direction);

        /// <summary>
        /// Get rover position (x,y, direction)
        /// </summary>
        /// <returns></returns>
        string GetCurrentPosition();

        /// <summary>
        /// Get rover position (x,y)
        /// </summary>
        /// <returns></returns>
        Coords GetPosition();

        /// <summary>
        /// Get rover direction
        /// </summary>
        /// <returns></returns>
        CardinalDirection GetDirection();


        /// <summary>
        /// Run commands
        /// </summary>
        /// <param name="command"></param>
        void RunCommands(string command);

        
    }
}
