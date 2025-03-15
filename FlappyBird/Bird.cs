using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    public class Bird
    {
        private Vector2 position;
        private Vector2 velocity;
        private float gravity;

        private const float flapStrength = -8.0f;
        private const int size = 20;
        private const float maxVelocity = 10.0f;

        public Vector2 Position => position;


        public Bird()
        {

        }
    }
}
