namespace FishingRogue
{
    public class Player : Entity
    {

        public Player()
        {
            Sprite sprite = new Sprite(
                entity: this,
                player: this,
                texture: Globals.fishermanTexture,
                width: 128,
                height: 128);

            Velocity velocity = new Velocity(this);
            WorldPosition position = new WorldPosition(this);
            Move move = new Move(this);


            AddComponent(move);
            AddComponent(velocity);
            AddComponent(position);
            AddComponent(sprite);
        }
    }
}
