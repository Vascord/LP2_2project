using CoreGameEngine;

namespace SuperMario
{
    /// <summary>
    /// Public class with the remaining time for the player to finish the level.
    /// </summary>
    public class Time : Component
    {
        /// <summary>
        /// Gets the actual time of the level.
        /// </summary>
        /// <value>The int time of the current level.</value>
        public int Timing { get; private set; }
        private int framesForTime;
        private Player player;

        /// <summary>
        /// Public override method which initiates at the first frame.
        /// </summary>
        public override void Start()
        {
            Timing = 200;
            framesForTime = 0;
            player = ParentScene
                .FindGameObjectByName("Player")
                .GetComponent<Player>();
        }

        /// <summary>
        /// Public override method which is launched at each frame.
        /// </summary>
        public override void Update()
        {
            // Sees if the player as not died or finish the level
            if (!player.Gameover)
            {
                framesForTime++;

                // At each 50 frames, the time goes down by 1
                if (framesForTime == 50)
                {
                    Timing--;

                    framesForTime = 0;

                    /* Actualizes the render of the game object with the 
                    actualized score */
                    ParentGameObject.GetComponent<RenderableStringComponent>().
                        SwitchString(() => "Time: " + Timing.ToString());
                }

                // Returns to the menu if the time's up.
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