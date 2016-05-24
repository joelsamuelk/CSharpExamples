using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace MazeGame
{
    class Maze
    {
        public Random Random = new Random();
        public Block[,] Blocks { get; }
        public Player Player;
        public int WidthBlocks;
        public int HeightBlocks;
        public double Width;
        public double Height;
        public Maze(double Width, double Height)
        {
            this.Width = Width;
            this.Height = Height;
            WidthBlocks = Random.Next(10, 30);
            HeightBlocks = Random.Next(10, 50);
            Blocks = new Block[HeightBlocks, WidthBlocks];
        }

        public Block[,] GenerateMaze()
        {
            try
            {
                double widthOfBlock = Width / WidthBlocks;
                double heightOfBlock = Height / HeightBlocks;
                for (int i = 0; i < HeightBlocks; i++)
                {
                    for (int j = 0; j < WidthBlocks; j++)
                    {
                        int chance = Random.Next(0, 100);
                        if(chance <= 20)
                        {
                            Wall w = new Wall(widthOfBlock, heightOfBlock);
                            w.SetPosition(j * widthOfBlock, i * heightOfBlock);
                            Blocks[i, j] = w;
                        }
                        else
                        {
                            Block b = new Block(widthOfBlock, heightOfBlock);
                            b.SetPosition(j * widthOfBlock, i * heightOfBlock);
                            Blocks[i, j] = b;
                        }
                        /*if (j == 0)
                        {
                            Wall w = new Wall(widthOfBlock, heightOfBlock);
                            w.SetPosition(j * widthOfBlock, i * heightOfBlock);
                            Blocks[i, j] = w;
                        }
                        if (i == WidthBlocks)
                        {
                            Wall w = new Wall(widthOfBlock, heightOfBlock);
                            w.SetPosition(j * widthOfBlock, i * heightOfBlock);
                            Blocks[i, j] = w;
                        }

                        if (j == HeightBlocks)
                        {
                            Wall w = new Wall(widthOfBlock, heightOfBlock);
                            w.SetPosition(j * widthOfBlock, i * heightOfBlock);
                            Blocks[i, j] = w;
                        }

                        if (i == WidthBlocks)
                        {
                            Wall w = new Wall(widthOfBlock, heightOfBlock);
                            w.SetPosition(j * widthOfBlock, i * heightOfBlock);
                            Blocks[i, j] = w;
                        }*/
                    }
                }
                Player = new Player(this, widthOfBlock, heightOfBlock, 0, 0);
                Blocks[0, WidthBlocks - 1] = Player;
                return Blocks;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public Block[,] ParseCommand(char Direction, int Times)
        {
            for (int i = 0; i < Times; i++)
            {
                switch (Direction)
                {
                    case 'F':
                        Player.Forward();
                        break;
                    case 'L':
                        Player.TurnLeft();
                        break;
                    case 'R':
                        Player.TurnRight();
                        break;
                }
            }
            Blocks[Player.X, Player.Y] = Player;
            return Blocks;
        }
    }
}
