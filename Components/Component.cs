
using Microsoft.Xna.Framework;


namespace FishingRogue
{
    public abstract class Component
    {
        public Entity entity;

        public Component(Entity entity)
        {
            this.entity = entity;
        }

        public abstract void Update(GameTime gameTime);
    }
}
