using System;
using CoreGameEngine;

namespace SuperMario
{
    /// <summary>
    /// This.
    /// </summary>
    public class BoxConfirmation : Component
    {
        /// <summary>
        /// Gets or sets.
        /// </summary>
        /// <value>Name of the file.</value>
        public int BoxUsed { get; set; }

        /// <summary>
        /// This.
        /// </summary>
        public BoxConfirmation()
        {
            BoxUsed = 0;
        }
    }
}