using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace FishingRogue
{
    internal class Pond : Entity
    {
        Vector2 initialPosition = new Vector2(300, 0);

        public Pond(Player player)
        {
            Sprite sprite = new Sprite(
                entity: this,
                player: player,
                texture: Globals.content.Load<Texture2D>("PlayerAssets\\Pond"));

            WorldPosition position = new WorldPosition(this, initialPosition);

            AddComponent(position);
            AddComponent(sprite);
        }
    }
}