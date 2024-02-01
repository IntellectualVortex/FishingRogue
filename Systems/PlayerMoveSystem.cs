using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FishingRogue
{
    class PlayerMoveSystem
    {
        float speedMult = 1.5f;

        public PlayerMoveSystem() 
        {
        }


        public void GetVelocity(Player player)
        {
            Position playerPosition = player.GetComponent<Position>();
            Velocity playerVelocity = player.GetComponent<Velocity>();
            var vel = playerVelocity.Vel;

            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.S))
            {
                vel += new Vector2(0, 0);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                vel += new Vector2(0, -1);

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                vel += new Vector2(0, 1);
            }
            else
            {
                vel += new Vector2(0, 0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                vel += new Vector2(0, 0);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                vel += new Vector2(1, 0);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                vel += new Vector2(-1, 0);
            }
            else
            {
                vel += new Vector2(0, 0);
            }

            if (vel != Vector2.Zero)
            {
                vel.Normalize();
                vel *= speedMult;
            }

            playerPosition.Pos += vel;
        }
    }
}
