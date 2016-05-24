using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MazeGame
{
    public class Wall : Block
    {
        public Wall(double Width, double Height) : base(Width, Height)
        {
            canMoveInto = false;
            SetColor(Colors.Blue);
        }
    }
}
