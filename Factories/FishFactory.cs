using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingRogue.Factories
{
    public class FishFactory
    {
        Player player;
        public FishFactory() { }

        public Fish CreateFish(string name) 
        {
            return new Fish(player);
        }

    }
}
