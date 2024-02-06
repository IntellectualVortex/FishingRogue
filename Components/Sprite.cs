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
    class Sprite : Component
    {
        Texture2D Texture { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        float Rotation { get; set; }

        Player? _player;

        public Sprite(Entity entity, Texture2D texture, float rotation = 0, int? width = null, int? height = null, Player? player = null) : base(entity)
        {
            Texture = texture;
            Rotation = rotation;
            _player = player;

            if (width == null)
            {
                Width = Texture.Bounds.Width;
            }
            if (height == null)
            {
                Height = Texture.Bounds.Height;
            }
        }

        public void ScaleDraw()
        {
            var rectangle = WorldSpaceToCameraSpace();
            Globals.spriteBatch.Draw(texture: Texture,
            destinationRectangle: rectangle,
            sourceRectangle: null,
            color: Color.White,
            rotation: Rotation,
            origin: new Vector2(Texture.Bounds.Width / 2, Texture.Bounds.Height / 2),
            effects: SpriteEffects.None,
            layerDepth: 0f);
        }

        public Rectangle WorldSpaceToCameraSpace()
        {
            Position? playerPosition = null;

            Position entityPosition = entity.GetComponent<Position>();
            FixedPosition fixedPosition = entity.GetComponent<FixedPosition>();
            Debug.WriteLine(entityPosition.Pos.X.ToString() + ", " + entityPosition.Pos.Y.ToString());

            if (_player != null)
            {
                playerPosition = _player.GetComponent<Position>();
            }

            if (fixedPosition == null && playerPosition != null)
            {
                var x_1 = entityPosition.Pos.X - playerPosition.Pos.X + Globals.gDM.PreferredBackBufferWidth / 2;
                var y_1 = entityPosition.Pos.Y - playerPosition.Pos.Y + Globals.gDM.PreferredBackBufferHeight / 2;
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


