using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace FishingRogue
{
    public class Move : Component
    {

        public Move(Entity entity) : base(entity)
        {
        }

        public override void Update(GameTime gameTime)
        {
            Velocity playerVelocity = entity.GetComponent<Velocity>();
            Vector2 vel = playerVelocity.Vel;

            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.S))
            {
                vel = new Vector2(0, 0);
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
                vel *= playerVelocity.SpeedMult;
            }

            playerVelocity.Vel = vel;
        }
    }
}
