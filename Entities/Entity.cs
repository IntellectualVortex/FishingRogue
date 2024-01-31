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

        public Entity() 
        {
            Debug.WriteLine(id);
        } 
    }