using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FishingRogue
{

    public class Fish : Entity
    {
        public Fish(Player player, Vector2 pos) 
        {

            Sprite sprite = new Sprite(
            entity: this,
            player: player,
            texture: Globals.content.Load<Texture2D>("PlayerAssets\\Fisherman"));

            WorldPosition worldPosition = new WorldPosition(this);

            AddComponent(worldPosition);
            AddComponent(sprite);
        }
    }
}
