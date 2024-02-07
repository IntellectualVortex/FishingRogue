using Microsoft.Xna.Framework;


namespace FishingRogue
{
    public class WorldPosition : Component
    {
        /* A 2D coordinate of something in World space
         * For example World size is 1000x1000
         * Then only 0 to 1000 x and y coordinates are valid
         */
        public Vector2 Pos { get; set; }

        public WorldPosition(Entity entity) : base(entity)
        {
        }

        public WorldPosition(Entity entity, Vector2 pos) : base(entity)
        {
            Pos = pos;
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
