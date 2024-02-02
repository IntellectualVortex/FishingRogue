using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;


namespace FishingRogue
{
    class Bullet : Entity
    {
        Vector2 initialPosition = new Vector2(0, 0);

        public Bullet()
        {
            Sprite sprite = new Sprite(this);
            Velocity velocity = new Velocity(this);
            Position position = new Position(this, initialPosition);
            MovePlayer move = new MovePlayer(this);

            sprite.Texture = Globals.content.Load<Texture2D>("PlayerAssets\\Fisherman");

            AddComponent(position);
            AddComponent(velocity);
            AddComponent(move);
            AddComponent(sprite);
        }
    }
}
