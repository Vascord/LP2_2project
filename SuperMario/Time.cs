using System;
using CoreGameEngine;

namespace SuperMario
{
    public class Time : Component
    {
        public int time {get; private set;}
        private int framesForTime;

        public override void Start()
        {
            time = 200;
            framesForTime = 0;
        }

        public override void Update()
        {
            framesForTime++;

            if(framesForTime == 100)
            {
                time--;

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