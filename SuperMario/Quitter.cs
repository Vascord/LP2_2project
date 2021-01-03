using System;
using CoreGameEngine;

namespace SuperMario
{
    /// <summary>
    /// This.
    /// </summary>
    public class Quitter : Component
    {
        private KeyObserver keyObserver;

        /// <summary>
        /// This.
        /// </summary>
        public override void Start()
        {
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
        }

        /// <summary>
        /// This.
        /// </summary>
        public override void Update()
        {
            foreach (ConsoleKey key in keyObserver.GetCurrentKeys())
            {
                // if (key == ConsoleKey.Escape)
                // {
                //     Console.WriteLine("Bye :(");
                //     ParentScene.Terminate();
                // }
            }
        }
    }
}