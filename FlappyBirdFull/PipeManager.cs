using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdFull
{
    class PipeManager
    {
        private const int pipeWidth = 80;
        private const int spawnInterval = 90;
        private int screenWidth;
        private int screenHeight;
        private List<Pipe> pipes;
        private int frameCounter;
        private Color pipeColor;
        private bool passed;
        public List<Pipe> Pipes => pipes;
        public PipeManager(int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.pipeColor = Raylib_cs.Color.Green;
            pipes = new List<Pipe>();
            frameCounter = 0;
        }

        private void AddPipe()
        {
            int pipeGap = Raylib.GetRandomValue(150, 250);
            int pipeHeight = Raylib.GetRandomValue(100, screenHeight -
            pipeGap - 100);
            Vector2 pipePosition = new Vector2(screenWidth, 0);
            pipes.Add(new Pipe(pipePosition, pipeWidth, pipeHeight,
            pipeGap, pipeColor));
        }

        public void Update()
        {
            frameCounter++;
            // Add new pipe at regular intervals
            if (frameCounter >= spawnInterval)
            {
                AddPipe();

                frameCounter = 0;
            }
            // Update and remove off-screen pipes
            for (int i = pipes.Count - 1; i >= 0; i--)
            {
                pipes[i].Update();
                if (pipes[i].IsOffScreen())
                {
                    pipes.RemoveAt(i);
                }
            }
        }
        public void Draw()
        {
            foreach (var pipe in pipes)
            {
                pipe.Draw();
            }
        }

        public int AddPoint(int score)
        {
            foreach (var pipe in pipes)
            {
                if (pipe.Position.X <= (screenWidth / 4) &&
                (pipe.Position.X + pipeWidth) >= (screenWidth / 4))

                {
                    if (!pipe.Passed)
                    {
                        pipe.Passed = true;
                        score += 1;
                        // Raylib.TraceLog(Raylib_cs.TraceLogLevel.Info, $"Points: {score}");
                    }
                }
            }
            return score;
        }

        public bool CheckCollision(Vector2 birdPosition)
        {
           foreach(var pipe in Pipes)
            {
                if (pipe.CheckCollision(birdPosition)) return true;
            }

            return false;
        }
    }
}
