using System;
using System.Collections.Generic;
using CoreGameEngine;

namespace SuperMario
{
    public class Help
    {
        int xdim = 150, ydim = 30;

        int frameLenght = 10;

        private Scene gameScene;

        public Help()
        {
            CreateHelp();
        }

        private void CreateHelp()
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

            // Creates help instruction
            char[,] instructionsSprite = 
            {
                {'M','J','E'},
                {'o','u','x'},
                {'v','m','i'},
                {'e','p','t'},
                {'m',':',' '},
                {'e',' ','G'},
                {'n','S','a'},
                {'t','p','m'},
                {':','a','e'},
                {' ','c',':'},
                {'A','e',' '},
                {'r',' ','E'},
                {'r',' ','s'},
                {'o',' ','c'},
                {'w',' ','a'},
                {'s',' ','p'},
                {' ',' ','e'}
            };
            GameObject instructions = new GameObject("Instructions");
            Position instructionsPos = new Position(66f, 10f, 0f);
            instructions.AddComponent(instructionsPos);
            instructions.AddComponent(new ConsoleSprite(
                instructionsSprite, ConsoleColor.Red, ConsoleColor.Gray));
            gameScene.AddGameObject(instructions);

            // Creates button and indicator
            char[,] buttonSprite =
            {
                {'B'},
                {'a'},
                {'c'},
                {'k'}
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
                { ConsoleKey.W , ConsoleKey.S, ConsoleKey.Enter });
            GameObject button = new GameObject("Button");
            GameObject indicator = new GameObject("Indicator");
            Position buttonPos = new Position(73f, 23f, 1f);
            Position indicatorPos = new Position(72f, 23f, 0f);
            indicator.AddComponent(indicatorKeyListener);
            indicator.AddComponent(new ReturnMenu());
            indicator.AddComponent(indicatorPos);
            button.AddComponent(buttonPos);
            button.AddComponent(new ConsoleSprite(
                buttonSprite, ConsoleColor.Red, ConsoleColor.Blue));
            indicator.AddComponent(new ConsoleSprite(
                indicatorSprite, ConsoleColor.Red, ConsoleColor.DarkBlue));
            gameScene.AddGameObject(button);
            gameScene.AddGameObject(indicator);
        }

        public void Run()
        {
            gameScene.GameLoop(frameLenght);
        }
    }
}