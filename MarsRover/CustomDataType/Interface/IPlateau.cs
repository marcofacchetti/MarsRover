using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.CustomDataType.Interface
{
    interface IPlateau
    {
        void SetSize(Size size);
        Size GetSize();
        bool IsValid(Coords point);
    }
}
