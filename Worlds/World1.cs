using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FishingRogue
{
    public class World1
    {
        internal List<Entity> entities = new List<Entity>();

        public World1()
        {
            entities.Add(new Map());
            entities.Add(new Player());
        }
    }
}
