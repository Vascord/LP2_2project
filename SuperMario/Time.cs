using System;
using CoreGameEngine;

namespace SuperMario
{
    /// <summary>
    /// This.
    /// </summary>
    public class Time : Component
    {
        /// <summary>
        /// Gets.
        /// </summary>
        /// <value>Name of the file.</value>
        public int Timing { get; private set; }
        private int framesForTime;
        private Player player;

        /// <summary>
        /// This.
        /// </summary>
        public override void Start()
        {
            Timing = 200;
            framesForTime = 0;
            player = ParentScene.FindGameObjectByName("Player").GetComponent<Player>();
        }

        /// <summary>
        /// This.
        /// </summary>
        public override void Update()
        {
            if (!player.Gameover)
            {
                framesForTime++;

                if (framesForTime == 100)
                {
                    Timing--;

                    framesForTime = 0;

                    ParentGameObject.GetComponent<RenderableStringComponent>().
                        SwitchString(() => "Time: " + Timing.ToString());   
                }

                if (Timing == 0)
                {
                    ParentScene.Terminate();
                    Menu menu = new Menu();
                    menu.Run();
                }
            }
        }
    }
}