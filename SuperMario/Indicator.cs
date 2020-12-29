using System;
using CoreGameEngine;

namespace SuperMario
{
    public class Indicator : Component
    {
        private KeyObserver keyObserver;
        private Position position;
        private float x, y;
        private int option;

        public override void Start()
        {
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
            position = ParentGameObject.GetComponent<Position>();
            x = position.Pos.X;
            option = 0;
        }

        public override void Update()
        {
            y = position.Pos.Y;

            foreach (ConsoleKey key in keyObserver.GetCurrentKeys())
            {
                if (key == ConsoleKey.UpArrow && option != 0)
                {
                    y -= 3;
                    option--;
                }
                else if (key == ConsoleKey.DownArrow && option != 2)
                {
                    y += 3;
                    option++;
                }
                else if (key == ConsoleKey.Enter)
                {
                    if(option == 0)
                    {
                        ParentScene.Terminate();
                        Level1 level1 = new Level1();
                        level1.Run();
                    }
                    else if(option == 1)
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

            x = Math.Clamp(x, 0, ParentScene.xdim - 3);
            y = Math.Clamp(y, 0, ParentScene.ydim - 3);

            position.Pos = new Vector3(x, y, position.Pos.Z);
        }
    }
}