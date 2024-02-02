#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Xml.Linq;
#endregion

namespace FishingRogue
{
    class Camera : Component
    {
        public Camera(Entity entity) : base(entity)
        {
        }


        // Update above functions after testing
        public Rectangle WorldSpaceToCameraSpace()
        {
            Position entityPosition = entity.GetComponent<Position>();
            var x_1 = entityPosition.Pos.X - 100 + Globals.gDM.PreferredBackBufferWidth / 2;
            var y_1 = entityPosition.Pos.Y - 100 + Globals.gDM.PreferredBackBufferHeight / 2;
            return new Rectangle((int)x_1, (int)y_1, 100, 100);
        }

        public override void Update(GameTime gameTime)
        {
        }

    }
}
