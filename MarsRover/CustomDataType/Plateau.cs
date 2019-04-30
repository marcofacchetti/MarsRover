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

        /// <summary>
        /// Set plateau size
        /// </summary>
        /// <param name="size"></param>
        public void SetSize(Size size)
        {
            this.size = size;
        }

        /// <summary>
        /// Get plateau size
        /// </summary>
        /// <returns></returns>
        public Size GetSize()
        {
            return size;
        }

        /// <summary>
        /// Check point is valid
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool IsValid(Coords point)
        {
            var isValidX = point.X >= 0 && point.X <= size.Width;
            var isValidY = point.Y >= 0 && point.Y <= size.Height;
            return isValidX && isValidY;
        }

        /// <summary>
        /// Check if obstacle exist
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool FoundObstacle(Coords point)
        {
            return this.Obstacles.Any(o => o.X == point.X && o.Y == point.Y);
        }

        private Coords getObstacle(Coords point)
        {
            return this.Obstacles.FirstOrDefault(o => o.X == point.X && o.Y == point.Y);
        }


        /// <summary>
        /// Add obstacle
        /// </summary>
        /// <param name="point"></param>
        public void AddObstacle(Coords point)
        {
            if (IsValid(point) && !FoundObstacle(point) )
            {
                this.Obstacles.Add(point);
            }            
        }

        /// <summary>
        /// Remove obstacle
        /// </summary>
        /// <param name="point"></param>
        public void RemoveObstacle(Coords point)
        {
            if (IsValid(point))
            {
                Coords obstacle = getObstacle(point);
                if (obstacle != null)
                    this.Obstacles.Remove(obstacle);
            }
        }

        /// <summary>
        ///  Get all obstacle
        /// </summary>
        /// <returns></returns>

        public List<Coords> GetAllObstacle()
        {
            return this.Obstacles;
        }
        
    }
}
