﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FishingRogue
{
    public class FishingRodString : Entity
    {
        public FishingRodString(Player player)
        {
            Sprite sprite = new Sprite(
                entity: this,
                player: player,
                texture: Globals.content.Load<Texture2D>("PlayerAssets\\greenpixel5"),
                width: 5,
                height: 5);

            Velocity velocity = new Velocity(this);
            WorldPosition position = new WorldPosition(this, player.initialPosition);
            Move move = new Move(this);

            AddComponent(position);
            AddComponent(velocity);
            AddComponent(move);
            AddComponent(sprite);
        }
    }
}