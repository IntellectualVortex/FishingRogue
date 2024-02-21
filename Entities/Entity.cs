using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace FishingRogue
{
    public class Entity
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

        public void ReplaceComponent(Component component, Component component2)
        {
            components.Remove(component);
            components.Add(component2); 
            component2.entity = this;
        }
    }
}