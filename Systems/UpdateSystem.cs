using Microsoft.Xna.Framework;


namespace FishingRogue
{
    class UpdateSystem
    {
        World1 world;

        public UpdateSystem(World1 world) {  this.world = world; }

        public void Update(GameTime gameTime)
        {
            foreach (Entity entity in world.entities)
            {
                foreach (Component component in entity.components)
                {
                    component.Update(gameTime);
                }
            }
        }
    }
}
