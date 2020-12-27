using System;
using System.Threading;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] map;
            Player player;

            Level1 level = new Level1();
            map = level.map;
            Output Ot = new Output(map);

            ConsoleKey ck = Console.ReadKey().Key;
            while (ck != ConsoleKey.Escape)
            {
                ck = Console.ReadKey().Key;

                player = new Player(map, ck);
                player.Refresh();
                map = player.map;

                //Ot = new Output(map);

                //Thread.Sleep(100);
            }
        }
    }
}
