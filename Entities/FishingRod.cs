using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FishingRogue
{
    class FishingRod : Entity
    {
        public Vector2 offset = new Vector2(120, 20);
        public Vector2 initialPosition
        {
            get
            {
                return new Vector2(Globals.gDM.PreferredBackBufferWidth / 2, Globals.gDM.PreferredBackBufferHeight / 2) + offset;
            }
        }

        public FishingRod(Player player)
        {
            Sprite sprite = new Sprite(
                entity: this,
                player: player,
                texture: Globals.content.Load<Texture2D>("PlayerAssets\\fishingPole"),
                width: 128,
                height: 128);

            Velocity velocity = new Velocity(this);
            CameraPosition position = new CameraPosition(this, initialPosition);

            AddComponent(velocity);
            AddComponent(position);
            AddComponent(sprite);
        }
    }
}