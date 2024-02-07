
using Microsoft.Xna.Framework;

namespace FishingRogue
{
    public class Velocity : Component
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

        public override void Update(GameTime gameTime)
        {
        }
    }
}
