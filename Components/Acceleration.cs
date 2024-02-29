
using Microsoft.Xna.Framework;

namespace FishingRogue
{
    public class Acceleration : Component
    {
        public Vector2 Accel { get; set; }
        public Acceleration(Entity entity, Vector2 acceleration) : base(entity)
        {
            Accel = acceleration;
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
