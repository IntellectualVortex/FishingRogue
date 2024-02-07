﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace FishingRogue
{
    internal class Map : Entity
    {
        Vector2 initialPosition = new Vector2(0, 0);

        public Map(Player player)
        {
            Sprite sprite = new Sprite(
                entity: this,
                player: player,
                texture: Globals.content.Load<Texture2D>("PlayerAssets\\Tex"));

            WorldPosition position = new WorldPosition(this, initialPosition);

            AddComponent(fixedPosition);
            AddComponent(position);
            AddComponent(sprite);
        }
    }
}