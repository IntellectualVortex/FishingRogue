using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FishingRogue
{
    public class World
    {
        Player player;
        RenderSystem renderSystem;
        PlayerMoveSystem moveSystem;

        public World()
        {
            player = new Player(Globals.content.Load<Texture2D>("PlayerAssets\\Fisherman"));
            renderSystem = new RenderSystem();
            moveSystem = new PlayerMoveSystem();
        }

        public void Update(GameTime gametime)
        {
            moveSystem.GetVelocity(player);
        }

        public void Draw()
        {
            Sprite playerSprite = player.GetComponent<Sprite>();
            Position playerPosition = player.GetComponent<Position>();
            renderSystem.SimpleDraw(playerSprite.texture, playerPosition.Pos);
        }
    }
}
