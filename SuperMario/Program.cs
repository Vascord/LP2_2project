using System;
using System.Threading;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] map;

            Level1 level = new Level1();
            map = level.map;
            Output Ot = new Output(map);

            ConsoleKey ck = Console.ReadKey().Key;
            while (ck != ConsoleKey.Escape)
            {
                //... Code for Player Movment
            }
        }
    }
}
