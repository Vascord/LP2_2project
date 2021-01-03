using System;
using CoreGameEngine;

namespace SuperMario
{
    public class Time : Component
    {
        public int time { get; private set; }
        private int framesForTime;
        private Player player;

        public override void Start()
        {
            time = 200;
            framesForTime = 0;
             player = ParentScene.FindGameObjectByName("Player").GetComponent<Player>();
        }

        public override void Update()
        {
            if (player.gameover == true){  }
            else
            {
                framesForTime++;

                if (framesForTime == 100)
                {
                    time--;

                    framesForTime = 0;

                    ParentGameObject.GetComponent<RenderableStringComponent>().
                        SwitchString(() => "Time: " + time.ToString());   
                }

                if (time == 0)
                {
                    ParentScene.Terminate();
                    Menu menu = new Menu();
                    menu.Run();
                }
            }
        }
    }
}