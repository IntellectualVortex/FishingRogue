#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Reflection.Emit;
using System.Xml.Linq;
#endregion

namespace FishingRogue
{
    class Sprite : Component
    {
        public Texture2D Texture { get; set; }

        public Sprite(Entity entity, Texture2D texture) : base(entity)
        {
            Texture = texture;
        }

        public Sprite(Entity entity) : base(entity)
        {
        }


        public override void Update()
        {
        }
    }
}
