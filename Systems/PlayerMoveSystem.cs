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

        public PlayerMoveSystem() 
        {
        }


        public void GetVelocity(Player player)
        {
            Position playerPosition = player.GetComponent<Position>();

            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.S))
            {
                playerPosition.Pos += new Vector2(1, 0);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                pos.Y += -1;

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                pos.Y += 1;
            }
            else
            {
                pos.Y += 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                pos.X += 0;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                pos.X += 1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                pos.X += -1;
            }
            else
            {
                pos.X += 0;
            }

/*            if (pos != Vector2.Zero)
            {
                pos.Normalize();
            }*/
        }
    }
}
