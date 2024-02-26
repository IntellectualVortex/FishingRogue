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
        float _powerCoefficient = 10f;
        float _returningSpeed = 5f;
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

            CameraPosition hookCameraPosition = entity.GetComponent<CameraPosition>();
            WorldPosition hookWorldPosition = entity.GetComponent<WorldPosition>();
            Velocity hookVelocity = entity.GetComponent<Velocity>();
            Vector2 hookInitialPosition = ((FishingRodHook)entity).initialPosition;


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
                        _cameraPosition = hookCameraPosition;
                        entity.ReplaceComponent(hookCameraPosition, hookWorldPosition);
                        

                        if (_power > _maxPower)
                        {
                            _power = _maxPower;
                        }
                        timeLeftFlying = 3f;

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
                    
                    Vector2 direction = (hookInitialPosition - hookWorldPosition.Pos);
                    direction.Normalize();
                    hookVelocity.Vel = direction * _returningSpeed;


                    if (Vector2.Distance(hookWorldPosition.Pos, hookInitialPosition) < _playerReach)
                    {
                        entity.ReplaceComponent(hookWorldPosition, _cameraPosition);
                        fishingState = FishingState.Ready;
                        _power = 0f;

                    }
                    break;
            }

            Debug.WriteLine(hookWorldPosition.Pos, hookInitialPosition.ToString());
            _oldMouseState = currentMouseState;
        }
    }
}
