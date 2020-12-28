/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */

using System.Collections.Generic;
namespace CoreGameEngine
{
    // Interface to be implemented by observable subjects
    public interface IObservable<T>
    {
        void RegisterObserver(
            IEnumerable<T> whatToObserve, IObserver<T> observer);
        void RemoveObserver(T whatToObserve, IObserver<T> observer);
        void RemoveObserver(IObserver<T> observer);
    }
}
