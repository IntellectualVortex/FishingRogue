﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingRogue
{
    public class Movement : Component
    {

        public Movement() 
        {
            MovementSystem.Register(this);
        }   
    }
}