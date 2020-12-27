using System;
namespace SuperMario
{
    public class Level1
    {
        public char[,] map {get;}

        public Level1()
        {
            map = new char[10, 120];
            FillMap();
        }

        private void FillMap()
        {
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    if (i == 0 || i == (map.GetLength(0) - 1) || j == 0 || j == (map.GetLength(1) - 1))
                    {
                        map[i, j] = '-';
                    }
                    else if(i == 6 || i == 7 || i == 8 )
                    {
                        if (j != 14 && j != 15 && j != 38 && j != 39 &&
                            j != 60 && j != 61 && j != 90 && j != 91)
                            map[i, j] = '-';
                    }
                    else
                    {
                        map[i, j] = ' ';
                    }
                }
            }
            map[5, 1] = 'M';
            Console.WriteLine(map.GetLength(1));
        }

    }
}