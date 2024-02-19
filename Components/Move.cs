﻿using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace FishingRogue
{
    public class Move : Component //: IWASDMovable?
    {

        public Move(Entity entity) : base(entity)
        {
        }

        public override void Update(GameTime gameTime)
        {
            Velocity playerVelocity = entity.GetComponent<Velocity>();
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
                vel *= playerVelocity.SpeedMult;
            }
        }
    }
}
