using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace FishingRogue
{
    public class Player : Entity
    {
        public Vector2 initialPosition = new Vector2(0, 0);

        public Player()
        {
            Sprite sprite = new Sprite(
                entity: this,
                player: this,
                texture: Globals.fishermanTexture,
                width: 128,
                height: 128);

            Velocity velocity = new Velocity(this);
            WorldPosition position = new WorldPosition(this, initialPosition);
            Move move = new Move(this);


            AddComponent(position);
            AddComponent(velocity);
            AddComponent(move);
            AddComponent(sprite);
        }
    }
}
