using Microsoft.Xna.Framework;


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

        public override void Update(GameTime gameTime)
        {
        }
    }
}
