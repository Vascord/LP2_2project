using System;
using System.Threading;
using System.Collections.Generic;
using CoreGameEngine;

namespace SuperMario
{
    /// <summary>
    /// This.
    /// </summary>
    public class Player : Component
    {
        private readonly List<Vector2> occupied;
        private readonly List<GameObject> coins;
        private readonly List<GameObject> boxes;
        private readonly GameObject dead;
        private readonly Score actualScore;
        private readonly int level;
        private KeyObserver keyObserver;
        private Position position;
        private bool inAir = false;
        private bool coinScore = false;
        private bool boxHit = false;

        /// <summary>
        /// Gets or sets a value indicating whether.
        /// </summary>
        /// <value>Name of the file.</value>
        public bool Gameover { get; set; } = false;
        private bool doesNotHaveKeyObserver = false;
        private int jumpFrames = 0;
        private float x;
        private float y;
        private ConsoleKey lastkey = ConsoleKey.LeftArrow;

        /// <summary>
        /// This.
        /// </summary>
        /// <param name="occupied">A.</param>
        /// <param name="score">E.</param>
        /// <param name="boxes">I.</param>
        /// <param name="coins">O.</param>
        /// <param name="dead">U.</param>
        /// <param name="level">Bababoi.</param>
        public Player (
            List<Vector2> occupied,
            Score score,
            List<GameObject> boxes,
            List<GameObject> coins,
            GameObject dead,
            int level )
        {
            this.occupied = occupied;
            this.coins = coins;
            this.boxes = boxes;
            this.dead = dead;
            this.level = level;
            actualScore = score;
        }

        /// <summary>
        /// This.
        /// </summary>
        public override void Start()
        {
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
            position = ParentGameObject.GetComponent<Position>();
        }

