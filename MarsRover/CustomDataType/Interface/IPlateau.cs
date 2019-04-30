using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.CustomDataType.Interface
{
    interface IPlateau
    {
        /// <summary>
        /// Set plateau size
        /// </summary>
        /// <param name="size"></param>
        void SetSize(Size size);
        
        /// <summary>
        /// Get plateau size
        /// </summary>
        /// <returns></returns>
        Size GetSize();

        /// <summary>
        /// Check if a point is valid
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        bool IsValid(Coords point);

        /// <summary>
        /// Add obstacle
        /// </summary>
        /// <param name="point"></param>
        void AddObstacle(Coords point);

        /// <summary>
        /// Remove obstacle
        /// </summary>
        /// <param name="point"></param>
        void RemoveObstacle(Coords point);

        /// <summary>
        /// Check if obstacle exists
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        bool FoundObstacle(Coords point);

        /// <summary>
        /// Get all obstacle
        /// </summary>
        /// <returns></returns>
        List<Coords> GetAllObstacle();
    }
}
