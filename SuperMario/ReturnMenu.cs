using System;
using CoreGameEngine;

namespace SuperMario
{
    /// <summary>
    /// Public class which permites to "press" the button in the help menu and
    /// return the main menu scene.
    /// </summary>
    public class ReturnMenu : Component
    {
        private KeyObserver keyObserver;

        /// <summary>
        /// Public override method which initiates at the first frame.
        /// </summary>
        public override void Start()
        {
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
        }

        /// <summary>
        /// Public override method which is launched at each frame.
        /// </summary>
        public override void Update()
        {
            /* Sees what key is pressed and depending of the keys pressed
            the indicator initiate the menu scene*/
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