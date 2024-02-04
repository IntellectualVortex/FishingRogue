using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FishingRogue
{
    public class Game1 : Game
    {
        World1 world;
        UpdateSystem updateSystem;

        public Game1()
        {
            Globals.gDM = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
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
            world = new World1();
            updateSystem = new UpdateSystem(world);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            GraphicsDevice.Clear(Color.DarkBlue);

            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, blendState: BlendState.AlphaBlend, null);
            updateSystem.Update(gameTime);
            Globals.spriteBatch.End();
        }
    }
}