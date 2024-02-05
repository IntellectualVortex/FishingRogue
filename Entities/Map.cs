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
            Sprite sprite = new Sprite(this, player, Globals.content.Load<Texture2D>("PlayerAssets\\Tex"), Color.Black);
            Position position = new Position(this, initialPosition);


            AddComponent(position);
            AddComponent(sprite);
        }
    }
}