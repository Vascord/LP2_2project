using System;
using CoreGameEngine;

namespace SuperMario
{
    public class Score : Component
    {
        public int score {get; set;}
        private int framesForTime;
        private Player player;

        public override void Start()
        {
            score = 3000;
            framesForTime = 0;
            player = ParentScene.FindGameObjectByName("Player").GetComponent<Player>();
        }

        public override void Update()
        {
            if(player.gameover == true){}
            else
            {
                framesForTime++;

                if(framesForTime == 20)
                {
                    score -= 10;

                    framesForTime = 0;
                }

                ParentGameObject.GetComponent<RenderableStringComponent>().
                        SwitchString(() => "Score: " + score.ToString());
            }
        }
    }
}