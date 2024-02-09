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
        private const int TREX_DEFAULT_SPRITE_POS_X = 848;
        private const int TREX_DEFAULT_SPRITE_POS_Y = 0;
        private const int TREX_DEFAULT_SPRITE_POS_WIDTH = 44;
        private const int TREX_DEFAULT_SPRITE_POS_HEIGHT = 52;

        public Sprite Sprite { get; private set; }

        public TrexState State { get; private set; }

        public Vector2 Position { get; set; }

        public bool IsAlive { get; private set; }

        public float Speed { get; private set; }

        public Trex(Texture2D spriteSheet, Vector2 position)
        {
            Sprite = new Sprite(spriteSheet, TREX_DEFAULT_SPRITE_POS_X, TREX_DEFAULT_SPRITE_POS_Y, TREX_DEFAULT_SPRITE_POS_WIDTH, TREX_DEFAULT_SPRITE_POS_HEIGHT);
            Position = position;
        }

        public int DrawOrder { get; set; }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Sprite.Draw(spriteBatch, this.Position);
        }

        public void Update(GameTime gameTime)
        {
           
        }
    }
}
