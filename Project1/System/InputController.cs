﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Project1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrexRunnerGame.System
{
    public class InputController
    {
        private Trex _trex;

        private KeyboardState _previousKeyboardState;
        public InputController(Trex trex)
        {
            _trex = trex;
        }
        public void ProcessControlls(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if(!_previousKeyboardState.IsKeyDown(Keys.Up) && keyboardState.IsKeyDown(Keys.Up))
            {
                if(_trex.State != TrexState.Jumping)
                _trex.BeginJump();
                else
                    _trex.ContinueJump();
            }

            _previousKeyboardState = keyboardState;

        }


    }
}
