using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MazeGame
{
    public class Block
    {
        public bool canMoveInto { get; set; }
        public Rectangle Rec { get; }

        public Block(double Width, double Height)
        {
            Rec = new Rectangle();
            SetColor(Colors.White);
            Rec.Width = Width;
            Rec.Height = Height;
        }

        public void SetColor(Color color)
        {
            Rec.Fill = new SolidColorBrush(color);
        }

        public void SetPosition(double x, double y)
        {
            Rec.Margin = new Thickness(x - 171, 0, 0, y);
        }
    }
}
