﻿using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdFull
{
    public class Pipe
    {
        private Vector2 position;
        private readonly int width;
        private readonly int height;
        private readonly int gap;
        private readonly Raylib_cs.Color color;
        private const int screenHeight = 600;

        private const int birdRadius = 10;
        private const int moveSpeed = 2;
        public Vector2 Position => position;
        public int Width => width;
        public bool Passed { get; set; }
        public Pipe(Vector2 position, int width, int height, int gap, Color color)
        {
            this.position = position;
            this.width = width;
            this.height = height;
            this.gap = gap;
            this.color = color;
            this.Passed = false;
        }

        public void Update()
        {
            position.X -= moveSpeed;
        }
        public void Draw()
        {
            Raylib.DrawRectangle((int)position.X, (int)position.Y, width, height, color);
            Raylib.DrawRectangle((int)position.X, (int)position.Y + height + gap, width, screenHeight - height - gap, color);
        }

        public bool IsOffScreen()
        {
            return position.X + width < 0;
        }

        public bool CheckCollision(Vector2 birdPosition)
        {
            bool topPipe = birdPosition.X + birdRadius > position.X &&
                            birdPosition.X - birdRadius < position.X + width &&
                            birdPosition.Y - birdRadius < position.Y + height;

            bool bottomPipe = birdPosition.X + birdRadius > position.X &&
                                birdPosition.X - birdRadius < position.X + width &&
                                birdPosition.Y + birdRadius > position.Y + height + gap;

            return topPipe || bottomPipe;
        }
    }
}
