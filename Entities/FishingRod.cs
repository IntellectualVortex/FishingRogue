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
            Sprite sprite = new Sprite(this, player, Globals.content.Load<Texture2D>("PlayerAssets\\fishingPole"), Color.Black, 0, 500, 500);
            Velocity velocity = new Velocity(this);
            Position position = new Position(this, initialPosition);
            Move move = new Move(this);

            AddComponent(position);
            AddComponent(velocity);
            AddComponent(move);
            AddComponent(sprite);
        }
    }
}