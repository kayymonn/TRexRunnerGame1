using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Entities;
using Project1.Graphics;

namespace Project1
{
    public class TRexRunnerGame : Game
    {
        private const string ASSET_NAME_SPRITESHEET = "TrexSpritesheet";


        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _spriteSheetTexture;

        private Trex _trex;



        public TRexRunnerGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _spriteSheetTexture = Content.Load<Texture2D>(ASSET_NAME_SPRITESHEET);

            _trex = new Trex(_spriteSheetTexture, new Vector2(20, 20));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            
            _spriteBatch.Begin();

            _trex.Draw(_spriteBatch, gameTime);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
