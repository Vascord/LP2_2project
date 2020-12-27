using System;
namespace SuperMario
{
    public class Output
    {
        private char[,] map; 
        public Output(char[,] map)
        {
            this.map = map;
            OutMap();
        }

        private void OutMap()
        {
            Console.Clear();
            for(int i = 0; i < map.GetLength(0); i++)
            {
                Console.WriteLine();
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == '-')
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(" ");
                    }                        
                    else
                    {
                        Console.ResetColor();
                        Console.Write(map[i, j]);
                    }
                    
                }
            }
            Console.ResetColor();
        }
    }
}