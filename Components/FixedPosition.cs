using Microsoft.Xna.Framework;


namespace FishingRogue
{
    class FixedPosition : Component
    {

        public Vector2 Pos { get; set; }

        public FixedPosition(Entity entity) : base(entity)
        {
        }

        public FixedPosition(Entity entity, Vector2 pos) : base(entity)
        {
            Pos = pos;
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
