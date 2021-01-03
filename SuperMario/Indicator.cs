using System;
using CoreGameEngine;

namespace SuperMario
{
    /// <summary>
    /// Public class which permites to "press" the button in the menu and
    /// change scene.
    /// </summary>
    public class Indicator : Component
    {
        private KeyObserver keyObserver;
        private Position position;
        private float x;
        private float y;
        private int option;

        /// <summary>
        /// Public override method which initiates at the first frame.
        /// </summary>
        public override void Start()
        {
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
            position = ParentGameObject.GetComponent<Position>();
            x = position.Pos.X;
            option = 0;
        }

        /// <summary>
        /// Public override method which is launched at each frame.
        /// </summary>
        public override void Update()
        {
            // Gets the position in Y of the indicator
            y = position.Pos.Y;

            /* Sees what key is pressed and depending of the keys pressed
            the indicator can go up and down or initiate another scene*/
            foreach (ConsoleKey key in keyObserver.GetCurrentKeys())
            {
                if (key == ConsoleKey.UpArrow && option != 0)
                {
                    y -= 2;
                    option--;
                }
                else if (key == ConsoleKey.DownArrow && option != 3)
                {
                    y += 2;
                    option++;
                }
                else if (key == ConsoleKey.Enter)
                {
                    if (option == 0)
                    {
                        ParentScene.Terminate();
                        Level1 level1 = new Level1();
                        level1.Run();
                    }

                    if (option == 1)
                    {
                        ParentScene.Terminate();
                        Level2 level2 = new Level2();
                        level2.Run();
                    }
                    else if (option == 2)
                    {
                        ParentScene.Terminate();
                        Help helpMenu = new Help();
                        helpMenu.Run();
                    }
                    else
                    {
                        ParentScene.Terminate();
                    }
                }
            }

            // The position of the gameobject actualizes with the new values
            position.Pos = new Vector3(x, y, position.Pos.Z);
        }
    }
}