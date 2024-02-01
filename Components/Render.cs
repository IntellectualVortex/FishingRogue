using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FishingRogue
{
    class Render
    {
        // Create more usable simple function
        public void SimpleDraw(Texture2D tex, Vector2 pos, float layer)
        {
            Globals.spriteBatch.Draw(tex,
            new Rectangle((int)pos.X, (int)pos.Y, 200, 200),
            null,
            Color.White,
            0, new Vector2(tex.Bounds.Width / 2, tex.Bounds.Height / 2), Globals.sE, layer);
        }

        public void ScaleDraw(Texture2D tex, Vector2 pos, Vector2 dims, float layer)
        {
            Globals.spriteBatch.Draw(tex,
            new Rectangle((int)pos.X, (int)pos.Y, (int)dims.X, (int)dims.Y),
            null,
            Color.White,
            0, new Vector2(tex.Bounds.Width / 2, tex.Bounds.Height / 2), SpriteEffects.None, layer);
        }

        public void FullCustomDraw(Texture2D tex, Vector2 pos, Vector2 dims, Color color, float rot, Vector2 origin, SpriteEffects spriteEffects, float layer)
        {
            Globals.spriteBatch.Draw(tex,
            new Rectangle((int)pos.X, (int)pos.Y, (int)dims.X, (int)dims.Y), null,
            color,
            rot, origin, spriteEffects, layer);
        }
    }
}