using System;
using System.Collections.Generic;
using CoreGameEngine;
namespace SuperMario
{
    public class Level1
    {
        int xdim = 150, ydim = 30;

        int frameLenght = 100;

        private Scene gameScene;


        public Level1()
        {
            CreateLevel();
        }
        private void CreateLevel()
        {
            // Create scene
            ConsoleKey[] quitKeys = new ConsoleKey[] { ConsoleKey.Escape };
            gameScene = new Scene(xdim, ydim,
                new InputHandler(quitKeys),
                new ConsoleRenderer(xdim, ydim, new ConsolePixel(' ')),
                new CollisionHandler(xdim, ydim));
            
            // Create quitter object
            GameObject quitter = new GameObject("Quitter");
            KeyObserver quitSceneKeyListener = new KeyObserver(new ConsoleKey[]
                { ConsoleKey.Escape });
            quitter.AddComponent(quitSceneKeyListener);
            quitter.AddComponent(new Quitter());
            gameScene.AddGameObject(quitter);

            // Create player object
            char[,] playerSprite =
            {
                { ' ', 'M', ' '},
                { 'M', 'M', 'M'},
                { ' ', 'M', ' '}
            };
            GameObject player = new GameObject("Player");
            KeyObserver playerKeyListener = new KeyObserver(new ConsoleKey[] {
                ConsoleKey.RightArrow,
                ConsoleKey.Spacebar,
                ConsoleKey.UpArrow,
                ConsoleKey.LeftArrow});
            player.AddComponent(playerKeyListener);
            Position playerPos = new Position(1f, 26f, 0f);
            player.AddComponent(playerPos);
            player.AddComponent(new Player());
            player.AddComponent(new ConsoleSprite(
                playerSprite, ConsoleColor.Red, ConsoleColor.DarkGreen));
            gameScene.AddGameObject(player);

            // Create walls
            GameObject walls = new GameObject("Walls");
            ConsolePixel wallPixel = new ConsolePixel(
                ' ', ConsoleColor.Blue, ConsoleColor.White);
            Dictionary<Vector2, ConsolePixel> wallPixels =
                new Dictionary<Vector2, ConsolePixel>();
            for (int x = 0; x < xdim; x++)
                wallPixels[new Vector2(x, 0)] = wallPixel;
            for (int x = 0; x < xdim; x++)
                wallPixels[new Vector2(x, ydim - 1)] = wallPixel;
            for (int y = 0; y < ydim; y++)
                wallPixels[new Vector2(0, y)] = wallPixel;
            for (int y = 0; y < ydim; y++)
                wallPixels[new Vector2(xdim - 1, y)] = wallPixel;
            walls.AddComponent(new ConsoleSprite(wallPixels));
            walls.AddComponent(new Position(0, 0, 1));
            gameScene.AddGameObject(walls);
        }

        public void Run()
        {
            gameScene.GameLoop(frameLenght);
        }

    }
}