        /// <summary>
        /// This.
        /// </summary>
        public override void Update()
        {
            bool ground;
            x = position.Pos.X;
            y = position.Pos.Y;
            bool colide = false;

            if (ParentScene.xdim - 10 == position.Pos.X && !Gameover)
            {
                Gameover = true;
            }

            if (Gameover)
            {
                ParentGameObject.GetComponent<KeyObserver>().keysToObserve =
                new ConsoleKey[] { ConsoleKey.Enter };
                ParentScene.inputHandler.quitKeys = new ConsoleKey[] {
                ConsoleKey.Enter,
                ConsoleKey.Escape, };
                ParentScene.inputHandler.RegisterObserver(
                    ParentGameObject
                    .GetComponent<KeyObserver>()
                    .keysToObserve, ParentGameObject
                    .GetComponent<KeyObserver>());

                if (ParentScene.ydim - 4 == position.Pos.Y)
                {
                    dead.GetComponent<RenderableStringComponent>()
                    .SwitchString(() => "Press Enter to restart");
                    foreach (ConsoleKey key in keyObserver.GetCurrentKeys())
                    {
                        if (key == ConsoleKey.Enter)
                        {
                            if (level == 1)
                            {
                                ParentScene.Terminate();
                                Level1 level1 = new Level1();
                                level1.Run();
                                break;
                            }
                            else
                            {
                                ParentScene.Terminate();
                                Level2 level2 = new Level2();
                                level2.Run();
                                break;
                            }
                        }

                        if (key == ConsoleKey.Escape)
                        {
                            ParentScene.Terminate();
                            Menu menu = new Menu();
                            menu.Run();
                            break;
                        }
                    }
                }
                else if (ParentScene.xdim - 10 == position.Pos.X)
                {
                    dead.GetComponent<RenderableStringComponent>()
                    .SwitchString(() => $"Press Enter to go to the next level, your score is : {actualScore.Scoring}");
                    foreach (ConsoleKey key in keyObserver.GetCurrentKeys())
                    {
                        if (key == ConsoleKey.Enter)
                        {
                            if (level == 1)
                            {
                                ParentScene.Terminate();
                                Level2 level2 = new Level2();
                                level2.Run();
                                break;
                            }
                            else
                            {
                                ParentScene.Terminate();
                                Menu menu = new Menu();
                                menu.Run();
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                ground = CheckGround();
                if (!inAir && !ground)
                {
                    while (!ground)
                    {
                        Falling();
                        ParentScene.inputHandler
                            .RemoveObserver(ParentGameObject
                            .GetComponent<KeyObserver>());
                        doesNotHaveKeyObserver = true;
                        ground = true;
                    }
                }
                else if (!inAir)
                {
                    if (doesNotHaveKeyObserver)
                    {
                        ParentScene.inputHandler
                            .AddObserver(ParentGameObject
                            .GetComponent<KeyObserver>());
                        doesNotHaveKeyObserver = false;
                    }

                    foreach (ConsoleKey key in keyObserver.GetCurrentKeys())
                    {
                        switch (key)
                        {
                            case ConsoleKey.RightArrow:
                                lastkey = ConsoleKey.RightArrow;
                                foreach (Vector2 v in occupied)
                                {
                                    if (position.Pos.X + 7 == v.X &&
                                        position.Pos.Y == v.Y)
                                    {
                                        colide = true;
                                    }
                                }

                                if (!colide)
                                    x++;
                                position.Pos = new Vector3(x, y, position.Pos.Z);
                                TurnSprite(true);
                                break;
                            case ConsoleKey.UpArrow:
                                lastkey = ConsoleKey.UpArrow;
                                position.Pos = new Vector3(x, y, position.Pos.Z);
                                break;
                            case ConsoleKey.LeftArrow:
                                lastkey = ConsoleKey.LeftArrow;
                                foreach (Vector2 v in occupied)
                                {
                                    if (position.Pos.X - 1 == v.X && position.Pos.Y == v.Y)
                                        colide = true;
                                }

                                if (!colide)
                                    x -= 1;
                                position.Pos = new Vector3(x, y, position.Pos.Z);
                                TurnSprite(false);
                                break;
                            case ConsoleKey.Spacebar:
                                inAir = true;
                                position.Pos = new Vector3(x, y, position.Pos.Z);
                                break;
                            case ConsoleKey.Escape:
                                ParentScene.Terminate();
                                Menu menu = new Menu();
                                menu.Run();
                                break;
                        }
                    }

                    x = Math.Clamp(x, 0, ParentScene.xdim - 8);
                    y = Math.Clamp(y, 0, ParentScene.ydim - 3);
                }
                else if (inAir)
                {
                    actualScore.Scoring -= 5;
                    ParentScene.inputHandler.RemoveObserver(ParentGameObject.GetComponent<KeyObserver>());
                    if (jumpFrames <= 2)
                    {
                        y -= 2;
                        if (lastkey == ConsoleKey.RightArrow)
                            x += 3;
                        else if (lastkey == ConsoleKey.LeftArrow)
                            x -= 3;
                        jumpFrames++;
                    }
                    else if (jumpFrames == 3)
                    {
                        y -= 2;
                        if (lastkey == ConsoleKey.RightArrow)
                            x += 3;
                        else if (lastkey == ConsoleKey.LeftArrow)
                            x -= 3;
                        jumpFrames = 0;
                        inAir = false;
                    }

                    x = Math.Clamp(x, 0, ParentScene.xdim - 8);
                    y = Math.Clamp(y, 0, ParentScene.ydim - 3);
                    position.Pos = new Vector3(x, y, position.Pos.Z);
                    Thread.Sleep(80);
                }

                if (coins != null)
                    coinScore = CheckCoin();
                if (coinScore)
                {
                    actualScore.Scoring += 1000;
                    coinScore = false;
                }
            }
        }

        private bool CheckBox()
        {
            char[,] emptyBoxSprite =
                {
                    { '█', '█', '█', '█' },
                    { '█', ' ', ' ', '█' },
                    { '█', ' ', ' ', '█' },
                    { '█', ' ', ' ', '█' },
                    { '█', ' ', ' ', '█' },
                    { '█', '█', '█', '█' },
                };
            boxHit = false;
            foreach (GameObject box in boxes)
            {
                if (position.Pos.X  >= box.GetComponent<Position>().Pos.X && position.Pos.X <= box.GetComponent<Position>().Pos.X + 4 &&
                    position.Pos.Y == box.GetComponent<Position>().Pos.Y + 7 && box.GetComponent<BoxConfirmation>().BoxUsed == 0)
                {
                    boxHit = true;
                    box.GetComponent<BoxConfirmation>().BoxUsed = 1;
                    actualScore.Scoring += 1000;
                    box.GetComponent<ConsoleSprite>().SwitchSprite(emptyBoxSprite, ConsoleColor.Yellow, ConsoleColor.DarkGray);
                }
            }

            if (!boxHit)
                return false;
            return true;
        }

        private bool CheckGround()
        {
            bool ground = false;

            // check if there is ground beneth the player 
            foreach (Vector2 v in occupied)
            {
                if ((position.Pos.X + 1 == v.X && position.Pos.Y + 4 == v.Y) || (position.Pos.X + 5 == v.X && position.Pos.Y + 4 == v.Y))
                {
                    ground = true;
                }
            }

            if (ParentScene.ydim - 4 == position.Pos.Y)
            {
                ground = true;
                Gameover = true;
            }

            if (!ground)
            {
                return false;
            }

            return true;
        }

        private bool CheckCoin()
        {
            coinScore = false;
            char[,] noMoreCoinSprite =
            {
                { ' ' },
            };

            // check if there is ground beneth the player
            foreach (GameObject coin in coins)
            {
                if ((position.Pos.X  == coin.GetComponent<Position>().Pos.X && position.Pos.Y == coin.GetComponent<Position>().Pos.Y) && 
                    coin.GetComponent<CoinConfirmation>().CoinUsed == 0)
                {
                    coinScore = true;
                    coin.GetComponent<CoinConfirmation>().CoinUsed = 1;
                    coin.GetComponent<ConsoleSprite>().SwitchSprite(noMoreCoinSprite, ConsoleColor.Gray, ConsoleColor.Gray);
                }
            }

            if (!coinScore)
                return false;
                
            return true;
        }

        private void Falling()
        {
            if (boxes != null)
                boxHit = CheckBox();
            if (boxHit)
            {
                boxHit = false;
            }

            x = position.Pos.X;
            y = position.Pos.Y;
            y++;
            x = Math.Clamp(x, 0, ParentScene.xdim - 8);
            y = Math.Clamp(y, 0, ParentScene.ydim - 3);
            position.Pos = new Vector3(x, y, position.Pos.Z);
            Thread.Sleep(50);
        }

        private void TurnSprite(bool right)
        {
            char[,] playerSprite =
            {
                { '─', '▄', '█', '└' },
                { '▄', '▀', '▄', '▄' },
                { '█', '█', '▐', '▄' },
                { '█', '▀', '▐', '▄' },
                { '█', '▐', '▄', '▄' },
                { '█', '└', '█', '▄' },
                { '▄', '─', '▄', '┘' },
                { '▄', '┐', '┘', ' ' },
            };
            char[,] playerSpriteT =
            {
                { '▄', '┌', '└', ' ' },
                { '▄', '─', '▄', '└' },
                { '█', '┘', '█', '▄' },
                { '█', '▌', '▄', '▄' },
                { '█', '▀', '▌', '▄' },
                { '█', '█', '▌', '▄' },
                { '▄', '▀', '▄', '▄' },
                { '─', '▄', '█', '┘' },
            };

            if (!right)
            {
                ParentGameObject
                .GetComponent<ConsoleSprite>()
                .SwitchSprite(
                    playerSpriteT, 
                    ConsoleColor.Red, 
                    ConsoleColor.Gray);
            }
            else
            {
                ParentGameObject
                .GetComponent<ConsoleSprite>()
                .SwitchSprite(
                    playerSprite, 
                    ConsoleColor.Red, 
                    ConsoleColor.Gray);
            }
        }
    }
}