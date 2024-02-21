using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Linq;


namespace FishingRogue
{
    public class UpdateSystem
    {
        World1 world;

        public UpdateSystem(World1 world) { this.world = world; }

        public void Update(GameTime gameTime)
        {
            foreach (Entity entity in world.entities.ToList())
                foreach (Component component in entity.components.ToList())
                {
                    component.Update(gameTime);
                    
                }
            foreach (Entity entity in world.pixelEntities.ToList())
                foreach (Component component in entity.components.ToList())
                {
                    component.PixelUpdate(gameTime);
                }
        }
    }
}
