using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FishingRogue
{
    public class FishingRodHook : Entity
    {
        public Vector2 initialPosition = new Vector2(0, 0);

        public FishingRodHook(Player player)
        {
            Sprite sprite = new Sprite(
                entity: this,
                player: player,
                texture: Globals.content.Load<Texture2D>("PlayerAssets\\hook"),
                width: 128,
                height: 128);

            Velocity velocity = new Velocity(this);
            WorldPosition position = new WorldPosition(this, initialPosition);
            CastFishingRod fishingAction = new CastFishingRod(this, player);
            Move move = new Move(this);

            AddComponent(position);
            AddComponent(velocity);
            AddComponent(sprite);
            AddComponent(fishingAction);
            AddComponent(move);
        }
    }
}
