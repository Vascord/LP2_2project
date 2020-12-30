using System;
using CoreGameEngine;

namespace SuperMario
{
    public class Coin : Component
    {
        private Score actualScore;
        public Coin(Score score)
        {
            actualScore = score;
        }

        public override void Update()
        {
            
        }
    }
}