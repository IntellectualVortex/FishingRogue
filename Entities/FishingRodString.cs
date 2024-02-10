using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FishingRogue
{
    public class FishingRodString : Entity
    {
        Vector2 initialPosition = new Vector2(190, 40);

        public FishingRodString(Player player)
        {
            Sprite sprite = new Sprite(
                entity: this,
                player: player,
                texture: Globals.content.Load<Texture2D>("PlayerAssets\\greenpixel"),
                width: 5,
                height: 5);

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