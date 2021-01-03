using CoreGameEngine;
namespace SuperMario
{
    /// <summary>
    /// This public class is used to see if a coin has been used or not.
    /// </summary>
    public class CoinConfirmation : Component
    {
        /// <summary>
        /// Gets or sets the used state of the coin.
        /// </summary>
        /// <value>Name of the file.</value>
        public int CoinUsed { get; set; }

        /// <summary>
        /// Public constructor that as the default coin as non-used.
        /// </summary>
        public CoinConfirmation()
        {
            CoinUsed = 0;
        }
    }
}