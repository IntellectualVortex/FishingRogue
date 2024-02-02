
using System.Collections.Generic;


namespace FishingRogue
{
    public class World1
    {
        internal List<Entity> entities = new List<Entity>();

        public World1()
        {
            entities.Add(new Map());
            entities.Add(new Player());
        }
    }
}
