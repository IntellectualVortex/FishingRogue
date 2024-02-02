using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace FishingRogue
{
    class CameraSystem
    {
        World1 world;

        public CameraSystem(World1 world) { this.world = world; }

        public void Update(GameTime gameTime)
        {
            foreach (Entity entity in world.entities)
            {
                foreach (Component component in entity.components)
                {
                    component.Update(gameTime);
                }
            }
        }
    }
}
