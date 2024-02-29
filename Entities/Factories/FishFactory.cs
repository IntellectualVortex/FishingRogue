using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingRogue
{
    public class FishFactory : Entity
    {
        Player _player;
        Fish _fish;
        public FishFactory(Entity entity, Player player, Fish fish)
        {
            _player = player;
            _fish = fish;

            Sprite sprite = new Sprite(
            entity: this,
            player: player,
            texture: Globals.content.Load<Texture2D>("PlayerAssets\\Fisherman"));

            // Need to create fish entity and attach components as well dynamically
            WorldPosition worldPosition = new WorldPosition(this);
            _fish.AddComponent(worldPosition);
            _fish.AddComponent(sprite);
        }
    }
}
