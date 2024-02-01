using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingRogue
{
    class PlayerMovementSystem 
    {

        public PlayerMovementSystem() {}

        public void Move(Vector2 vel)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.S))
            {
                vel.Y = 0;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                vel.Y = -1;

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                vel.Y = 1;
            }
            else
            {
                vel.Y = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                vel.X = 0;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                vel.X = 1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                vel.X = -1;
            }
            else
            {
                vel.X = 0;
            }

            if (vel != Vector2.Zero)
            {
                vel.Normalize();
            }
        }
    }
}
