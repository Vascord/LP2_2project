using System;
using CoreGameEngine;

namespace SuperMario
{
    /// <summary>
    /// Class which generates the scene help with the inputs and game objects 
    /// of the help menu.
    /// </summary>
    public class Help
    {
        private readonly int xdim = 150;
        private readonly int ydim = 30;
        private readonly int frameLength = 10;
        private Scene gameScene;

        /// <summary>
        /// Public constructor of the help menu.
        /// </summary>
        public Help()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            CreateHelp();
        }

        /// <summary>
        /// Private method which makes the scene and put the following
        /// game objects on it for the help menu.
        /// </summary>
        private void CreateHelp()
        {
            // Create scene
            ConsoleKey[] quitKeys = new ConsoleKey[] { ConsoleKey.Enter };
            gameScene = new Scene(
                xdim,
                ydim,
                new InputHandler(quitKeys),
                new ConsoleRenderer(xdim, ydim, new ConsolePixel(' ')),
                new CollisionHandler(xdim, ydim));

            // Creates help instruction
            char[,] instructionsSprite =
            {
                { 'M', ' ', 'J', ' ', 'S', ' ', 'E' },
                { 'o', ' ', 'u', ' ', 't', ' ', 'x' },
                { 'v', ' ', 'm', ' ', 'r', ' ', 'i' },
                { 'e', ' ', 'p', ' ', 'a', ' ', 't' },
                { 'm', ' ', ':', ' ', 'i', ' ', ' ' },
                { 'e', ' ', ' ', ' ', 'g', ' ', 'T' },
                { 'n', ' ', 'S', ' ', 't', ' ', 'o' },
                { 't', ' ', 'p', ' ', ' ', ' ', ' ' },
                { ':', ' ', 'a', ' ', 'J', ' ', 'M' },
                { ' ', ' ', 'c', ' ', 'u', ' ', 'a' },
                { 'A', ' ', 'e', ' ', 'm', ' ', 'i' },
                { 'r', ' ', ' ', ' ', 'p', ' ', 'n' },
                { 'r', ' ', '+', ' ', ':', ' ', ' ' },
                { 'o', ' ', ' ', ' ', ' ', ' ', 'M' },
                { 'w', ' ', 'L', ' ', 'A', ' ', 'e' },
                { 's', ' ', 'a', ' ', 'r', ' ', 'n' },
                { ' ', ' ', 's', ' ', 'r', ' ', 'u' },
                { 'L', ' ', 't', ' ', 'o', ' ', ':' },
                { 'e', ' ', ' ', ' ', 'w', ' ', ' ' },
                { 'f', ' ', 'p', ' ', ' ', ' ', 'E' },
                { 't', ' ', 'r', ' ', 'U', ' ', 's' },
                { ' ', ' ', 'e', ' ', 'p', ' ', 'c' },
                { 'a', ' ', 's', ' ', ' ', ' ', 'a' },
                { 'n', ' ', 's', ' ', 't', ' ', 'p' },
                { 'd', ' ', 'e', ' ', 'h', ' ', 'e' },
                { ' ', ' ', 'd', ' ', 'e', ' ', ' ' },
                { 'R', ' ', ' ', ' ', 'n', ' ', ' ' },
                { 'i', ' ', 'A', ' ', ' ', ' ', ' ' },
                { 'g', ' ', 'r', ' ', 'S', ' ', ' ' },
                { 'h', ' ', 'r', ' ', 'p', ' ', ' ' },
                { 't', ' ', 'o', ' ', 'a', ' ', ' ' },
                { ' ', ' ', 'w', ' ', 'c', ' ', ' ' },
                { ' ', ' ', ' ', ' ', 'e', ' ', ' ' },
            };
            GameObject instructions = new GameObject("Instructions");
            Position instructionsPos = new Position(60f, 10f, 0f);
            instructions.AddComponent(instructionsPos);
            instructions.AddComponent(new ConsoleSprite(
                instructionsSprite, ConsoleColor.Red, ConsoleColor.Gray));
            gameScene.AddGameObject(instructions);

            // Creates the button to return to the menu
            char[,] buttonSprite =
            {
                { 'B' },
                { 'a' },
                { 'c' },
                { 'k' },
            };
            GameObject button = new GameObject("Button");
            Position buttonPos = new Position(73f, 23f, 1f);
            button.AddComponent(buttonPos);
            button.AddComponent(new ConsoleSprite(
                buttonSprite, ConsoleColor.Red, ConsoleColor.Blue));
            gameScene.AddGameObject(button);

            // Creates the indicator to press the buttons
            char[,] indicatorSprite =
            {
                { '>' },
                { ' ' },
                { ' ' },
                { ' ' },
                { ' ' },
                { '<' },
            };
            KeyObserver indicatorKeyListener = new KeyObserver(new ConsoleKey[]
                { ConsoleKey.W, ConsoleKey.S, ConsoleKey.Enter });
            GameObject indicator = new GameObject("Indicator");
            Position indicatorPos = new Position(72f, 23f, 0f);
            indicator.AddComponent(indicatorKeyListener);
            indicator.AddComponent(new ReturnMenu());
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