using CoreGameEngine;
namespace SuperMario
{
    public class CoinConfirmation : Component
    {
        public int coinUsed {get; set;}

        public CoinConfirmation()
        {
            coinUsed = 0;
        }
    }
}