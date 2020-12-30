using System;
using System.Collections.Generic;
using CoreGameEngine;
namespace SuperMario
{
    public class Level1
    {
        int xdim = 250, ydim = 30;

        int frameLenght = 10;

        private Scene gameScene;
        public List<Vector2> Occupied = new List<Vector2>();
        public List<Vector2> Coin = new List<Vector2>();


        public Level1()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            CreateLevel();
        }
        private void CreateLevel()
        {
            // Create scene
            ConsoleKey[] quitKeys = new ConsoleKey[] { ConsoleKey.Escape };
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
            
            GameObject obstacle = new GameObject("Obstacle");
            ConsolePixel obstaclePixel = new ConsolePixel(
                ' ', ConsoleColor.Blue, ConsoleColor.Green);
            Dictionary<Vector2, ConsolePixel> obstaclePixels =
                new Dictionary<Vector2, ConsolePixel>();
            for (int x = 0; x < xdim; x++)
            {
                if((x > 0 && x < 25) || (x > 30 && x < xdim))
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
                
            }
            for (int y = 0; y < ydim; y++)
            {
                wallPixels[new Vector2(0, y)] = wallPixel;
                Occupied.Add(new Vector2(0, y));
                wallPixels[new Vector2(xdim - 1, y)] = wallPixel;
                Occupied.Add(new Vector2(xdim - 1, y));
                
            }

            obstaclePixels[new Vector2(49, 19)] = obstaclePixel;
            Occupied.Add(new Vector2(49, 19));

            obstaclePixels[new Vector2(52, 19)] = obstaclePixel;
            Occupied.Add(new Vector2(52, 19));

            obstaclePixels[new Vector2(50, 20)] = obstaclePixel;
            Occupied.Add(new Vector2(50, 20));
            
            obstaclePixels[new Vector2(50, 21)] = obstaclePixel;
            Occupied.Add(new Vector2(50, 21));

            obstaclePixels[new Vector2(50, 19)] = obstaclePixel;
            Occupied.Add(new Vector2(50, 19));

            obstaclePixels[new Vector2(50, 22)] = obstaclePixel;
            Occupied.Add(new Vector2(50, 22));

            obstaclePixels[new Vector2(51, 20)] = obstaclePixel;
            Occupied.Add(new Vector2(51, 20));
            
            obstaclePixels[new Vector2(51, 21)] = obstaclePixel;
            Occupied.Add(new Vector2(51, 21));

            obstaclePixels[new Vector2(51, 19)] = obstaclePixel;
            Occupied.Add(new Vector2(51, 19));

            obstaclePixels[new Vector2(51, 22)] = obstaclePixel;
            Occupied.Add(new Vector2(51, 22));
                
            walls.AddComponent(new ConsoleSprite(wallPixels));
            walls.AddComponent(new Position(0, 0, 1));
            gameScene.AddGameObject(walls);

            obstacle.AddComponent(new ConsoleSprite(obstaclePixels));
            obstacle.AddComponent(new Position(0, 0, 0));
            gameScene.AddGameObject(obstacle);

            ConsolePixel coinPixel = new ConsolePixel(
                ' ', ConsoleColor.Blue, ConsoleColor.Green);
            Dictionary<Vector2, ConsolePixel> coinPixels =
                new Dictionary<Vector2, ConsolePixel>();

            coinPixels[new Vector2(80, 13)] = coinPixel;
            Coin.Add(new Vector2(80, 13));
            coinPixels[new Vector2(80, 14)] = coinPixel;
            Coin.Add(new Vector2(80, 14));
            coinPixels[new Vector2(81, 13)] = coinPixel;
            Coin.Add(new Vector2(81, 13));
            coinPixels[new Vector2(81, 14)] = coinPixel;
            Coin.Add(new Vector2(81, 14));

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

            // Create player object
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
            player.AddComponent(new Player(Occupied, Coin,score.GetComponent<Score>()));
            player.AddComponent(new ConsoleSprite(
                playerSprite, ConsoleColor.Red, ConsoleColor.Gray));
            //player.AddComponent(new SpriteCollider());
            gameScene.AddGameObject(player);

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
            box.AddComponent(new Position(100, 8, 0f));
            gameScene.AddGameObject(box);


            // Create game object for showing time limit
            GameObject time = new GameObject("Time");
            time.AddComponent(new Position(240, 0, 10));
            time.AddComponent(new Time());
            RenderableStringComponent visualTime = new RenderableStringComponent(
                () => "Time: " + 200.ToString(),
                i => new Vector2(i, 0),
                ConsoleColor.DarkMagenta, ConsoleColor.White);
            time.AddComponent(visualTime);
            gameScene.AddGameObject(time);

            // Create Coin
            char[,] coinSprite=
            {
                { '█', '█'},
                { '█', '█'},        
            };
            GameObject coin = new GameObject("Coin");
            coin.AddComponent(new ConsoleSprite(coinSprite, ConsoleColor.Yellow, 
                ConsoleColor.DarkGray));
            coin.AddComponent(new Position(80, 13, 0f));
            coin.AddComponent(new Coin(score.GetComponent<Score>()));
            gameScene.AddGameObject(coin);

        }

        public void Run()
        {
            gameScene.GameLoop(frameLenght);
        }

    }
}

// ─ ▄ █ █ █ █ ▄ ▄

// ▄ ▀ █ ▀ ▐ └ ─ ┐

// █ ▄ ▐ ▌ ▄ █ ▄ ┘

// └ ▄ ▄ ▄ ▄ ▄ ┘


//_ _ _ _ ▒ ▒ ▒ ▒ ▒

//— - ▒ ▒ ▒ ▒ ▒ ▒ ▒ ▒ ▒

//— – ▓ ▓ ▓ ░ ░ ▓ ░

//— ▓ ░ ▓ ░ ░ ░ ▓ ░ ░ ░

//— ▓ ░ ▓ ▓ ░ ░ ░ ▓ ░ ░ ░

//— ▓ ▓ ░ ░ ░ ░ ▓ ▓ ▓ ▓

//— — ░ ░ ░ ░ ░ ░ ░ ░

//— - ▓ ▓ ▒ ▓ ▓ ▓ ▒ ▓ ▓ 

//– ▓ ▓ ▓ ▒ ▓ ▓ ▓ ▒ ▓ ▓ ▓

//░ ░ ▓ ▒ ░ ▒ ▒ ▒ ░ ▒ ▓ ░ ░


//— - ▒ ▒ ▒  — — ▒ ▒ ▒ 

//– ▓ ▓ ▓ — — — - ▓ ▓ ▓ 

//▓ ▓ ▓ ▓ — — — - ▓ ▓ ▓ ▓ 


// ____▒▒▒▒▒
// —-▒▒▒▒▒▒▒▒▒
// —–▓▓▓░░▓░
// —▓░▓░░░▓░░░
// —▓░▓▓░░░▓░░░
// —▓▓░░░░▓▓▓▓
// ——░░░░░░░░
// —-▓▓▒▓▓▓▒▓▓
// –▓▓▓▒▓▓▓▒▓▓▓
// ▓▓▓▓▒▒▒▒▒▓▓▓▓
// ░░▓▒░▒▒▒░▒▓░░
// ░░░▒▒▒▒▒▒▒░░░
// ░░▒▒▒▒▒▒▒▒▒░░
// —-▒▒▒ ——▒▒▒
// –▓▓▓———-▓▓▓
// ▓▓▓▓———-▓▓▓▓



        