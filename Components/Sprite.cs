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
        public Sprite(Entity entity) : base(entity)
        {
        }

        public Texture2D texture { get; set; }

        public override void Update()
        {
        }
    }
}
