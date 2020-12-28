/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */

using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreGameEngine
{
    // This component is an key observer
    public class KeyObserver : Component, IObserver<ConsoleKey>
    {

        private IEnumerable<ConsoleKey> keysToObserve;
        private Queue<ConsoleKey> observedKeys;
        private object queueLock;

        public KeyObserver(IEnumerable<ConsoleKey> keysToObserve)
        {
            this.keysToObserve = keysToObserve;
            observedKeys = new Queue<ConsoleKey>();
            queueLock = new object();
        }

        public override void Start()
        {
            ParentScene.inputHandler.RegisterObserver(keysToObserve, this);
        }

        // This method will be called by the subject when an observed key is
        // pressed
        public void Notify(ConsoleKey notification)
        {
            lock (queueLock)
            {
                observedKeys.Enqueue(notification);
            }
        }

        // Return the currently observed keys
        public IEnumerable<ConsoleKey> GetCurrentKeys()
        {
            IEnumerable<ConsoleKey> currentKeys;
            lock (queueLock)
            {
                currentKeys = observedKeys.ToArray();
                observedKeys.Clear();
            }
            return currentKeys;

        }
    }
}
