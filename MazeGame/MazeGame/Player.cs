using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MazeGame
{
    class Player : Block
    {
        public int Orientation;
        public int X;
        public int Y;
        public Maze maze;

        public Player(Maze maze, double Width, double Height, int X, int Y) : base(Width, Height)
        {
            this.maze = maze;
            canMoveInto = false;
            SetColor(Colors.Green);
        }

        public void TurnLeft()
        {
            Orientation--;
        }

        public void TurnRight()
        {
            Orientation++;
        }

        public void Forward()
        {
            int Orient = Orientation % 4;
            if(Orient < 0)
            {
                Orient += 4;
            }
            switch (Orient)
            {
                case 0:
                    if (!(maze.Blocks.GetLength(1) < Y + 1) && maze.Blocks[X, Y + 1].canMoveInto)
                        Y++;
                    break;
                case 1:
                    if (!(maze.Blocks.GetLength(0) < X + 1) && maze.Blocks[X + 1, Y].canMoveInto)
                        X++;
                    break;
                case 2:
                    if (!(Y - 1 < 0) && maze.Blocks[X, Y - 1].canMoveInto)
                        Y--;
                    break;
                case 3:
                    if (!(X - 1 < 0) && maze.Blocks[X - 1, Y].canMoveInto)
                        X--;
                    break;

            }
        }
    }
}
