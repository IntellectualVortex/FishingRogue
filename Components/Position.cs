﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace FishingRogue
{
    class Position : Component
    {
        public Position(Entity entity) : base(entity)
        {
        }

        public Vector2 Pos {  get; set; }

        public override void Update()
        {
        }
    }
}
