using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Entities
{
    public class Trex : IGameEntity
    {
        private const int TREx_IDLE_BACKGROUND_SPRITE_POS_X = 40;
        private const int TREx_IDLE_BACKGROUND_SPRITE_POS_Y = 0;

        public const int TREX_DEFAULT_SPRITE_POS_X = 848;
        public const int TREX_DEFAULT_SPRITE_POS_Y = 0;
        public const int TREX_DEFAULT_SPRITE_POS_WIDTH = 44;
        public const int TREX_DEFAULT_SPRITE_POS_HEIGHT = 52;

        private Sprite _idleBackgroundSprite;

        public Sprite Sprite { get; private set; }

        public TrexState State { get; private set; }

        public Vector2 Position { get; set; }

        public bool IsAlive { get; private set; }

        public float Speed { get; private set; }

        public Trex(Texture2D spriteSheet, Vector2 position)
        {
            Sprite = new Sprite(spriteSheet, TREX_DEFAULT_SPRITE_POS_X, TREX_DEFAULT_SPRITE_POS_Y, TREX_DEFAULT_SPRITE_POS_WIDTH, TREX_DEFAULT_SPRITE_POS_HEIGHT);
            Position = position;
            _idleBackgroundSprite = new Sprite(spriteSheet, TREx_IDLE_BACKGROUND_SPRITE_POS_X, TREx_IDLE_BACKGROUND_SPRITE_POS_Y, TREX_DEFAULT_SPRITE_POS_WIDTH, TREX_DEFAULT_SPRITE_POS_HEIGHT);
            State = TrexState.Idle;
        }


        public int DrawOrder { get; set; }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (State == TrexState.Idle) 
            {
                _idleBackgroundSprite.Draw(spriteBatch, this.Position);
            }
            
            Sprite.Draw(spriteBatch, this.Position);
        }

        public void Update(GameTime gameTime)
        {
           
        }
    }
}
