using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace FishingRogue
{ 
    class Player : Entity
    {
        Vector2 initialPosition = new Vector2(Globals.gDM.PreferredBackBufferWidth / 2,
                    Globals.gDM.PreferredBackBufferHeight / 2);

        public Player()
        {
            Sprite sprite = new Sprite(this);
            Velocity velocity = new Velocity(this);
            Position position = new Position(this, initialPosition);
            Move move = new Move(this);

            sprite.Texture = Globals.content.Load<Texture2D>("PlayerAssets\\Fisherman");

            AddComponent(position);
            AddComponent(velocity);
            AddComponent(move);
            AddComponent(sprite);
        }
    }
}
