using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.ComponentModel.DataAnnotations;

namespace FishingRogue
{
    public class FishAction : Component
    {

        MouseState mouse = Mouse.GetState();

        public FishAction(Entity entity) : base(entity)
        {
        }

        public override void Update(GameTime gameTime) 
        {
            WorldPosition hookPosition = entity.GetComponent<WorldPosition>();
            Velocity hookVelocity = entity.GetComponent<Velocity>();
            var vel = hookVelocity.Vel;

            if (mouse.LeftButton == ButtonState.Pressed)
            {
                vel += new Vector2(1, 0);
            }
        }

    }
}
