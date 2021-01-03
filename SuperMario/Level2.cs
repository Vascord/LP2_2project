using System;
using System.Collections.Generic;
using CoreGameEngine;

namespace SuperMario
{
    public class Level2
    {
         int xdim = 200, ydim = 30;

        int frameLenght = 10;

        private Scene gameScene;
        public List<Vector2> Occupied = new List<Vector2>();
        public List<GameObject> coins = new List<GameObject>();
        public List<GameObject> boxes = new List<GameObject>();



        public Level2()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            CreateLevel();
        }
        private void CreateLevel()
        {
            // Create scene
            ConsoleKey[] quitKeys = new ConsoleKey[] { ConsoleKey.Escape};
            gameScene = new Scene(xdim, ydim,
                new InputHandler(quitKeys),
                new ConsoleRenderer(xdim, ydim, new ConsolePixel(' ')),
                new CollisionHandler(xdim, ydim));
            
            // Create quitter object
            GameObject quitter = new GameObject("Quitter");
            KeyObserver quitSceneKeyListener = new KeyObserver(new ConsoleKey[]
                { ConsoleKey.Escape });
            quitter.AddComponent(quitSceneKeyListener);
            quitter.AddComponent(new Quitter());
            gameScene.AddGameObject(quitter);

            

            

            // Create walls
            GameObject walls = new GameObject("Walls");
            ConsolePixel wallPixel = new ConsolePixel(
                ' ', ConsoleColor.Blue, ConsoleColor.DarkGray);
            Dictionary<Vector2, ConsolePixel> wallPixels =
                new Dictionary<Vector2, ConsolePixel>();
            
            
            for (int x = 0; x < xdim; x++)
            {
                //Ground and walls
                if((x > 0 && x < 38) ||(x > 54 && x < 57) || (x > 84 && x < 87)  || (x > 135 && x < 150) || (x > 160 && x < xdim))
                {
                    //wallPixels[new Vector2(x, 0)] = wallPixel;
                    wallPixels[new Vector2(x, ydim - 1)] = wallPixel;
                    Occupied.Add(new Vector2(x, ydim - 1));
                    wallPixels[new Vector2(x, ydim - 2)] = wallPixel;
                    Occupied.Add(new Vector2(x, ydim - 2));
                    wallPixels[new Vector2(x, ydim - 3)] = wallPixel;
                    Occupied.Add(new Vector2(x, ydim - 3));
                    wallPixels[new Vector2(x, ydim - 4)] = wallPixel;
                    Occupied.Add(new Vector2(x, ydim - 4));
                    wallPixels[new Vector2(x, ydim - 5)] = wallPixel;
                    Occupied.Add(new Vector2(x, ydim - 5));
                    wallPixels[new Vector2(x, ydim - 6)] = wallPixel;
                    Occupied.Add(new Vector2(x, ydim - 6));
                    wallPixels[new Vector2(x, ydim - 7)] = wallPixel;
                    Occupied.Add(new Vector2(x, ydim - 7));

                }

                // Plataform 1
                if(x > 30 && x < 45)
                {
                    wallPixels[new Vector2(x, ydim - 18)] = wallPixel;
                    Occupied.Add(new Vector2(x, ydim - 18));
                }
                // Plataform 2
                if(x > 65 && x < 80)
                {
                    wallPixels[new Vector2(x, ydim - 18)] = wallPixel;
                    Occupied.Add(new Vector2(x, ydim - 18));
                }
                // Plataform 3
                if(x > 5 && x < 20)
                {
                    wallPixels[new Vector2(x, ydim - 22)] = wallPixel;
                    Occupied.Add(new Vector2(x, ydim - 22));
                }
                // Plataform 4
                if(x > 90 && x < 140)
                {
                    wallPixels[new Vector2(x, ydim - 22)] = wallPixel;
                    Occupied.Add(new Vector2(x, ydim - 22));
                }

                // Plataform 5
                if(x > 90 && x < 120)
                {
                    wallPixels[new Vector2(x, ydim - 5)] = wallPixel;
                    Occupied.Add(new Vector2(x, ydim - 5));
                }
                
            }
            for (int y = 0; y < ydim; y++)
            {
                wallPixels[new Vector2(0, y)] = wallPixel;
                Occupied.Add(new Vector2(0, y));
                wallPixels[new Vector2(xdim - 1, y)] = wallPixel;
                Occupied.Add(new Vector2(xdim - 1, y));
                
            }
            BuildObstacles();
            
                
            walls.AddComponent(new ConsoleSprite(wallPixels));
            walls.AddComponent(new Position(0, 0, 1));
            gameScene.AddGameObject(walls);

            

            

            // Create game object for showing score
            GameObject score = new GameObject("Score");
            score.AddComponent(new Position(1, 0, 10));
            score.AddComponent(new Score());
            RenderableStringComponent visualScore = new RenderableStringComponent(
                () => "Score: " + 3000.ToString(),
                i => new Vector2(i, 0),
                ConsoleColor.DarkMagenta, ConsoleColor.White);
            score.AddComponent(visualScore);
            gameScene.AddGameObject(score);

            // Create Coin Sprite
            char[,] coinSprite =
            {
                {'█'}
            };

            //COin 1
            GameObject coin1 = new GameObject("Coin1");
            coin1.AddComponent(new ConsoleSprite(coinSprite));
            coin1.AddComponent(new Position(135, 19, 0f));
            coin1.AddComponent(new CoinConfirmation());
            gameScene.AddGameObject(coin1);
            coins.Add(coin1);

            //Coin 2
            GameObject coin2 = new GameObject("Coin2");
            coin2.AddComponent(new ConsoleSprite(coinSprite));
            coin2.AddComponent(new Position(6, 4, 0f));
            coin2.AddComponent(new CoinConfirmation());
            gameScene.AddGameObject(coin2);
            coins.Add(coin2);

            // Create Box 
            char[,] boxSprite=
            {
                { '█', '█', '█' , '█'},
                { '█', '?', '?' , '█'},
                { '█', '?', '?' , '█'},
                { '█', '?', '?' , '█'},
                { '█', '?', '?' , '█'},
                { '█', '█', '█' , '█'}  
            };
            GameObject box = new GameObject("Box");
            box.AddComponent(new ConsoleSprite(boxSprite, ConsoleColor.Yellow, 
                ConsoleColor.DarkGray));
            box.AddComponent(new Position(110, 11, 0f));
            box.AddComponent(new BoxConfirmation());
            gameScene.AddGameObject(box);
            boxes.Add(box);

            // Create Box2
            // GameObject box2 = new GameObject("Box2");
            // box2.AddComponent(new ConsoleSprite(boxSprite, ConsoleColor.Yellow, 
            //     ConsoleColor.DarkGray));
            // box2.AddComponent(new Position(150, 8, 0f));
            // box2.AddComponent(new BoxConfirmation());
            // gameScene.AddGameObject(box2);
            // boxes.Add(box2);

            GameObject dead = new GameObject("Dead");
            dead.AddComponent(new Position(70, 10, 10));
            RenderableStringComponent deadString = new RenderableStringComponent(
                () => "",
                i => new Vector2(i, 0),
                ConsoleColor.Red, ConsoleColor.Gray);
            dead.AddComponent(deadString);
            gameScene.AddGameObject(dead);

            // Create player object
            // ─▄████▄▄
            // ▄▀█▀▐└─┐
            // █▄▐▌▄█▄┘
            // └▄▄▄▄▄┘
            char[,] playerSprite =
            {
                { '─', '▄', '█' , '└'},
                { '▄', '▀', '▄' , '▄'},
                { '█', '█', '▐' , '▄'},
                { '█', '▀', '▐' , '▄'},
                { '█', '▐', '▄' , '▄'},
                { '█', '└', '█' , '▄'},
                { '▄', '─', '▄' , '┘'},
                { '▄', '┐', '┘' , ' '}
            };
            GameObject player = new GameObject("Player");
            KeyObserver playerKeyListener = new KeyObserver(new ConsoleKey[] {
                ConsoleKey.RightArrow,
                ConsoleKey.Spacebar,
                ConsoleKey.UpArrow,
                ConsoleKey.LeftArrow});
            player.AddComponent(playerKeyListener);
            Position playerPos = new Position(1f, 19f, 0f);
            player.AddComponent(playerPos);
            player.AddComponent(new Player(Occupied, score.GetComponent<Score>(), boxes, coins, dead));
            player.AddComponent(new ConsoleSprite(
                playerSprite, ConsoleColor.Red, ConsoleColor.Gray));
            //player.AddComponent(new SpriteCollider());
            gameScene.AddGameObject(player);

            


            // Create game object for showing time limit
            GameObject time = new GameObject("Time");
            time.AddComponent(new Position(190, 0, 10));
            time.AddComponent(new Time());
            RenderableStringComponent visualTime = new RenderableStringComponent(
                () => "Time: " + 200.ToString(),
                i => new Vector2(i, 0),
                ConsoleColor.DarkMagenta, ConsoleColor.White);
            time.AddComponent(visualTime);
            gameScene.AddGameObject(time);

        }

