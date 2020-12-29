using System;
using CoreGameEngine;

namespace SuperMario
{
    public class Time : Component
    {
        public int time {get; private set;}
        public int score {get; private set;}
        private int framesForTime;

        public override void Start()
        {
            time = 200;
            score = 3000;
            framesForTime = 0;
        }

        public override void Update()
        {
            framesForTime++;

            if(framesForTime == 100)
            {
                time--;

                score -= 10;

                framesForTime = 0;

                ParentGameObject.GetComponent<RenderableStringComponent>().
                    SwitchString(() => "Time: " + time.ToString());
            }
            if(time == 0)
            {
                ParentScene.Terminate();
                Menu menu = new Menu();
                menu.Run();
            }
        }
    }
}