
using System.Collections.Generic;


namespace FishingRogue
{
    public class World1
    {
        internal List<Entity> entities = new List<Entity>();
        internal List<Entity> pixelEntities = new List<Entity>();

        public World1()
        {
            Player player = new Player();
            pixelEntities.Add(new FishingRodString(player));
            entities.Add(new Map(player));
            entities.Add(player);
            entities.Add(new Pond(player));
            entities.Add(new FishingRod(player));
            entities.Add(new FishingRodHook(player));
        }
    }
}
