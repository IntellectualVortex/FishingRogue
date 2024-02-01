using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingRogue
{ 
    class Player : Entity
    {
        public Player(Texture2D tex)
        {
            Sprite sprite = new Sprite();
            Velocity velocity = new Velocity();
            Position position = new Position();

            sprite.texture = tex;
            AddComponent(sprite);
            AddComponent(position);
            AddComponent(velocity);
        }
    }
}
