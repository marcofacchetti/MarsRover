using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.CustomDataType.Interface
{
    public interface IRover
    {
        void SetPosition(int x, int y, CardinalDirection direction);
        string GetCurrentPosition();
        Coords GetPosition();
        CardinalDirection GetDirection();
        void RunCommands(string command);


    }
}
