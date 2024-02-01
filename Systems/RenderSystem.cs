using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace FishingRogue
{
    class RenderSystem
    {
        public RenderSystem() 
        {
        }


        // Create more usable simple function
        public void SimpleDraw(Texture2D tex)
        {
            Globals.spriteBatch.Draw(tex,
            new Rectangle(200, 200, 500, 500),
            null,
            Color.White,
            0, new Vector2(tex.Bounds.Width / 2, tex.Bounds.Height / 2), SpriteEffects.None, 0);
        }

        public void CustomDraw(Texture2D tex)
        {
            // Add dynamic parameters for XNA draw effects
        }
    }
}
