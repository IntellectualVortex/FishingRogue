using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingRogue
{
    internal class Map : Entity
    {
        public Map(Texture2D tex)
        {
            Sprite sprite = new Sprite();
            Position position = new Position();

            sprite.texture = tex;

            AddComponent(sprite);
            AddComponent(position);
        }
    }
}