using System;
using CoreGameEngine;

namespace SuperMario
{
    public class BoxConfirmation : Component
    {
        public int boxUsed {get; set;}

        public BoxConfirmation()
        {
            boxUsed = 0;
        }
    }
}