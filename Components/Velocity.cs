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

        public float SpeedMult { get; set; } = 1f;
        public Vector2 Vel { get; set; }

        public Velocity(Entity entity, float speedMult, Vector2 vel) : base(entity)
        {
            SpeedMult = speedMult;
            Vel = vel;
        }

        public Velocity(Entity entity) : base(entity)
        {
        }

        public override void Update()
        {
        }
    }
}
