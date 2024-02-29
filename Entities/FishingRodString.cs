using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FishingRogue
{
    public class FishingRodString : Entity
    {
        public Vector2 offset = new Vector2(120, 20);
        public Vector2 initialPosition
        {
            get
            {
                return new Vector2(Globals.gDM.PreferredBackBufferWidth / 2, Globals.gDM.PreferredBackBufferHeight / 2) + offset;
            }
        }
        public FishingRodString(Player player, FishingRodHook fishingRodHook)
        {
            Sprite sprite = new Sprite(
                entity: this,
                player: player,
                fRH: fishingRodHook,
                texture: Globals.content.Load<Texture2D>("PlayerAssets\\greenpixel5"),
                width: 1,
                height: 1);

            Velocity velocity = new Velocity(this);
            CameraPosition position = new CameraPosition(this, initialPosition);

            AddComponent(velocity);
            AddComponent(position);
            AddComponent(sprite);
        }
    }
}