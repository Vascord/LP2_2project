using System.Collections.Generic;

namespace CoreGameEngine
{
    public abstract class AbstractCollider : Component
    {
        public abstract IEnumerable<Vector2> Occupied { get; }

    }
}
