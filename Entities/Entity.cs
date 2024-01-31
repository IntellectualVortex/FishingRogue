using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingRogue
{
    public class Entity
    {
        Guid id = Guid.NewGuid();

        List<Component> components = new List<Component>(); 

        public Entity()
        {
            Debug.WriteLine(id);
        }

        
        public T GetComponent<T>() where T : Component
        {
            foreach (var component in components)
            {
                if (component.GetType() == typeof(T))
                {
                    return (T)component;
                }
            }
            return null;
        }

        public void AddComponent(Component component)
        {
            components.Add(component);
            component.entity = this;
        }
    }
}