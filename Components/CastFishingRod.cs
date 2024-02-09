using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using System.Collections;
using System;

namespace FishingRogue
{
    public class CastFishingRod : Component
    {

        Player _player;
        MouseState _oldMouseState;
        //bool _isFishing;  implement for fish catching, pond activity, bobber animation, etc.
        float _power;
        float _powerIncreaseRate = 25f;
        int _hookRange = 400;

        enum FishingState
        {
            Ready,
            Charging,
            Casted,
            Returning
        }

        FishingState fishingState = FishingState.Ready;

        public CastFishingRod(Entity entity, Player player) : base(entity)
        {
            _player = player;
        }

        public override void Update(GameTime gameTime)
        {
            float timePassed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            MouseState currentMouseState = Mouse.GetState();

            WorldPosition hookPosition = entity.GetComponent<WorldPosition>();
            WorldPosition playerPosition = _player.GetComponent<WorldPosition>();
            Vector2 hookStartingPosition = playerPosition.Pos;
            Velocity hookVelocity = entity.GetComponent<Velocity>();

            switch (fishingState)
            {
                case FishingState.Ready:
                    if (currentMouseState.LeftButton == ButtonState.Pressed && _oldMouseState.LeftButton == ButtonState.Released)
                    {
                        fishingState = FishingState.Charging;
                    }
                    break;


                case FishingState.Charging:
                    _power += timePassed * _powerIncreaseRate;

                    if (currentMouseState.LeftButton == ButtonState.Released && _oldMouseState.LeftButton == ButtonState.Pressed)
                    {
                        fishingState = FishingState.Casted;
                        hookVelocity.Vel = new Vector2(1, 0) * _power;
                        hookPosition.Pos = playerPosition.Pos;
                    }
                    break;

                case FishingState.Casted:

                    if (hookPosition.Pos.X <= _hookRange)
                    {
                        hookVelocity.Vel += new Vector2(0, 9.8f) * timePassed;
                        hookPosition.Pos += hookVelocity.Vel * timePassed;
                    }
                    else
                    {
                        hookVelocity.Vel = new Vector2(0, 0);
                    }

                    if (currentMouseState.LeftButton == ButtonState.Pressed && _oldMouseState.LeftButton == ButtonState.Released)
                    {
                        fishingState = FishingState.Returning;
                    }
                    break;

                case FishingState.Returning:

                    hookPosition.Pos = Vector2.Lerp(hookPosition.Pos, hookStartingPosition, 0.1f);

                    if (Vector2.Distance(hookPosition.Pos, hookStartingPosition) < 1f)
                    {
                        fishingState = FishingState.Ready;
                        _power = 0f;
                    }
                    break;
            }

            Debug.WriteLine(_power.ToString());
            _oldMouseState = currentMouseState;
        }
    }
}
