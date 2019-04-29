using MarsRover.CustomDataType.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.CustomDataType
{
    public class Plateau : IPlateau
    {
        private Size size { get; set; }

        public void SetSize(Size size)
        {
            this.size = size;
        }

        public Size GetSize()
        {
            return size;
        }

        public bool IsValid(Coords point)
        {
            var isValidX = point.X >= 0 && point.X <= size.Width;
            var isValidY = point.Y >= 0 && point.Y <= size.Height;
            return isValidX && isValidY;
        }
    }
}
