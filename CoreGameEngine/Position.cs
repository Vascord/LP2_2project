/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */

namespace CoreGameEngine
{
    // This component defines the position of a game object
    public class Position : Component
    {
        public Vector3 Pos { get; set; }

        public Position()
        {
            Pos = new Vector3(0f, 0f, 0f);
        }

        public Position(float x, float y, float z)
        {
            Pos = new Vector3(x, y, z);
        }
    }
}
