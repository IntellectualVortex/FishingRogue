using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FishingRogue
{

    public class Fish : Entity
    {
        Vector2 initialPosition = new Vector2(300, 0);
        public Fish(Player player) 
        {
            Sprite sprite = new Sprite(
            entity: this,
            player: player,
            texture: Globals.content.Load<Texture2D>("PlayerAssets\\Fisherman"));

            WorldPosition position = new WorldPosition(this, initialPosition);

            AddComponent(position);
            AddComponent(sprite);
        }
    }
}
