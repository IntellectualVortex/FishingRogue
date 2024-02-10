using Microsoft.Xna.Framework;
using System.Linq;


namespace FishingRogue
{
    public class UpdateSystem
    {
        World1 world;

        public UpdateSystem(World1 world) { this.world = world; }

        public void Update(GameTime gameTime)
        {
            // iterate through both 

            foreach (Entity entity in world.entities.Concat(world.pixelEntities))
                foreach (Component component in entity.components)
                {
                    component.Update(gameTime);
                }
        }
    }
}
