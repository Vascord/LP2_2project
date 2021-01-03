using System;
using CoreGameEngine;

namespace SuperMario
{
    /// <summary>
    /// This public class is used to see if a box has been used or not.
    /// </summary>
    public class BoxConfirmation : Component
    {
        /// <summary>
        /// Gets or sets the used state of the box.
        /// </summary>
        /// <value>Name of the file.</value>
        public int BoxUsed { get; set; }

        /// <summary>
        /// Public constructor that as the default box as non-used.
        /// </summary>
        public BoxConfirmation()
        {
            BoxUsed = 0;
        }
    }
}