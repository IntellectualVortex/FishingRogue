#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Runtime.CompilerServices;

#endregion

namespace FishingRogue
{
    class Sprite : Component
    {
        Vector2 Position { get; set; }
        Texture2D Texture { get; set; } 
        int Width { get; set; }
        int Height { get; set; }
        Color Color { get; set; }
        float Rotation { get; set; }

        Player _player;

        public Sprite(Entity entity, Player player, Texture2D texture, Color color, float rotation = 0, int width = 100, int height = 100, Vector2 position = default) : base(entity)
        {
            Texture = texture;
            _player = player;
            Width = width;
            Height = height;
            Color = color;
            Rotation = rotation;
            Position = position;
        }

        public void ScaleDraw(Texture2D tex, int _width, int _height, Color color, float rot)
        {
            var rectangle = WorldSpaceToCameraSpace();
            Globals.spriteBatch.Draw(tex,
            rectangle,
            null,
            color,
            rot, new Vector2(tex.Bounds.Width / 2, tex.Bounds.Height / 2), SpriteEffects.None, 0f);
        }

        public Rectangle WorldSpaceToCameraSpace()
        {
            Position entityPosition = entity.GetComponent<Position>();
            //Position playerPosition = _player.GetComponent<Position>();


            var x_1 = entityPosition.Pos.X - Position.X + Globals.gDM.PreferredBackBufferWidth / 2;
            var y_1 = entityPosition.Pos.Y - Position.Y + Globals.gDM.PreferredBackBufferHeight / 2;
            return new Rectangle((int)x_1, (int)y_1, Width, Height);
        }

        public override void Update(GameTime gameTime)
        {
            Sprite entitySprite = entity.GetComponent<Sprite>();
            Position entityPosition = entity.GetComponent<Position>();
            if (entitySprite == null || entityPosition == null)
            {
                throw new NullReferenceException("You fucked up, probably forgot to add this type of component in this entites constructor");
            }

            // Add ability to draw based of any arbitrary position, absolute position e.g. UI

            if (Width != 0 & Height != 0) // default value of any built-in integral numeric type
            {
                ScaleDraw(entitySprite.Texture, Width, Height, Color, Rotation);
            }
            else
            {
                ScaleDraw(entitySprite.Texture, Texture.Bounds.Width, Texture.Bounds.Width, Color, Rotation); // cant create default for width, height due to constant error
            }
        }
    }
}
