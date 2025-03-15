using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    class Game
    {
        private const int HEIGHT = 600;
        private const int WIDTH = 800;

        private int countdown = 3;
        private float countdownTimer = 0;
        private int score = 0;
        private float gravity = 0.5f;

        private GameStatus gameStatus;

        public void Init()
        {
            Raylib.InitWindow(WIDTH, HEIGHT, "Flappy Bird Game");
            Raylib.SetTargetFPS(60);
            gameStatus = GameStatus.GameOver;
            countdown = 3;
            countdownTimer = 0;
            score = 0;
        }

        public void Update()
        {
            if (gameStatus.Equals(GameStatus.Ready))
            {
                countdownTimer += Raylib.GetFrameTime();
                
                if( countdownTimer >= 1)
                {
                    countdown--;
                    countdownTimer = 0;
                }

                if (countdown <= 0)
                    gameStatus = GameStatus.Playing;
            }
        }

        public void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.SkyBlue);


            if(gameStatus == GameStatus.Ready)
            {
                Raylib.DrawText(countdown.ToString(), WIDTH / 2 - 20, HEIGHT / 2 - 20, 60, Color.Black);
            }
            else
            {
               if(gameStatus == GameStatus.GameOver)
                {
                    Raylib.DrawText("Game Over", WIDTH / 2 - 160, HEIGHT / 2 - 50, 70, Color.Red);
                    Raylib.DrawText("Press Enter to Restart", WIDTH / 2 - 170, HEIGHT / 2 + 30, 30, Color.White);
                }
            }

            Raylib.EndDrawing();
        }

        public void Run()
        {
            Init();

            while(!Raylib.WindowShouldClose())
            {
                Update();
                Draw();
            }

            Raylib.CloseWindow();
        }
    }
}
