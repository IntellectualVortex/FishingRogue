#nullable enable

#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

#endregion

namespace FishingRogue
{
    public class Sprite : Component
    {
        public int cameraWidth;
        public int cameraHeight;
        public Texture2D Texture { get; set; }
        public int? customWidth;
        public int? customHeight;
        int Width
        {
            get
            {
                if (customWidth != null) { return (int)customWidth; }
                return Texture.Bounds.Width;
            }
            set
            {
                Width = value;
            }
        }
        int Height
        {
            get
            {
                if (customHeight != null) { return (int)customHeight; }
                return Texture.Bounds.Height;
            }
            set
            {
                Height = value;
            }
        }

        float Rotation { get; set; }

        Player? _player;
        FishingRodHook? _fishingRodHook;

        public Sprite(Entity entity, Texture2D texture, float rotation = 0, int? width = null, int? height = null, FishingRodHook? fRH = null, Player? player = null, int _cameraWidth = 1920, int _cameraHeight = 1080) : base(entity)
        {
            Texture = texture;
            Rotation = rotation;
            _player = player;
            _fishingRodHook = fRH;
            customWidth = width;
            customHeight = height;
            cameraWidth = _cameraWidth;
            cameraHeight = _cameraHeight;
        }

        public void ScaleDraw()
        {
            WorldPosition? entityWorldPosition = entity.GetComponent<WorldPosition>();
            CameraPosition? entityCameraPosition = entity.GetComponent<CameraPosition>();
            Vector2 topleft;
            if (entityWorldPosition != null)
            {
                topleft = WorldSpaceToCameraSpace(entityWorldPosition.Pos);
            }
            else if (entityCameraPosition != null)
            {
                topleft = new Vector2((int)entityCameraPosition.Pos.X, (int)entityCameraPosition.Pos.Y);
            }
            else
            {
                throw new ArgumentException("Camera position and world position are both NULL!");
            }

            Rectangle rectangle = new Rectangle((int)topleft.X, (int)topleft.Y, Width, Height);
            Globals.spriteBatch.Draw(texture: Texture,
            destinationRectangle: rectangle,
            sourceRectangle: null,
            color: Color.White,
            rotation: Rotation,
            origin: new Vector2(Width / 2, Height / 2),
            effects: SpriteEffects.None,
            layerDepth: 0f);
        }

        public void PixelDraw()
        {

            WorldPosition hookWorldPosition = _fishingRodHook.GetComponent<WorldPosition>();
            if (hookWorldPosition != null)
            {
                WorldPosition playerPosition = _player.GetComponent<WorldPosition>();


                Vector2 toHook = (hookWorldPosition.Pos - playerPosition.Pos) - new Vector2(80, 25);
                float length = toHook.Length();
                float angle = (float)Math.Atan2(toHook.Y, toHook.X);

                Globals.spriteBatch.Draw(
                    texture: Texture,
                    position: _fishingRodHook.initialPosition,
                    sourceRectangle: null,
                    color: Color.White,
                    rotation: angle,
                    origin: new Vector2(0, 0),
                    scale: new Vector2(length / 5, 1),
                    effects: SpriteEffects.None,
                    layerDepth: 0
                );
            }
        }


        public Vector2 WorldSpaceToCameraSpace(Vector2 vector)
        {
            WorldPosition? worldPosition = _player == null ? null : _player.GetComponent<WorldPosition>();
            if (worldPosition == null)
            {
                throw new ArgumentException("Forgot to give Player a WorldPosition!!");
            }
            var x_1 = vector.X - worldPosition.Pos.X + cameraWidth / 2;
            var y_1 = vector.Y - worldPosition.Pos.Y + cameraHeight / 2;
            return new Vector2((int)x_1, (int)y_1);
        }



        public override void Update(GameTime gameTime)
        {
            ScaleDraw();
        }

        public override void PixelUpdate(GameTime gameTime)
        {
            PixelDraw();
        }
    }
}


