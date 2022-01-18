using System;

namespace GameOfLife
{
    public class Engine
    {
        private int WorldHeight;
        private int WorldWidth;
        public byte[,] World { get; private set; }

        private Engine(Configuration configuration)
        {
            this.WorldHeight = configuration.WorldHeight;
            this.WorldWidth = configuration.WorldWidth;
            this.World = configuration.StartingWorld != null ? configuration.StartingWorld : this.GenerateWorld();
        }

        public static Engine Of(Configuration configuration)
        {
            return new Engine(configuration);
        }

        private byte[,] GenerateWorld()
        {
            byte[,] world = new byte[this.WorldHeight, this.WorldWidth];

            Random rng = new Random();
            for (int i = 0; i < this.WorldHeight; i += 1)
            {
                for (int j = 0; j < this.WorldWidth; j += 1)
                {
                    world[i, j] = (byte) rng.Next(2);
                }
            }

            return world;
        }

        public byte[,] ProcessNewTurn()
        {
            for (int i = 0; i < this.WorldHeight; i++)
            {
                for (int j = 0; j < this.WorldWidth; j++)
                {
                    int aliveNeighbors = this.GetAliveNeighbors(i, j);

                    if (this.World[i, j] == 1)
                    {
                        if (aliveNeighbors < 2)
                        {
                            this.World[i, j] = 0;
                        }

                        if (aliveNeighbors > 3)
                        {
                            this.World[i, j] = 0;
                        }
                    }
                    else
                    {
                        if (aliveNeighbors == 3)
                        {
                            this.World[i, j] = 0;
                        }
                    }
                }
            }

            return this.World;
        }

        private int GetAliveNeighbors(int x, int y)
        {
            int aliveNeighbors = 0;

            for (int i = x - 1; i < x + 2; i += 1)
            {
                for (int j = y - 1; j < y + 2; j += 1)
                {
                    if (!((i < 0 || j < 0) || (i >= this.WorldHeight || j >= this.WorldWidth)) && this.World[i, j] == 1) // todo
                    {
                        aliveNeighbors += 1;
                    }
                }
            }

            return aliveNeighbors;
        }
    }
}
