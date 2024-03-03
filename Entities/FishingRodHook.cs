using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FishingRogue
{
    public class FishingRodHook : Entity
    {
        public Vector2 offset = new Vector2(120, 20);
        public Vector2 initialPosition
        {
            get
            {
                return new Vector2(Globals.gDM.PreferredBackBufferWidth / 2, Globals.gDM.PreferredBackBufferHeight / 2) + offset;
            }
        }

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

            // Offset for initial cast added

            CastFishingRod fishingAction = new CastFishingRod(entity: this, player: player);



            AddComponent(cameraPosition);

            AddComponent(velocity);
            AddComponent(fishingAction);
            AddComponent(sprite);

        }
    }
}
