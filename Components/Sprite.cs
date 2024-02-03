﻿#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

#endregion

namespace FishingRogue
{
    class Sprite : Component
    {
        public Texture2D Texture { get; set; }

        Player _player;

        public Sprite(Entity entity, Player player, Texture2D texture) : base(entity)
        {
            Texture = texture;
            _player = player;
        }

        public Sprite(Entity entity) : base(entity)
        {
        }

        public void SimpleDraw(Texture2D tex, Vector2 pos)
        {
            var rectangle = WorldSpaceToCameraSpace();
            Globals.spriteBatch.Draw(tex,
            rectangle,
            null,
            Color.White,
            0, new Vector2(tex.Bounds.Width / 2, tex.Bounds.Height / 2), Globals.sE, 0f);
        }

        public void ScaleDraw(Texture2D tex, Vector2 pos, Vector2 dims)
        {
            Globals.spriteBatch.Draw(tex,
            new Rectangle((int)pos.X, (int)pos.Y, (int)dims.X, (int)dims.Y),
            null,
            Color.White,
            0, new Vector2(tex.Bounds.Width / 2, tex.Bounds.Height / 2), SpriteEffects.None, 0f);
        }

        

        public void FullCustomDraw(Texture2D tex, Vector2 pos, Vector2 dims, Color color, float rot, Vector2 origin, SpriteEffects spriteEffects)
        {
            Globals.spriteBatch.Draw(tex,
            new Rectangle((int)pos.X, (int)pos.Y, (int)dims.X, (int)dims.Y), null,
            color,
            rot, origin, spriteEffects, 0f);
        }

        public Rectangle WorldSpaceToCameraSpace()
        {
            Position entityPosition = entity.GetComponent<Position>();
            Position playerPosition = _player.GetComponent<Position>();

            var x_1 = entityPosition.Pos.X - playerPosition.Pos.X + Globals.gDM.PreferredBackBufferWidth / 2;
            var y_1 = entityPosition.Pos.Y - playerPosition.Pos.Y + Globals.gDM.PreferredBackBufferHeight / 2;
            return new Rectangle((int)x_1, (int)y_1, 100, 100);
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
            SimpleDraw(entitySprite.Texture, entityPosition.Pos);
        }
    }
}
