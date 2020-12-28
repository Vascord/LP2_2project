/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */
namespace CoreGameEngine
{
    // All game object components must implement this interface
    public abstract class Component : BaseGameObject
    {
        // Reference to the parent game object
        public GameObject ParentGameObject { get; internal set; }
        // Reference to the parent scene
        public Scene ParentScene => ParentGameObject.ParentScene;

    }
}
