using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FishingRogue
{
    public class FishingRodString : Entity
    {

        public Vector2 initialPosition = new Vector2(Globals.gDM.PreferredBackBufferWidth / 2 + 120, Globals.gDM.PreferredBackBufferHeight / 2 + 20);

        public FishingRodString(Player player)
        {
            Sprite sprite = new Sprite(
                entity: this,
                player: player,
                texture: Globals.content.Load<Texture2D>("PlayerAssets\\greenpixel5"),
                width: 5,
                height: 5);

            Velocity velocity = new Velocity(this);
            CameraPosition position = new CameraPosition(this, initialPosition);
            Move move = new Move(this);

            AddComponent(position);
            AddComponent(velocity);
            AddComponent(move);
            AddComponent(sprite);
        }
    }
}