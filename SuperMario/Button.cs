using System;
using CoreGameEngine;

namespace SuperMario
{
    public class Button : Component
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
                if (key == ConsoleKey.W && option == 1)
                {
                    y += 3;
                    option = 0;
                }
                else if (key == ConsoleKey.S && option == 0)
                {
                    y -= 3;
                    option = 1;
                }
                else if (key == ConsoleKey.Enter)
                {
                    if(option == 0)
                    {
                        Level1 level1 = new Level1();
                        level1.Run();
                        ParentScene.Terminate();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }

            x = Math.Clamp(x, 0, ParentScene.xdim - 3);
            y = Math.Clamp(y, 0, ParentScene.ydim - 3);

            position.Pos = new Vector3(x, y, position.Pos.Z);
        }
    }
}