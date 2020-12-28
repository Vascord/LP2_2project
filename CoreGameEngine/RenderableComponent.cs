/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */

using System.Collections.Generic;

namespace CoreGameEngine
{
    // Renderable components must extend this class
    public abstract class RenderableComponent : Component
    {
        public abstract
        IEnumerable<KeyValuePair<Vector2, ConsolePixel>> Pixels { get; }
    }
}