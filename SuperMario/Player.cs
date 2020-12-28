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
       private int jumpFrames = 0;
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
            float x = position.Pos.X;
            float y = position.Pos.Y;
            bool colide = false;
            if(!inAir)
            {
                foreach(ConsoleKey key in keyObserver.GetCurrentKeys())
                {
                    switch (key)
                    {
                        case ConsoleKey.RightArrow:
                            Lastkey = ConsoleKey.RightArrow;
                            foreach (Vector2 v in Occupied)
                            {
                                if (position.Pos.X + 3 == v.X)
                                    colide = true;
                            }
                            if (!colide)
                                x += 1;
                            //colide = false;
                            break;
                        case ConsoleKey.UpArrow:
                            Lastkey = ConsoleKey.UpArrow;
                            break;
                        case ConsoleKey.LeftArrow:
                            Lastkey = ConsoleKey.LeftArrow;
                            foreach (Vector2 v in Occupied)
                            {
                                if (position.Pos.X - 1 == v.X)
                                    colide = true;
                            }
                            if (!colide)
                                x -= 1;
                            break;
                        case ConsoleKey.Spacebar:
                            inAir = true;
                            break;
                    }
                }

                x = Math.Clamp(x, 0, ParentScene.xdim - 3);
                y = Math.Clamp(y, 0, ParentScene.ydim - 3);

                position.Pos = new Vector3(x, y, position.Pos.Z);
            }

            if(inAir)
            {
                
                if(jumpFrames == 0)
                {
                    y -= 4;
                    if(Lastkey == ConsoleKey.RightArrow)
                        x += 2;
                    else if (Lastkey == ConsoleKey.LeftArrow)
                        x -= 2;
                    jumpFrames++;
                }
                else if(jumpFrames == 1)
                {
                    y -= 3;
                    if(Lastkey == ConsoleKey.RightArrow)
                        x += 2;
                    else if (Lastkey == ConsoleKey.LeftArrow)
                        x -= 2;
                    jumpFrames++;
                }
                else if (jumpFrames == 2)
                {
                    y += 3;
                    if(Lastkey == ConsoleKey.RightArrow)
                        x += 1;
                    else if (Lastkey == ConsoleKey.LeftArrow)
                        x -= 1;
                    jumpFrames++;
                }
                else if(jumpFrames == 3)
                {
                    y += 4;
                    if(Lastkey == ConsoleKey.RightArrow)
                        x += 1;
                    else if (Lastkey == ConsoleKey.LeftArrow)
                        x -= 1;
                    jumpFrames = 0;
                    inAir = false;
                }
                x = Math.Clamp(x, 0, ParentScene.xdim - 3);
                y = Math.Clamp(y, 0, ParentScene.ydim - 3);
                position.Pos = new Vector3(x, y, position.Pos.Z);
                Thread.Sleep(100);
            }
            
        }
    }
}