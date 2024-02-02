using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace FishingRogue
{
    class Position : Component
    {

        public Vector2 Pos { get; set; }

        public Position(Entity entity) : base(entity)
        {
        }

        public Position(Entity entity, Vector2 pos) : base(entity)
        {
            Pos = pos;
        }

        public override void Update()
        {
        }
    }
}
