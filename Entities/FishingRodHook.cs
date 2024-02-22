using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FishingRogue
{
    public class FishingRodHook : Entity
    {
        public Vector2 initialPosition = new Vector2(Globals.gDM.PreferredBackBufferWidth / 2 + 120, Globals.gDM.PreferredBackBufferHeight / 2 + 20);

        public FishingRodHook(Player player)
        {
            Sprite sprite = new Sprite(
                entity: this,
                player: player,
                texture: Globals.content.Load<Texture2D>("PlayerAssets\\hook"),
                width: 64,
                height: 64);


            Velocity velocity = new Velocity(this);
            CameraPosition cameraPosition = new CameraPosition(this, initialPosition);
            WorldPosition worldPosition = new WorldPosition(this);
            CastFishingRod fishingAction = new CastFishingRod(entity: this, player: player);

            AddComponent(cameraPosition);
            AddComponent(worldPosition);
            AddComponent(velocity);
            AddComponent(fishingAction);
            AddComponent(sprite);

        }
    }
}
