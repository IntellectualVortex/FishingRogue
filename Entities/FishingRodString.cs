using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using System.Collections;
using System;
using Microsoft.Xna.Framework.Graphics;

namespace FishingRogue
{
    public class FishingRodString : Entity
    {
        Vector2 initialPosition = new Vector2(0, 0);

        public FishingRodString(Player player)
        {

            Velocity velocity = new Velocity(this);
            WorldPosition position = new WorldPosition(this, initialPosition);
            Move move = new Move(this);
            Sprite sprite = new Sprite(this,
                player: player,
                texture: Globals.content.Load<Texture2D>("PlayerAssets\\greenpixel"));


            AddComponent(position);
            AddComponent(velocity);
            AddComponent(move);
            AddComponent(sprite);
        }
    }
}