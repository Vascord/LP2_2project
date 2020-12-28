/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */

using System;

namespace CoreGameEngine
{
    // Represents a console pixel with shape (char), foreground and background
    // colors
    public struct ConsolePixel
    {
        public readonly char shape;
        public readonly ConsoleColor foregroundColor;
        public readonly ConsoleColor backgroundColor;

        // Is this pixel renderable?
        public bool IsRenderable
        {
            get
            {
                // The pixel is renderable if any of its fields is not the
                // default to the specific type
                return !shape.Equals(default(char))
                    && !foregroundColor.Equals(default(ConsoleColor))
                    && !backgroundColor.Equals(default(ConsoleColor));
            }
        }

        // Below there are several constructors for building a console pixel

        public ConsolePixel(char shape,
            ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            this.shape = shape;
            this.foregroundColor = foregroundColor;
            this.backgroundColor = backgroundColor;
        }

        public ConsolePixel(char shape, ConsoleColor foregroundColor)
        {
            this.shape = shape;
            this.foregroundColor = foregroundColor;
            backgroundColor = Console.BackgroundColor;
        }

        public ConsolePixel(char shape)
        {
            this.shape = shape;
            foregroundColor = Console.ForegroundColor;
            backgroundColor = Console.BackgroundColor;
        }

    }

}
