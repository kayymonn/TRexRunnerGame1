﻿using Microsoft.Xna.Framework;
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

        private Trex _trex;

        private Trex _trex2;


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

            _trex = new Trex(_spriteSheetTexture, new Vector2(TREX_START_POS_X + Trex.TREX_DEFAULT_SPRITE_POS_WIDTH *2, TREX_START_POS_Y - Trex.TREX_DEFAULT_SPRITE_POS_HEIGHT));
            _trex2 = new Trex(_spriteSheetTexture, new Vector2(TREX_START_POS_X, TREX_START_POS_Y - Trex.TREX_DEFAULT_SPRITE_POS_HEIGHT));

            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            

            base.Update(gameTime);


            _trex.Update(gameTime);

            _trex2.Position = new Vector2(_trex2.Position.X  + _trex2.Krok, _trex2.Position.Y );
            if (_trex2.Position.X > WINDOW_WIDTH - Trex.TREX_DEFAULT_SPRITE_POS_WIDTH)
                _trex2.Krok = -2;
            if (_trex2.Position.X < 0)
                _trex2.Krok = 2;
             
            if (_trex2.Position.X + Trex.TREX_DEFAULT_SPRITE_POS_WIDTH  > _trex.Position.X)
                
            
            _trex2.Update(gameTime);
            

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            
            _spriteBatch.Begin();

            _trex.Draw(_spriteBatch, gameTime);
            _trex2.Draw(_spriteBatch, gameTime);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
