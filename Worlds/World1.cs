
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
            entities.Add(new Map(player));
            entities.Add(player);
            entities.Add(new FishingRod(player));
            entities.Add(new FishingRodHook(player));
            pixelEntities.Add(new FishingRodString(player));
        }
    }
}
