using System;
using System.Collections.Generic;
using CoreGameEngine;

namespace SuperMario
{
    public class ReturnMenu : Component
    {
        private KeyObserver keyObserver;

        public override void Start()
        {
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
        }

        public override void Update()
        {

            foreach (ConsoleKey key in keyObserver.GetCurrentKeys())
            {
                if (key == ConsoleKey.Enter)
                {
                    ParentScene.Terminate();
                    Menu menu = new Menu();
                    menu.Run();
                }
            }
        }
    }
}