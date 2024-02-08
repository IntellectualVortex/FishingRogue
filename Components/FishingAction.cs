using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Runtime.InteropServices;

namespace FishingRogue
{
    public class FishingAction : Component
    {

        Player _player;
        float PressedDuration { get; set; }
        MouseState OldMouseState { get; set; } 
        bool isFishing { get; set; } = false;

        float playerFishingRange { get; set; } = 200;


        /* redo the below code by creating a list or enum of hook states
         * based on the state, perform the relevant update mechanics and draws
         * use switch case for better performance
         * 
         * 
         * */

        public FishingAction(Entity entity, Player player) : base(entity)
        {
            _player = player;
        }

        public override void Update(GameTime gameTime) 
        {
            MouseState newMouseState = Mouse.GetState();
            
            WorldPosition hookPosition = entity.GetComponent<WorldPosition>();
            Velocity hookVelocity = entity.GetComponent<Velocity>();
            WorldPosition playerPosition = _player.GetComponent<WorldPosition>();
            var vel = hookVelocity.Vel;

            if (OldMouseState.LeftButton == ButtonState.Released && newMouseState.LeftButton == ButtonState.Released && !isFishing)
            {
                if (hookPosition.Pos.X <= playerFishingRange)
                {
                    vel += new Vector2(PressedDuration, 0);
                }
            }

            if (newMouseState.LeftButton == ButtonState.Pressed && OldMouseState.LeftButton == ButtonState.Released)
            {
                hookPosition.Pos = playerPosition.Pos;
                
            }


            if (newMouseState.LeftButton == ButtonState.Pressed)
            {
                PressedDuration += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
               
            }

            if (vel != Vector2.Zero)
            {
                vel.Normalize();
                vel *= PressedDuration / 100;
            }

            hookPosition.Pos += vel;
            Debug.WriteLine(PressedDuration.ToString());
            OldMouseState = newMouseState;
        }
    }
}
