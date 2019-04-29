using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.CustomDataType
{
    public class Size
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int MinWidth { get; set; } = 0;
        public int MinHeight { get; set; } = 0;

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Size(int minWidth , int minHeight, int width, int height)
        {
            MinWidth = minWidth;
            MinHeight = minHeight;    
            Width = width;
            Height = height;
        }
    }
}
