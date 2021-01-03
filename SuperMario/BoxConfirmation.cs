using System;
using CoreGameEngine;

namespace SuperMario
{
    /// <summary>
    /// This.
    /// </summary>
    public class BoxConfirmation : Component
    {
        public int boxUsed { get; set; }

        /// <summary>
        /// This.
        /// </summary>
        public BoxConfirmation()
        {
            boxUsed = 0;
        }
    }
}