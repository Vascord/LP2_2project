using CoreGameEngine;
namespace SuperMario
{
    /// <summary>
    /// This.
    /// </summary>
    public class CoinConfirmation : Component
    {
        public int coinUsed { get; set; }

        /// <summary>
        /// This.
        /// </summary>
        public CoinConfirmation()
        {
            coinUsed = 0;
        }
    }
}