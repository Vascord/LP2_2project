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
            ConsoleKey[] quitKeys = new ConsoleKey[] { ConsoleKey.Escape,
                ConsoleKey.Enter };
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
                {'█','█','█',' ','█',' ','█','█','█','█','█'},
                {'█',' ','█',' ','█',' ',' ','█',' ',' ',' '},
                {'█',' ','█','█','█',' ','█','█','█','█','█'},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {'█','█','█','█','█',' ','█','█','█','█','█'},
                {' ',' ',' ',' ','█',' ','█',' ','█',' ',' '},
                {'█','█','█','█','█',' ','█','█','█','█','█'},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {'█','█','█','█','█',' ','█','█','█','█','█'},
                {'█',' ','█',' ',' ',' ','█',' ','█','█',' '},
                {'█','█','█',' ',' ',' ','█','█','█',' ','█'},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {'█','█','█','█','█',' ','█',' ',' ',' ','█'},
                {'█',' ','█',' ','█',' ','█','█','█','█','█'},
                {'█',' ','█',' ','█',' ','█',' ',' ',' ','█'},
                {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {'█','█','█','█','█',' ','█','█','█','█','█'},
                {'█',' ','█','█',' ',' ','█',' ',' ',' ','█'},
                {'█','█','█',' ','█',' ','█','█','█','█','█'}
            };
            GameObject title = new GameObject("Title");
            Position titlePos = new Position(65f, 3f, 0f);
            title.AddComponent(titlePos);
            title.AddComponent(new Title());
            title.AddComponent(new ConsoleSprite(
                titleSprite, ConsoleColor.Red, ConsoleColor.Gray));
            gameScene.AddGameObject(title);

            // Creates button and indicator
            char[,] buttonSprite1 = 
            {
                {'P'},
                {'l'},
                {'a'},
                {'y'}
            };
            char[,] buttonSprite2 = 
            {
                {'H'},
                {'e'},
                {'l'},
                {'p'}
            };
            char[,] buttonSprite3 = 
            {
                {'Q'},
                {'u'},
                {'i'},
                {'t'}
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
            KeyObserver indicatorKeyListener = new KeyObserver(new ConsoleKey[]
                { ConsoleKey.UpArrow , ConsoleKey.DownArrow,ConsoleKey.Enter });
            GameObject button1 = new GameObject("Button1");
            GameObject button2 = new GameObject("Button2");
            GameObject button3 = new GameObject("Button3");
            GameObject indicator = new GameObject("Indicator");
            Position buttonPos1 = new Position(73f, 20f, 1f);
            Position buttonPos2 = new Position(73f, 23f, 1f);
            Position buttonPos3 = new Position(73f, 26f, 1f);
            Position indicatorPos = new Position(72f, 20f, 0f);
            indicator.AddComponent(indicatorKeyListener);
            indicator.AddComponent(new Indicator());
            indicator.AddComponent(indicatorPos);
            button1.AddComponent(buttonPos1);
            button2.AddComponent(buttonPos2);
            button3.AddComponent(buttonPos3);
            button1.AddComponent(new ConsoleSprite(
                buttonSprite1, ConsoleColor.Red, ConsoleColor.Blue));
            button2.AddComponent(new ConsoleSprite(
                buttonSprite2, ConsoleColor.Red, ConsoleColor.Blue));
            button3.AddComponent(new ConsoleSprite(
                buttonSprite3, ConsoleColor.Red, ConsoleColor.Blue));
            indicator.AddComponent(new ConsoleSprite(
                indicatorSprite, ConsoleColor.Red, ConsoleColor.DarkBlue));
            gameScene.AddGameObject(button1);
            gameScene.AddGameObject(button2);
            gameScene.AddGameObject(button3);
            gameScene.AddGameObject(indicator);
        }

        public void Run()
        {
            gameScene.GameLoop(frameLenght);
        }
    }
}