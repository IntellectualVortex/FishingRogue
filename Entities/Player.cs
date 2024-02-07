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
                texture: Globals.fishermanTexture);

            Velocity velocity = new Velocity(this);
            WorldPosition position = new WorldPosition(this, initialPosition);
            Move move = new Move(this);
            FixedPosition fixedPosition = new FixedPosition(this);

            AddComponent(fixedPosition);
            AddComponent(position);
            AddComponent(velocity);
            AddComponent(move);
            AddComponent(sprite);
        }
    }
}
