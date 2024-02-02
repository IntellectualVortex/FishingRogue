using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingRogue
{
    internal class Map : Entity
    {
        Vector2 initialPosition = new Vector2(300, 200);

        public Map()
        {
            Sprite sprite = new Sprite(this);
            Position position = new Position(this, initialPosition);


            sprite.Texture = Globals.content.Load<Texture2D>("PlayerAssets\\Tex");

            AddComponent(position);
            AddComponent(sprite);
        }
    }
}