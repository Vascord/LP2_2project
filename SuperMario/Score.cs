using System;
using CoreGameEngine;

namespace SuperMario
{
    public class Score : Component
    {
        public int score {get; set;}
        private int framesForTime;

        public override void Start()
        {
            score = 3000;
            framesForTime = 0;
        }

        public override void Update()
        {
            //framesForTime++;

            ParentGameObject.GetComponent<RenderableStringComponent>().
                    SwitchString(() => "Score: " + score.ToString());
            // if(framesForTime == 100)
            // {
            //     score -= 10;

            //     framesForTime = 0;

            //     ParentGameObject.GetComponent<RenderableStringComponent>().
            //         SwitchString(() => "Score: " + score.ToString());
            // }
        }
    }
}