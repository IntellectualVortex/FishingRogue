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
        PlayerMovementSystem pMS;

        public World()
        {
            player = new Player(Globals.content.Load<Texture2D>("PlayerAssets\\Fisherman"));
            renderSystem = new RenderSystem();
            pMS = new PlayerMovementSystem();
        }

        public void Update(GameTime gameTime)
        {
            MovePlayer();
        }

        public void Draw()
        {
            Sprite playerSprite = player.GetComponent<Sprite>();
            Position playerPosition = player.GetComponent<Position>();
            renderSystem.SimpleDraw(playerSprite.texture);
        }

        public void MovePlayer()
        {
        }
    }
}
