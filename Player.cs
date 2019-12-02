using GeoSketch;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Side_Scroller
{
    internal class Player
    {
        private int _speed = 5;
        private int _sprint;
        private Vector2 charPos = new Vector2(200, 610);
        
        private bool isRCollide = false;
        private bool isLCollide = false;

        private bool jumping = false;
        private float startY = 610, jumpspeed = 0;
        public Viewport GraphicsViewport;

        public Texture2D _dinoHead;
        public Texture2D _dinoBody;


        public void PlayerMovement()
        {
            BoundingBox();
            KeyboardState kState = Keyboard.GetState();
            
            if (kState.IsKeyDown(Keys.LeftShift))
            {
                _sprint = 2;
            }
            else if (kState.IsKeyUp(Keys.LeftShift))
            {
                _sprint = 0;
            }
            if (isRCollide == false)
            {
                if (kState.IsKeyDown(Keys.D))
                {
                    charPos.X += _speed + _sprint;
                }
            }
            if (isLCollide == false)
            {
                if (kState.IsKeyDown(Keys.A))
                {
                    charPos.X -= _speed + _sprint;
                }
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
            }
            else
            {
                if (kState.IsKeyDown(Keys.Space))
                {
                    jumping = true;
                    jumpspeed = -20;//Give it upward thrust
                }
            }
        }

        public void BoundingBox()
        {
            if (charPos.X + 75 == GraphicsViewport.Width)
            {
                isRCollide = true;
            }
            else
            {
                isRCollide = false;
            }
            if (charPos.X == 0)
            {
                isLCollide = true;
            }
            else
            {
                isLCollide = false;
            }
        }

        public void DrawPlayer(SpriteBatch spriteBatch)
        {
            Vector2 up = new Vector2(0, 60);
            Vector2 charPosHead = charPos- up;
            spriteBatch.Draw(_dinoHead,charPosHead, Color.White);
            spriteBatch.Draw(_dinoBody,charPos, Color.White);
        }
    }
}