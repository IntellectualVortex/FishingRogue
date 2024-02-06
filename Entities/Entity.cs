using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace FishingRogue
{
    class Entity
    {
        Guid id = Guid.NewGuid();

        internal List<Component> components = new List<Component>();

        public Entity()
        {
            Debug.WriteLine(id);
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (Component component in components)
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