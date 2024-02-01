using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FishingRogue
{
    class Velocity : Component
    {
        public Velocity(Entity entity) : base(entity)
        {
        }

        public float speedMult { get; set; } = 1f;
        public Vector2 Vel { get; set; }

        public override void Update()
        {
        }
    }
}
