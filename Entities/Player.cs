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
        Vector2 initialPosition = new Vector2(0, 0);

        public Player()
        {
            Sprite sprite = new Sprite(this);
            Velocity velocity = new Velocity(this);
            Position position = new Position(this, initialPosition);
            Move move = new Move(this);

            sprite.Texture = Globals.content.Load<Texture2D>("PlayerAssets\\Fisherman");

            AddComponent(position);
            AddComponent(velocity);
            AddComponent(move);
            AddComponent(sprite);
        }
    }
}
