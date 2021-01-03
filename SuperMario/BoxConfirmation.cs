using CoreGameEngine;

namespace SuperMario
{
    /// <summary>
    /// Public class used to see if a box has been used or not.
    /// </summary>
    public class BoxConfirmation : Component
    {
        /// <summary>
        /// Gets or sets the used state of the box.
        /// </summary>
        /// <value>If the box is used (1) or not (0).</value>
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