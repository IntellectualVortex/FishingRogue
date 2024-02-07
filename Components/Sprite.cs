#nullable enable

#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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

        public Sprite(Entity entity, Texture2D texture, float rotation = 0, int? width = null, int? height = null, Player? player = null, int _cameraWidth = 1920, int _cameraHeight = 1080) : base(entity)
        {
            Texture = texture;
            Rotation = rotation;
            _player = player;
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

        public Rectangle WorldSpaceToCameraSpace()
        {
            WorldPosition? playerPosition = null;

            WorldPosition entityPosition = entity.GetComponent<WorldPosition>();
            CameraPosition fixedPosition = entity.GetComponent<CameraPosition>();


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
            else
            {
                return new Rectangle((int)fixedPosition.Pos.X, (int)fixedPosition.Pos.Y, Width, Height);
            }
        }

        public override void Update(GameTime gameTime)
        {
            ScaleDraw();
        }
    }
}


