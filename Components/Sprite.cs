#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Reflection.Emit;
using System.Xml.Linq;
#endregion

namespace FishingRogue
{
    class Sprite : Component
    {
        public Texture2D texture { get; set; }

        public Sprite()
        {
            SpriteSystem.Register(this);
            
            //delete this aftert draw test
            texture = Globals.content.Load<Texture2D>("PlayerAssets\\Fisherman");
        }

        public override void Update()
        {
            
        }

        public virtual void Draw()
        {
            Globals.spriteBatch.Draw(texture,
            new Rectangle(200, 200, 500, 500),
            null,
            Color.White,
            0, new Vector2(texture.Bounds.Width / 2, texture.Bounds.Height / 2), SpriteEffects.None, 0);
        }
    }
}
