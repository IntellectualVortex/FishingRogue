
using Microsoft.Xna.Framework;

namespace FishingRogue
{
    public class Acceleration : Component
    {
        public float Accel { get; set; } = 9.8f;
        public Acceleration(Entity entity, float acceleration) : base(entity)
        {
            Accel = acceleration;
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
