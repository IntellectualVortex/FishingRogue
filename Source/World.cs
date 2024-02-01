using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        internal List<Entity> entities = new List<Entity>();

        Player player;
        RenderSystem renderSystem;
        PlayerMoveSystem moveSystem;
        Map map;

        

        public World()
        {
            player = new Player(Globals.content.Load<Texture2D>("PlayerAssets\\Fisherman"));
            map = new Map(Globals.content.Load<Texture2D>("PlayerAssets\\Tex"));
            renderSystem = new RenderSystem();
            moveSystem = new PlayerMoveSystem();


            AddEntity(player);
            AddEntity(map);
        }

        void AddEntity(Entity entity) 
        {
            entities.Add(entity);
        }

        public void Update(GameTime gametime)
        {
            Position playerPosition = player.GetComponent<Position>();
            Velocity playerVelocity = player.GetComponent<Velocity>();
            var vel = playerVelocity.Vel;

            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.S))
            {
                vel += new Vector2(0, 0);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                vel += new Vector2(0, -1);

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                vel += new Vector2(0, 1);
            }
            else
            {
                vel += new Vector2(0, 0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                vel += new Vector2(0, 0);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                vel += new Vector2(1, 0);

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                vel += new Vector2(-1, 0);

            }
            else
            {
                vel += new Vector2(0, 0);
            }

            if (vel != Vector2.Zero)
            {
                vel.Normalize();
                vel *= playerVelocity.speedMult;
            }

            playerPosition.Pos += vel;
        }

        public void Draw()
        {
            Sprite playerSprite = player.GetComponent<Sprite>();
            Position playerPosition = player.GetComponent<Position>();

            Sprite mapSprite = map.GetComponent<Sprite>();
            Position mapPosition = map.GetComponent<Position>();

            renderSystem.SimpleDraw(playerSprite.texture, playerPosition.Pos, 0f);
            renderSystem.SimpleDraw(mapSprite.texture, mapPosition.Pos + new Vector2(300, 200), 1f);
        }
    }
}
