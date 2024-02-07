using Microsoft.Xna.Framework;


namespace FishingRogue
{
    public class CameraPosition : Component
    {
        /* A 2D coordinate of something in World space
         * For example World size is 1920x1080
         * Then only 0 to 1920 x coordinates are valid
         * and only 0 to 1080 y coordinates are valid
         */
        public Vector2 Pos { get; set; }

        public CameraPosition(Entity entity) : base(entity)
        {
        }

        public CameraPosition(Entity entity, Vector2 pos) : base(entity)
        {
            Pos = pos;
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
