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
    public class World
    {

        internal List<Entity> entities = new List<Entity>();

        UpdateSystem updateSystem = new UpdateSystem();
        Player player;
        Map map;
        Render render;
        Move move;
        

        public World()
        {
            player = new Player(Globals.content.Load<Texture2D>("PlayerAssets\\Fisherman"));
            map = new Map(Globals.content.Load<Texture2D>("PlayerAssets\\Tex"));
            render = new Render();
            move = new Move();

            AddEntity(player);
            AddEntity(map);
        }

        void AddEntity(Entity entity) 
        {
            entities.Add(entity);
        }



        public void Update(GameTime gametime)
        {
            move.Update(player);
            updateSystem.Update(this);
        }


        public void Draw()
        {
            Sprite playerSprite = player.GetComponent<Sprite>();
            Position playerPosition = player.GetComponent<Position>();

            Sprite mapSprite = map.GetComponent<Sprite>();
            Position mapPosition = map.GetComponent<Position>();


            render.SimpleDraw(playerSprite.texture, playerPosition.Pos, 0f);
            render.SimpleDraw(mapSprite.texture, mapPosition.Pos + new Vector2(300, 200), 1f);
        }
    }
}
