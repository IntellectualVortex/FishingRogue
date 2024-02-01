using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
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
            Sprite sprite = new Sprite(this);
            Velocity velocity = new Velocity(this);
            Position position = new Position(this);
            Render render = new Render(this);
            Move move = new Move(this);

            sprite.texture = tex;

            
            AddComponent(sprite);
            AddComponent(position);
            AddComponent(velocity);
            AddComponent(render);
            AddComponent(move);
        }

        public Player()
        {

        }
    }
}
