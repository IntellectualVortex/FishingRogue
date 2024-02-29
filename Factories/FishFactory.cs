using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingRogue.Factories
{
    public class FishFactory : Entity
    {
        Player _player;
        Fish _fish;
        public FishFactory(Entity entity, Player player, Fish fish)
        {
            _player = player;
            _fish = fish;

            // Need to create fish entity and attach components as well dynamically
            WorldPosition worldPosition = new WorldPosition(this);
            _fish.AddComponent(worldPosition);
        }
    }
}
