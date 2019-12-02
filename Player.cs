using GeoSketch;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Side_Scroller
{
    class Player
    {
        int _speed = 5;
        int _sprint;
        Vector2 charPos = new Vector2(200,610);

        bool jumping = false;
        float startY = 610, jumpspeed = 0;

        public void PlayerMovement()
        {
            KeyboardState kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.LeftShift))
            {
                _sprint = 2;
            }else if (kState.IsKeyUp(Keys.LeftShift))
            {
                _sprint = 0;
            }
            if (kState.IsKeyDown(Keys.D))
            {
                charPos.X += _speed + _sprint;
            }
            if (kState.IsKeyDown(Keys.A))
            {
                charPos.X -= _speed + _sprint;
            }
            if (jumping)
            {
                charPos.Y += jumpspeed;
                jumpspeed += 1;
                if (charPos.Y >= startY)
            
                {
                    charPos.Y = startY;
                    jumping = false;
                }
            }else
            {
                if (kState.IsKeyDown(Keys.Space))
                {
                    jumping = true;
                    jumpspeed = -20;//Give it upward thrust
                }
            }
        }
        public void DrawPlayer(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawRectangle((int)charPos.X, (int) charPos.Y, 75, 100, Color.DarkGray, Color.White, 0); // player

        }

       
    }
}
