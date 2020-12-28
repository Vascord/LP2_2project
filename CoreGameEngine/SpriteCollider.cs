using System;
using System.Collections.Generic;

namespace CoreGameEngine
{
    public class SpriteCollider : AbstractCollider
    {
        public override IEnumerable<Vector2> Occupied
        {
            get
            {
                foreach(KeyValuePair<Vector2, ConsolePixel> V in sprite.Pixels)
                {
                    Vector2 v = V.Key;
                    yield return new Vector2();
                }
            }
        } // TODO


        private ConsoleSprite sprite;

        public override void Start()
        {
            sprite = ParentGameObject.GetComponent<ConsoleSprite>();
            if (sprite == null)
            {
                throw new InvalidOperationException(
                    $"The {nameof(SpriteCollider)} component " +
                    $"requires a {nameof(ConsoleSprite)} component");
            }
        }

    }
}
