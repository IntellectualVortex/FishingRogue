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
        float _maxPower;
        float _minPower;
        float _powerCoefficient = 3f;
        float _returningSpeed = 1.5f;
        float _playerReach = 10f;
        float chargingSince = 0f;
        float timeLeftFlying = 0f;
        CameraPosition _cameraPosition;
        public enum FishingState
        {
            Ready,
            Charging,
            Casted,
            Returning
        }

        public FishingState fishingState = FishingState.Ready;

        public CastFishingRod(Entity entity, Player player) : base(entity)
        {
            _player = player;
            _maxPower = 5 * _powerCoefficient;
            _minPower = 1 * _powerCoefficient;
        }

        public override void Update(GameTime gameTime)
        {
            MouseState currentMouseState = Mouse.GetState();
            Velocity hookVelocity = entity.GetComponent<Velocity>();
            WorldPosition playerWorldPosition = _player.GetComponent<WorldPosition>();


            switch (fishingState)
            {
                case FishingState.Ready:
                    if (currentMouseState.LeftButton == ButtonState.Pressed && _oldMouseState.LeftButton == ButtonState.Released)
                    {

                        fishingState = FishingState.Charging;
                        chargingSince = (float)gameTime.TotalGameTime.TotalSeconds;
                    }

                    break;


                case FishingState.Charging:
                    if (currentMouseState.LeftButton == ButtonState.Released && _oldMouseState.LeftButton == ButtonState.Pressed)
                    {
                        _power = ((float)gameTime.TotalGameTime.TotalSeconds - chargingSince) * _powerCoefficient + _minPower;
                        fishingState = FishingState.Casted;

                        WorldPosition worldPositionCasted = new WorldPosition(entity, new Vector2(playerWorldPosition.Pos.X, playerWorldPosition.Pos.Y) + ((FishingRodHook)entity).offset);
                        _cameraPosition = entity.GetComponent<CameraPosition>();
                        entity.ReplaceComponent(_cameraPosition, worldPositionCasted);

                        if (_power > _maxPower)
                        {
                            _power = _maxPower;
                        }
                        timeLeftFlying = 1.5f;

                    }
                    break;

                case FishingState.Casted:


                    if (timeLeftFlying > 0)
                    {
                        hookVelocity.Vel = new Vector2(1, 0) * _power;

                    }
                    else
                    {
                        hookVelocity.Vel = new Vector2(0, 0);

                    }

                    if (currentMouseState.LeftButton == ButtonState.Pressed && _oldMouseState.LeftButton == ButtonState.Released)
                    {
                        fishingState = FishingState.Returning;
                    }
                    timeLeftFlying -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;

                case FishingState.Returning:

                    WorldPosition worldPositionReturning = entity.GetComponent<WorldPosition>();

                    // Offset added for hook to return to rod position
                    Vector2 direction = ((playerWorldPosition.Pos + ((FishingRodHook)entity).offset) - worldPositionReturning.Pos);
                    direction.Normalize();
                    hookVelocity.Vel = direction * _returningSpeed;


                    // Offset added for hook to return to rod position
                    if (Vector2.Distance(worldPositionReturning.Pos, playerWorldPosition.Pos + ((FishingRodHook)entity).offset) < _playerReach)
                    {
                        CameraPosition cameraPosition = new CameraPosition(entity, ((FishingRodHook)entity).initialPosition);
                        entity.ReplaceComponent(worldPositionReturning, _cameraPosition);
                        fishingState = FishingState.Ready;
                        _power = 0f;
                        hookVelocity.Vel = new Vector2(0, 0);
                    }
                    break;
            }

            WorldPosition worldPositionDebug = entity.GetComponent<WorldPosition>();



            Debug.WriteLine("hook world pos: " + ((worldPositionDebug == null) ? "it's null" : worldPositionDebug.Pos.ToString()));
            Debug.WriteLine("player world pos: " + playerWorldPosition.Pos.ToString());
            Debug.WriteLine("Fishing State: " + fishingState);
            _oldMouseState = currentMouseState;
        }
    }
}
