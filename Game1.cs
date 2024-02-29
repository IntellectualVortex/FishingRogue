using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FishingRogue
{
    public class Game1 : Game
    {
        World1 world;
        UpdateSystem updateSystem;
        //SpriteUpdateSystem spriteUpdateSystem;
        public Texture2D pixel;

        public Game1()
        {
            Globals.gDM = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });

            Globals.gDM.IsFullScreen = false;
            Globals.gDM.PreferredBackBufferWidth = 1920;
            Globals.gDM.PreferredBackBufferHeight = 1080;
            Globals.gDM.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.content = this.Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

            Globals.fishermanTexture = Globals.content.Load<Texture2D>("PlayerAssets\\Fisherman");
            world = new World1();
            updateSystem = new UpdateSystem(world);
            //spriteUpdateSystem = new SpriteUpdateSystem(world);
        }

        public void TestLoadContent()
        {
            Globals.content = this.Content;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            GraphicsDevice.Clear(Color.DarkBlue);

            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, blendState: BlendState.AlphaBlend, null);
            updateSystem.Update(gameTime);
            //spriteUpdateSystem.Update(gameTime);
            Globals.spriteBatch.End();
        }

        protected override void Draw(GameTime gameTime)
        {

        }
    }
}