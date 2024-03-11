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

        public const int WINDOW_WIDTH = 600;
        public const int WINDOW_HEIGHT = 150;

        public const int TREX_START_POS_Y = WINDOW_HEIGHT - 16;
        public const int TREX_START_POS_X = 1;


        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _spriteSheetTexture;

        private Trex _trexPomalej;

        private Trex _trexRychlej;


        public TRexRunnerGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            _graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            _graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            _graphics.ApplyChanges();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _spriteSheetTexture = Content.Load<Texture2D>(ASSET_NAME_SPRITESHEET);

            _trexRychlej = new Trex(_spriteSheetTexture, new Vector2(WINDOW_WIDTH - Trex.TREX_DEFAULT_SPRITE_POS_WIDTH, TREX_START_POS_Y - Trex.TREX_DEFAULT_SPRITE_POS_HEIGHT ));
            _trexRychlej.Krok = -4;


            _trexPomalej = new Trex(_spriteSheetTexture, new Vector2(TREX_START_POS_X, TREX_START_POS_Y - Trex.TREX_DEFAULT_SPRITE_POS_HEIGHT));
            _trexPomalej.Krok = 2;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);

            
            _trexPomalej.Position = new Vector2(_trexPomalej.Position.X + _trexPomalej.Krok, _trexPomalej.Position.Y);
            
            if (_trexPomalej.Position.X == WINDOW_WIDTH - Trex.TREX_DEFAULT_SPRITE_POS_WIDTH)
                _trexPomalej.Krok = -2;

            if (_trexPomalej.Position.X < 0)
                _trexPomalej.Krok = 2;

            _trexPomalej.Update(gameTime);

 


            _trexRychlej.Position = new Vector2(_trexRychlej.Position.X  + _trexRychlej.Krok, _trexRychlej.Position.Y );
            if (_trexRychlej.Position.X > WINDOW_WIDTH - Trex.TREX_DEFAULT_SPRITE_POS_WIDTH)
                _trexRychlej.Krok = -4;

            
            if (_trexRychlej.Position.X < 0)
                _trexRychlej.Krok = 4;
           
           
            
            _trexRychlej.Update(gameTime);


           if (_trexPomalej.Position.X + Trex.TREX_DEFAULT_SPRITE_POS_WIDTH > _trexRychlej.Position.X)
            {
                _trexPomalej.Krok = -2;
                _trexRychlej.Krok = 4;
            }
                
                





        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            
            _spriteBatch.Begin();

            _trexPomalej.Draw(_spriteBatch, gameTime);
            _trexRychlej.Draw(_spriteBatch, gameTime);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
