using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FishingRogue
{
    class FishingRod : Entity
    {
        Vector2 initialPosition = new Vector2(Globals.gDM.PreferredBackBufferWidth / 2 + 60,
            Globals.gDM.PreferredBackBufferHeight / 2 - 30);

        public FishingRod(Player player)
        {
            Sprite sprite = new Sprite(
                entity : this, 
                player : player, 
                texture : Globals.content.Load<Texture2D>("PlayerAssets\\fishingPole"));

            Velocity velocity = new Velocity(this);
            Position position = new Position(this, initialPosition);
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