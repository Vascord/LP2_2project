using System;
using CoreGameEngine;

namespace SuperMario
{
    /// <summary>
    /// Public class to do the title animation.
    /// </summary>
    public class Title : Component
    {
        private Position position;
        private int animation = 0;
        private float x;
        private float y;

        /// <summary>
        /// Public override method which initiates at the first frame.
        /// </summary>
        public override void Start()
        {
            position = ParentGameObject.GetComponent<Position>();
            x = position.Pos.X;
        }

        /// <summary>
        /// Public override method which is launched at each frame.
        /// </summary>
        public override void Update()
        {
            // Gets the position in Y of the title
            y = position.Pos.Y;

            /* The title goes down if the animation is at frame is at 
            50, 100 or 150 */
            if (animation % 50 == 0 && animation <= 150)
            {
                y++;
                animation++;
            }

            /* The title goes up if the animation is at frame is at 
            200, 250 or 300 */
            else if (animation % 50 == 0 && animation > 150)
            {
                y--;
                animation++;
            }

            // The animation frame resets to 1
            else if (animation == 301)
            {
                animation = 1;
            }

            // If none of that happens, the animation frame goes up by one
            else
            {
                animation++;
            }

            // The position of the gameobject actualizes with the new values
            position.Pos = new Vector3(x, y, position.Pos.Z);
        }
    }
}