using CoreGameEngine;
namespace SuperMario
{
    /// <summary>
    /// This.
    /// </summary>
    public class CoinConfirmation : Component
    {
        /// <summary>
        /// Gets or sets.
        /// </summary>
        /// <value>Name of the file.</value>
        public int CoinUsed { get; set; }

        /// <summary>
        /// This.
        /// </summary>
        public CoinConfirmation()
        {
            CoinUsed = 0;
        }
    }
}