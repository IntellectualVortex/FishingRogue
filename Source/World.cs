using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FishingRogue
{
    public class World
    {
        Sprite sprite;
        public World()
        {
            sprite = new Sprite();
        }

        public void Update(GameTime gameTime)
        {
            SpriteSystem.Update();
        }

        public void Draw()
        {
            sprite.Draw();
        }
    }
}