        public void Run()
        {
            gameScene.GameLoop(frameLenght);
        }

        public void BuildObstacles()
        {
            GameObject obstacle = new GameObject("Obstacle");
            ConsolePixel obstaclePixel = new ConsolePixel(
                ' ', ConsoleColor.Blue, ConsoleColor.Green);
            Dictionary<Vector2, ConsolePixel> obstaclePixels =
                new Dictionary<Vector2, ConsolePixel>();

            //Obstacle GreenTube 1
            obstaclePixels[new Vector2(34, 19)] = obstaclePixel;
            Occupied.Add(new Vector2(34, 19));

            obstaclePixels[new Vector2(37, 19)] = obstaclePixel;
            Occupied.Add(new Vector2(37, 19));

            obstaclePixels[new Vector2(35, 20)] = obstaclePixel;
            Occupied.Add(new Vector2(35, 20));
            
            obstaclePixels[new Vector2(35, 21)] = obstaclePixel;
            Occupied.Add(new Vector2(35, 21));

            obstaclePixels[new Vector2(35, 19)] = obstaclePixel;
            Occupied.Add(new Vector2(35, 19));

            obstaclePixels[new Vector2(35, 22)] = obstaclePixel;
            Occupied.Add(new Vector2(35, 22));

            obstaclePixels[new Vector2(36, 20)] = obstaclePixel;
            Occupied.Add(new Vector2(36, 20));
            
            obstaclePixels[new Vector2(36, 21)] = obstaclePixel;
            Occupied.Add(new Vector2(36, 21));

            obstaclePixels[new Vector2(36, 19)] = obstaclePixel;
            Occupied.Add(new Vector2(36, 19));

            obstaclePixels[new Vector2(36, 22)] = obstaclePixel;
            Occupied.Add(new Vector2(36, 22));

            //Obstacle GreenTube 2
            obstaclePixels[new Vector2(54, 19)] = obstaclePixel;
            Occupied.Add(new Vector2(54, 19));

            obstaclePixels[new Vector2(57, 19)] = obstaclePixel;
            Occupied.Add(new Vector2(57, 19));

            obstaclePixels[new Vector2(55, 20)] = obstaclePixel;
            Occupied.Add(new Vector2(55, 20));
            
            obstaclePixels[new Vector2(55, 21)] = obstaclePixel;
            Occupied.Add(new Vector2(55, 21));

            obstaclePixels[new Vector2(55, 19)] = obstaclePixel;
            Occupied.Add(new Vector2(55, 19));

            obstaclePixels[new Vector2(55, 22)] = obstaclePixel;
            Occupied.Add(new Vector2(55, 22));

            obstaclePixels[new Vector2(56, 20)] = obstaclePixel;
            Occupied.Add(new Vector2(56, 20));
            
            obstaclePixels[new Vector2(56, 21)] = obstaclePixel;
            Occupied.Add(new Vector2(56, 21));

            obstaclePixels[new Vector2(56, 19)] = obstaclePixel;
            Occupied.Add(new Vector2(56, 19));

            obstaclePixels[new Vector2(56, 22)] = obstaclePixel;
            Occupied.Add(new Vector2(56, 22));

            //Obstacle GreenTube 3
            obstaclePixels[new Vector2(84, 19)] = obstaclePixel;
            Occupied.Add(new Vector2(84, 19));

            obstaclePixels[new Vector2(87, 19)] = obstaclePixel;
            Occupied.Add(new Vector2(87, 19));

            obstaclePixels[new Vector2(85, 20)] = obstaclePixel;
            Occupied.Add(new Vector2(85, 20));
            
            obstaclePixels[new Vector2(85, 21)] = obstaclePixel;
            Occupied.Add(new Vector2(85, 21));

            obstaclePixels[new Vector2(85, 19)] = obstaclePixel;
            Occupied.Add(new Vector2(85, 19));

            obstaclePixels[new Vector2(85, 22)] = obstaclePixel;
            Occupied.Add(new Vector2(85, 22));

            obstaclePixels[new Vector2(86, 20)] = obstaclePixel;
            Occupied.Add(new Vector2(86, 20));
            
            obstaclePixels[new Vector2(86, 21)] = obstaclePixel;
            Occupied.Add(new Vector2(86, 21));

            obstaclePixels[new Vector2(86, 19)] = obstaclePixel;
            Occupied.Add(new Vector2(86, 19));

            obstaclePixels[new Vector2(86, 22)] = obstaclePixel;
            Occupied.Add(new Vector2(86, 22));

            obstacle.AddComponent(new ConsoleSprite(obstaclePixels));
            obstacle.AddComponent(new Position(0, 0, 0));
            gameScene.AddGameObject(obstacle);
        }

    }
}