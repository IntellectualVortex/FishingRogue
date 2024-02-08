using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.AccessControl;

namespace FishingRogue
{
    public class FishingAction : Component
    {

        Player _player;
        float pressedDuration { get; set; }



        public FishingAction(Entity entity, Player player) : base(entity)
        {
            _player = player;
        }

        public override void Update(GameTime gameTime) 
        {
            MouseState newMouseState = Mouse.GetState();
            MouseState oldMouseState = Mouse.GetState();
            
            WorldPosition hookPosition = entity.GetComponent<WorldPosition>();
            Velocity hookVelocity = entity.GetComponent<Velocity>();
            WorldPosition playerPosition = _player.GetComponent<WorldPosition>();
            var vel = hookVelocity.Vel;

            if (oldMouseState.LeftButton == ButtonState.Pressed && newMouseState.LeftButton == ButtonState.Released)
            {
                vel += new Vector2(pressedDuration, 0);

                pressedDuration += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                hookPosition.Pos = playerPosition.Pos;
            }

            if (newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                //first time pres logic
            }

            if (newMouseState.LeftButton == ButtonState.Pressed)
            {
                // left click held down logic
            }


            if (vel != Vector2.Zero)
            {
                vel.Normalize();
                vel *= pressedDuration / 1000;
            }

            hookPosition.Pos += vel;
            Debug.WriteLine(pressedDuration.ToString());
            oldMouseState = newMouseState;
        }

    }
}
