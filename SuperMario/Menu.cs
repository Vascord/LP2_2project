using System;
using System.Collections.Generic;
using CoreGameEngine;
namespace SuperMario
{
    public class Menu
    {
        int xdim = 150, ydim = 30;

        int frameLenght = 10;

        private Scene gameScene;

        public Menu()
        {
            CreateMenu();
        }

        private void CreateMenu()
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

            // Creates title
            char[,] titleSprite = 
            {
                {'■','■','■',' ','■',' ','■','■','■','■','■'},
                {'■',' ','■',' ','■',' ',' ','■',' ',' ',' '},
                {'■',' ','■','■','■',' ','■','■','■','■','■'},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {'■','■','■','■','■',' ','■','■','■','■','■'},
                {' ',' ',' ',' ','■',' ','■',' ','■',' ',' '},
                {'■','■','■','■','■',' ','■','■','■','■','■'},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {'■','■','■','■','■',' ','■','■','■','■','■'},
                {'■',' ','■',' ',' ',' ','■',' ','■','■',' '},
                {'■','■','■',' ',' ',' ','■','■','■',' ','■'},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {'■','■','■','■','■',' ','■',' ',' ',' ','■'},
                {'■',' ','■',' ','■',' ','■','■','■','■','■'},
                {'■',' ','■',' ','■',' ','■',' ',' ',' ','■'},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {'■','■','■','■','■',' ','■','■','■','■','■'},
                {'■',' ','■','■',' ',' ','■',' ',' ',' ','■'},
                {'■','■','■',' ','■',' ','■','■','■','■','■'}
            };
            GameObject title = new GameObject("Title");
            Position titlePos = new Position(65f, 3f, 0f);
            title.AddComponent(titlePos);
            title.AddComponent(new Title());
            title.AddComponent(new ConsoleSprite(
                titleSprite, ConsoleColor.Red, ConsoleColor.Gray));
            gameScene.AddGameObject(title);

            // Creates button and indicator
            char[,] buttonSprite = 
            {
                {'P',' ',' ','Q'},
                {'l',' ',' ','u'},
                {'a',' ',' ','i'},
                {'y',' ',' ','t'}
            };
            char[,] indicatorSprite = 
            {
                {'>'},
                {' '},
                {' '},
                {' '},
                {' '},
                {'<'}
            };
            KeyObserver buttonKeyListener = new KeyObserver(new ConsoleKey[]
                { ConsoleKey.W , ConsoleKey.S, ConsoleKey.Enter });
            GameObject button = new GameObject("Button");
            GameObject indicator = new GameObject("Indicator");
            Position buttonPos = new Position(73f, 23f, 1f);
            Position indicatorPos = new Position(72f, 23f, 0f);
            button.AddComponent(buttonKeyListener);
            button.AddComponent(buttonPos);
            button.AddComponent(new Button());
            button.AddComponent(new ConsoleSprite(
                buttonSprite, ConsoleColor.Red, ConsoleColor.Blue));
            indicator.AddComponent(new ConsoleSprite(
                indicatorSprite, ConsoleColor.Red, ConsoleColor.DarkBlue));
            indicator.AddComponent(indicatorPos);
            gameScene.AddGameObject(button);
            gameScene.AddGameObject(indicator);

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