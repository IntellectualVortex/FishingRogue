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
        Texture2D Texture { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        Color Color { get; set; } = Color.White;
        float Rotation { get; set; } 

        Player _player;

        public Sprite(Entity entity, Player player, Texture2D texture) : base(entity)
        {
            Texture = texture;
            _player = player;
        }

        public Sprite(Entity entity, Player player, Texture2D texture, int width, int height, Color color, float rotation) : base(entity)
        {
            Texture = texture;
            _player = player;
            Width = width;
            Height = height;
            Color = color;
            Rotation = rotation;
        }

        public Sprite(Entity entity) : base(entity)
        {
        }

        public void ScaleDraw(Texture2D tex, Vector2 pos, int width, int height, Color color, float rot)
        {
            var rectangle = WorldSpaceToCameraSpace(width, height);
            Globals.spriteBatch.Draw(tex,
            rectangle,
            null,
            color,
            rot, new Vector2(tex.Bounds.Width / 2, tex.Bounds.Height / 2), SpriteEffects.None, 0f);
        }

        public Rectangle WorldSpaceToCameraSpace(int width, int height)
        {
            Position entityPosition = entity.GetComponent<Position>();
            Position playerPosition = _player.GetComponent<Position>();

            var x_1 = entityPosition.Pos.X - playerPosition.Pos.X + Globals.gDM.PreferredBackBufferWidth / 2;
            var y_1 = entityPosition.Pos.Y - playerPosition.Pos.Y + Globals.gDM.PreferredBackBufferHeight / 2;
            return new Rectangle((int)x_1, (int)y_1, width, height);
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
                ScaleDraw(entitySprite.Texture, entityPosition.Pos, Width, Height, Color, Rotation);
            }
            else
            {
                ScaleDraw(entitySprite.Texture, entityPosition.Pos, Texture.Bounds.Width, Texture.Bounds.Width, Color, Rotation);
            }
        }
    }
}
