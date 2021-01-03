using System;
using CoreGameEngine;

namespace SuperMario
{
    /// <summary>
    /// This.
    /// </summary>
    public class Score : Component
    {
        /// <summary>
        /// Gets or sets.
        /// </summary>
        /// <value>Name of the file.</value>
        public int Scoring { get; set; }
        private int framesForTime;
        private Player player;

        /// <summary>
        /// This.
        /// </summary>
        public override void Start()
        {
            Scoring = 3000;
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

                if (framesForTime == 20)
                {
                    Scoring -= 10;

                    framesForTime = 0;
                }

                ParentGameObject.GetComponent<RenderableStringComponent>().
                        SwitchString(() => "Score: " + Scoring.ToString());
            }
        }
    }
}