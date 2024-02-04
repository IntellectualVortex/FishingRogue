using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FishingRogue
{
    class FishingRodHook : Entity
    {
        Vector2 initialPosition = new Vector2(Globals.gDM.PreferredBackBufferWidth / 2,
            Globals.gDM.PreferredBackBufferHeight / 2);

        public FishingRodHook(Player player)
        {
            Sprite sprite = new Sprite(this, player, Globals.content.Load<Texture2D>("PlayerAssets\\hook"));
            Velocity velocity = new Velocity(this);
            Position position = new Position(this, initialPosition);
            Move move = new Move(this);


            AddComponent(position);
            AddComponent(velocity);
            AddComponent(sprite);
            AddComponent(move);
        }
    }
}
