using System;
using System.Threading;
namespace SuperMario
{
    public class Player
    {
        public char[,] map {get; set;}

        private int playerX;
        private int playerY;
        private ConsoleKey ck;
        private Output Ot;
        public Player(char[,] map, ConsoleKey ck)
        {
            this.map = map;
            this.ck = ck;

            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 'M')
                    {
                        playerX = j;
                        playerY = i;
                    }
                }
            }
            Ot = new Output(map);

        }

        public void Refresh()
        {
            switch(ck)
            {
                case ConsoleKey.A:
                    if(map[playerY, playerX - 1] != '-')
                    {
                        map[playerY, playerX] = ' ';
                        map[playerY, playerX - 1] = 'M';
                    }
                    Ot = new Output(map);    
                break;
                case ConsoleKey.D:
                    if(map[playerY, playerX + 1] != '-')
                    {
                        map[playerY, playerX] = ' ';
                        map[playerY, playerX + 1] = 'M';
                    }
                    Ot = new Output(map);       
                break;
                case ConsoleKey.Spacebar:
                    map[playerY, playerX] = ' ';
                    map[playerY - 1, playerX + 1] = 'M';
                    Ot = new Output(map);
                    Thread.Sleep(100);

                    map[playerY - 1, playerX + 1] = ' ';
                    map[playerY - 2, playerX + 2] = 'M';
                    Ot = new Output(map);
                    Thread.Sleep(100);

                    map[playerY - 2, playerX + 2] = ' ';
                    map[playerY - 1, playerX + 3] = 'M';
                    Ot = new Output(map);
                    Thread.Sleep(100);

                    map[playerY - 1, playerX + 3] = ' ';
                    map[playerY, playerX + 4] = 'M';
                    Ot = new Output(map);
                break;
            }
        }
    }
}