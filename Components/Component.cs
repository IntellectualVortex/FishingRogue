
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FishingRogue
{
    abstract class Component
    {
        public Entity entity;

        public Component(Entity entity)
        {
            this.entity = entity;
        }

        public abstract void Update(GameTime gameTime);
    }
}
