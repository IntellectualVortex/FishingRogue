using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace FishingRogue
{
    internal class Map : Entity
    {
        Vector2 initialPosition = new Vector2(Globals.gDM.PreferredBackBufferWidth / 2,
                    Globals.gDM.PreferredBackBufferHeight / 2);

        public Map(Player player)
        {
            Sprite sprite = new Sprite(
                entity: this, 
                player : player, 
                texture: Globals.content.Load<Texture2D>("PlayerAssets\\Tex"));

            Position position = new Position(this, initialPosition);
            FixedPosition fixedPosition = new FixedPosition(this);

            AddComponent(fixedPosition);
            AddComponent(position);
            AddComponent(sprite);
        }
    }
}