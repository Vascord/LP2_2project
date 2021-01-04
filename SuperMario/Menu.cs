using System;
using CoreGameEngine;

namespace SuperMario
{
    /// <summary>
    /// Class which generates the scene menu with the inputs and game objects
    /// of the menu.
    /// </summary>
    public class Menu
    {
        private readonly int xdim = 150;
        private readonly int ydim = 30;
        private readonly int frameLength = 10;
        private Scene gameScene;

        /// <summary>
        /// Public constructor of the menu.
        /// </summary>
        public Menu()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            CreateMenu();
        }

        /// <summary>
        /// Private method which makes the scene and put the following
        /// game objects on it for the menu.
        /// </summary>
        private void CreateMenu()
        {
            // Create scene
            ConsoleKey[] quitKeys = new ConsoleKey[] { ConsoleKey.Enter };
            gameScene = new Scene(
                xdim,
                ydim,
                new InputHandler(quitKeys),
                new ConsoleRenderer(xdim, ydim, new ConsolePixel(' ')),
                new CollisionHandler(xdim, ydim));

            // Creates title
            char[,] titleSprite =
            {
                { '█', '█', '█', ' ', '█', ' ', '█', '█', '█', '█', '█' },
                { '█', ' ', '█', ' ', '█', ' ', ' ', '█', ' ', ' ', ' ' },
                { '█', ' ', '█', '█', '█', ' ', '█', '█', '█', '█', '█' },
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                { '█', '█', '█', '█', '█', ' ', '█', '█', '█', '█', '█' },
                { ' ', ' ', ' ', ' ', '█', ' ', '█', ' ', '█', ' ', ' ' },
                { '█', '█', '█', '█', '█', ' ', '█', '█', '█', '█', '█' },
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                { '█', '█', '█', '█', '█', ' ', '█', '█', '█', '█', '█' },
                { '█', ' ', '█', ' ', ' ', ' ', '█', ' ', '█', '█', ' ' },
                { '█', '█', '█', ' ', ' ', ' ', '█', '█', '█', ' ', '█' },
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                { '█', '█', '█', '█', '█', ' ', '█', ' ', ' ', ' ', '█' },
                { '█', ' ', '█', ' ', '█', ' ', '█', '█', '█', '█', '█' },
                { '█', ' ', '█', ' ', '█', ' ', '█', ' ', ' ', ' ', '█' },
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                { '█', '█', '█', '█', '█', ' ', '█', '█', '█', '█', '█' },
                { '█', ' ', '█', '█', ' ', ' ', '█', ' ', ' ', ' ', '█' },
                { '█', '█', '█', ' ', '█', ' ', '█', '█', '█', '█', '█' },
            };
            GameObject title = new GameObject("Title");
            Position titlePos = new Position(65f, 3f, 0f);
            title.AddComponent(titlePos);
            title.AddComponent(new Title());
            title.AddComponent(new ConsoleSprite(
                titleSprite, ConsoleColor.Red, ConsoleColor.Gray));
            gameScene.AddGameObject(title);

            // Creates buttons
            char[,] buttonSprite1 = 
            {
                { 'L' },
                { 'e' },
                { 'v' },
                { 'e' },
                { 'l' },
                { '1' },
            };
            char[,] buttonSprite2 = 
            {
                { 'L' },
                { 'e' },
                { 'v' },
                { 'e' },
                { 'l' },
                { '2' },
            };
            char[,] buttonSprite3 = 
            {
                { 'H' },
                { 'e' },
                { 'l' },
                { 'p' },
            };
            char[,] buttonSprite4 = 
            {
                { 'Q' },
                { 'u' },
                { 'i' },
                { 't' },
            };
            GameObject button1 = new GameObject("Button1");
            GameObject button2 = new GameObject("Button2");
            GameObject button3 = new GameObject("Button3");
            GameObject button4 = new GameObject("Button4");
            Position buttonPos1 = new Position(72f, 19f, 1f);
            Position buttonPos2 = new Position(72f, 21f, 1f);
            Position buttonPos3 = new Position(73f, 23f, 1f);
            Position buttonPos4 = new Position(73f, 25f, 1f);
            button1.AddComponent(buttonPos1);
            button2.AddComponent(buttonPos2);
            button3.AddComponent(buttonPos3);
            button4.AddComponent(buttonPos4);
            button1.AddComponent(new ConsoleSprite(
                buttonSprite1, ConsoleColor.Red, ConsoleColor.Blue));
            button2.AddComponent(new ConsoleSprite(
                buttonSprite2, ConsoleColor.Red, ConsoleColor.Blue));
            button3.AddComponent(new ConsoleSprite(
                buttonSprite3, ConsoleColor.Red, ConsoleColor.Blue));
            button4.AddComponent(new ConsoleSprite(
                buttonSprite4, ConsoleColor.Red, ConsoleColor.Blue));
            gameScene.AddGameObject(button1);
            gameScene.AddGameObject(button2);
            gameScene.AddGameObject(button3);
            gameScene.AddGameObject(button4);

            // Creates indicator
            char[,] indicatorSprite =
            {
                { '>' },
                { ' ' },
                { ' ' },
                { ' ' },
                { ' ' },
                { ' ' },
                { ' ' },
                { ' ' },
                { ' ' },
                { '<' },
            };
            KeyObserver indicatorKeyListener = new KeyObserver(new ConsoleKey[]
                { ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.Enter });
            GameObject indicator = new GameObject("Indicator");
            Position indicatorPos = new Position(70f, 19f, 0f);
            indicator.AddComponent(indicatorKeyListener);
            indicator.AddComponent(new Indicator());
            indicator.AddComponent(indicatorPos);
            indicator.AddComponent(new ConsoleSprite(
                indicatorSprite, ConsoleColor.Red, ConsoleColor.DarkBlue));
            gameScene.AddGameObject(indicator);
        }

        /// <summary>
        /// Public method that makes the scene run with the predefined
        /// frame length.
        /// </summary>
        public void Run()
        {
            gameScene.GameLoop(frameLength);
        }
    }
}