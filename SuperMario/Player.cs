using System;
using System.Threading;
using System.Collections.Generic;
using CoreGameEngine;

namespace SuperMario
{
    public class Player : Component
    {
       private KeyObserver keyObserver;
       private Position position;
       private List<Vector2> Occupied;

       private bool inAir = false;
       private bool ground = true;
       private int jumpFrames = 0;
       private float x, y;
       private ConsoleKey Lastkey = ConsoleKey.LeftArrow;

        public override void Start()
        {
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
            position = ParentGameObject.GetComponent<Position>();

        }

        public Player (List<Vector2> Occupied)
        {
            this.Occupied = Occupied; 
        }

        public override void Update()
        {
            x = position.Pos.X;
            y = position.Pos.Y;
            bool colide = false;

            ground = checkGround();
            
            if(!inAir && !ground)
            {
                while(!ground)
                {
                    falling();
                    ground = true;
                }
            }

            else if(!inAir)
            {
                foreach(ConsoleKey key in keyObserver.GetCurrentKeys())
                {
                    switch (key)
                    {
                        case ConsoleKey.RightArrow:
                            Lastkey = ConsoleKey.RightArrow;
                            foreach (Vector2 v in Occupied)
                            {
                                if (position.Pos.X + 3 == v.X && position.Pos.Y == v.Y)
                                    colide = true;
                            }
                            if (!colide)
                                x += 1;
                            position.Pos = new Vector3(x, y, position.Pos.Z);
                            
                            
                            //colide = false;
                            break;
                        case ConsoleKey.UpArrow:
                            Lastkey = ConsoleKey.UpArrow;
                            position.Pos = new Vector3(x, y, position.Pos.Z);
                            break;
                        case ConsoleKey.LeftArrow:
                            Lastkey = ConsoleKey.LeftArrow;
                            foreach (Vector2 v in Occupied)
                            {
                                if (position.Pos.X - 1 == v.X && position.Pos.Y == v.Y)
                                    colide = true;
                            }
                            if (!colide)
                                x -= 1;
                            position.Pos = new Vector3(x, y, position.Pos.Z);
                            break;
                        case ConsoleKey.Spacebar:
                            inAir = true;
                            position.Pos = new Vector3(x, y, position.Pos.Z);
                            break;
                    }
                }

                x = Math.Clamp(x, 0, ParentScene.xdim - 3);
                y = Math.Clamp(y, 0, ParentScene.ydim - 3);

                //position.Pos = new Vector3(x, y, position.Pos.Z);
            }

            else if(inAir)
            {
                if(jumpFrames == 0)
                {
                    y -= 4;
                    if(Lastkey == ConsoleKey.RightArrow)
                        x += 5;
                    else if (Lastkey == ConsoleKey.LeftArrow)
                        x -= 5;
                    jumpFrames++;
                }
                else if(jumpFrames == 1)
                {
                    y -= 3;
                    if(Lastkey == ConsoleKey.RightArrow)
                        x += 5;
                    else if (Lastkey == ConsoleKey.LeftArrow)
                        x -= 5;
                    jumpFrames = 0;
                    inAir = false;
                }
                // else if (jumpFrames == 2)
                // {
                //     y += 3;
                //     if(Lastkey == ConsoleKey.RightArrow)
                //         x += 1;
                //     else if (Lastkey == ConsoleKey.LeftArrow)
                //         x -= 1;
                //     jumpFrames++;
                // }
                // else if(jumpFrames == 3)
                // {
                //     y += 4;
                //     if(Lastkey == ConsoleKey.RightArrow)
                //         x += 1;
                //     else if (Lastkey == ConsoleKey.LeftArrow)
                //         x -= 1;
                //     jumpFrames = 0;
                //     inAir = false;
                //}
                x = Math.Clamp(x, 0, ParentScene.xdim - 3);
                y = Math.Clamp(y, 0, ParentScene.ydim - 3);
                position.Pos = new Vector3(x, y, position.Pos.Z);
                Thread.Sleep(100);
            }
            
        }

        private bool checkGround()
        {
            bool ground = false;
            // check if there is ground beneth the player 
            foreach (Vector2 v in Occupied)
            {
                if (position.Pos.X + 1 == v.X && position.Pos.Y + 3 == v.Y)
                {
                    ground = true;
                } 
            }
            if(!ground)
                return false;
            return true;
        }

        private void falling()
        {
            x = position.Pos.X;
            y = position.Pos.Y;
            y++;
            x = Math.Clamp(x, 0, ParentScene.xdim - 3);
            y = Math.Clamp(y, 0, ParentScene.ydim - 3);
            
            position.Pos = new Vector3(x, y, position.Pos.Z);
            if (ParentScene.ydim - 3 == position.Pos.Y)
            {
                // Not correct
                position.Pos = new Vector3(1f, 20f, position.Pos.Z);
            }
        }
    }
}