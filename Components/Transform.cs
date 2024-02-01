using FishingRogue.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingRogue
{
    class Transform : Component
    {

        public Transform() 
        {
            TransformSystem.Register(this);
        }
    }
}
