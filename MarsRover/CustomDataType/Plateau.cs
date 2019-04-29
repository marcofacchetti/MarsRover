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
        private List<Coords> Obstacles { get; set; } = new List<Coords>();
        
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

        public bool FoundObstacle(Coords point)
        {
            return this.Obstacles.Any(o => o.X == point.X && o.Y == point.Y);
        }

        private Coords getObstacle(Coords point)
        {
            return this.Obstacles.FirstOrDefault(o => o.X == point.X && o.Y == point.Y);
        }

        public void AddObstacle(Coords point)
        {
            if (IsValid(point) && !FoundObstacle(point) )
            {
                this.Obstacles.Add(point);
            }            
        }



        public void RemoveObstacle(Coords point)
        {
            if (IsValid(point))
            {
                Coords obstacle = getObstacle(point);
                if (obstacle != null)
                    this.Obstacles.Remove(obstacle);
            }
        }

        public List<Coords> GetAllObstacle()
        {
            return this.Obstacles;
        }
        
    }
}
