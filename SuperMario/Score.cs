using CoreGameEngine;

namespace SuperMario
{
    /// <summary>
    /// Public class that provides the score of the player at each level.
    /// </summary>
    public class Score : Component
    {
        /// <summary>
        /// Gets or sets the score during the game.
        /// </summary>
        /// <value>The int score of current level.</value>
        public int Scoring { get; set; }
        private int framesForTime;
        private Player player;

        /// <summary>
        /// Public override method which initiates at the first frame.
        /// </summary>
        public override void Start()
        {
            Scoring = 3000;
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

                // At each 50 frames, the score goes down by 10
                if (framesForTime == 50)
                {
                    Scoring -= 10;

                    framesForTime = 0;

                    /* Actualizes the render of the game object with the 
                    actualized score */
                    ParentGameObject.GetComponent<RenderableStringComponent>()
                    .SwitchString(() => "Score: " + Scoring.ToString());
                }
            }
        }
    }
}