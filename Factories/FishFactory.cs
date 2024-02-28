using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingRogue.Factories
{
    public class FishFactory
    {
        Player _player;
        public FishFactory(Player player) 
        {
            _player = player;
        }

        public Fish CreateFish(string name) 
        {
            return new Fish(_player);
            // Need to create fish entity and attach components as well dynamically
        }

    }
}
