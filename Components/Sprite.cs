#nullable enable

#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

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
        FishingRodHook _fishingRodHook;

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
            var rectangle = WorldSpaceToCameraSpace();
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
            WorldPosition playerPosition = _player.GetComponent<WorldPosition>();
            WorldPosition hookWorldPosition = _fishingRodHook.GetComponent<WorldPosition>();
            Vector2 hookStartingPosition = playerPosition.Pos;

            Vector2 toHook = (hookWorldPosition.Pos - hookStartingPosition);
            float length = toHook.Length();
            float angle = (float)Math.Atan2(toHook.Y, toHook.X);

            Globals.spriteBatch.Draw(Texture, hookWorldPosition.Pos, null, Color.White, angle, new Vector2(0, 0), new Vector2(length, 1), SpriteEffects.None, 0);
        }

        public Rectangle WorldSpaceToCameraSpace()
        {
            WorldPosition? playerPosition = null;
            WorldPosition entityPosition = entity.GetComponent<WorldPosition>();
            CameraPosition? fixedPosition = entity.GetComponent<CameraPosition>();


            if (_player != null)
            {
                playerPosition = _player.GetComponent<WorldPosition>();
            }


            if (fixedPosition == null && playerPosition != null)
            {
                var x_1 = entityPosition.Pos.X - playerPosition.Pos.X + cameraWidth / 2;
                var y_1 = entityPosition.Pos.Y - playerPosition.Pos.Y + cameraHeight / 2;
                return new Rectangle((int)x_1, (int)y_1, Width, Height);
            }
            if (fixedPosition != null)
            {
                return new Rectangle((int)fixedPosition.Pos.X, (int)fixedPosition.Pos.Y, Width, Height);
            }
            else
            {
                throw new ArgumentException("FIXED POSITION IS NULL!");
            }
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


