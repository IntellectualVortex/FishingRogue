﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FishingRogue
{
    class BaseSystem<T> where T : Component
    {

        // Components list accessible anywhere
        public static List<T> components = new List<T>();


        // Only 
        public static void Register(T component)
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
}
