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
            Sprite sprite = new Sprite(this);
            Position position = new Position(this);
            Render render = new Render(this);

            sprite.Texture = tex;

            AddComponent(sprite);
            AddComponent(position);
            AddComponent(render);
        }
    }
}