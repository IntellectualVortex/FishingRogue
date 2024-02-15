﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FishingRogue
{
    class FishingRod : Entity
    {
        Vector2 initialPosition = new Vector2(0, 0);

        public FishingRod(Player player)
        {
            Sprite sprite = new Sprite(
                entity: this,
                player: player,
                texture: Globals.content.Load<Texture2D>("PlayerAssets\\fishingPole"));

            Velocity velocity = new Velocity(this);
            WorldPosition position = new WorldPosition(this, initialPosition);
            Move move = new Move(this);
            CameraPosition fixedPosition = new CameraPosition(this);

            AddComponent(fixedPosition);
            AddComponent(position);
            AddComponent(velocity);
            AddComponent(move);
            AddComponent(sprite);
        }
    }
}