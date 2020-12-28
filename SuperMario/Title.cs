using System;
using CoreGameEngine;

namespace SuperMario
{
    public class Title : Component
    {
        private Position position;
        private int animation = 0;
        private float x, y;

        public override void Start()
        {
            position = ParentGameObject.GetComponent<Position>();
            x = position.Pos.X;
        }

        public override void Update()
        {
            y = position.Pos.Y;

            if(animation % 50 == 0 && animation <= 150)
            {
                y++;
                animation++;
            }
            else if(animation % 50 == 0 && animation <= 300)
            {
                y--;
                animation++;
            }
            else if(animation == 301)
            {
                animation = 1;
            }
            else
            {
                animation++;
            }

            x = Math.Clamp(x, 0, ParentScene.xdim - 3);
            y = Math.Clamp(y, 0, ParentScene.ydim - 3);

            position.Pos = new Vector3(x, y, position.Pos.Z);
        }
    }
}