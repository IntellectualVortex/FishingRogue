using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FishingRogue
{
    public class BaseSystem<T> where T : Component
    {

        // Components list accessible anywhere
        static List<T> components = new List<T>();


        // Only 
        public void Register(T component)
        {
            components.Add(component);
        }


        public static void Update()
        {
            foreach (T component in components)
            {
                component.Update();
            }
        }
    }

    class SpriteSystem : BaseSystem<Sprite> { }
    class MovementSystem : BaseSystem<Movement> { }
}
