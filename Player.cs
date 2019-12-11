using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Side_Scroller
{
    class Player
    {
        private int _speed = 5;
        private int _sprint;

        private bool jumping = false;
        private float startY = 610, jumpspeed = 0;
        public Viewport GraphicsViewport;

        public Texture2D _dinoHead;
        public Texture2D _dinoBody;
        public Texture2D _dinoPlaceHolder;

        private int _spriteSheetRows =2;
        private int _spriteSheetColumns = 5;

        private Vector2 _charPos = new Vector2(200, 610);
        private Vector2 _initialDrawingSize = new Vector2(100,100);

        private int _spriteSheetIndex = 0;
        private int _frameCounter = 0;
        private int _speedFrameCounter = 4;
        private int _runningFrameCounter = 2;

        public SpriteEffects spriteEffect = SpriteEffects.FlipHorizontally;

        public void PlayerMovement()
        {
            KeyboardState kState = Keyboard.GetState();

            if (IsCollidingRight() == false)
            {
                if (kState.IsKeyDown(Keys.D))
                {
                    _charPos.X += _speed + _sprint;
                    spriteEffect = SpriteEffects.FlipHorizontally;
                }
                if (kState.IsKeyDown(Keys.LeftShift))
                {
                    _sprint = 2;
                }
                else if (kState.IsKeyUp(Keys.LeftShift))
                {
                    _sprint = 0;
                }
            }
            if (IsCollidingLeft() == false)
            {
                if (kState.IsKeyDown(Keys.A))
                {
                    _charPos.X -= _speed + _sprint;
                    spriteEffect = SpriteEffects.None;
                }
                if (kState.IsKeyDown(Keys.LeftShift))
                {
                    _sprint = 2;
                    _speedFrameCounter = _runningFrameCounter;
                }
                else if (kState.IsKeyUp(Keys.LeftShift))
                {
                    _sprint = 0;
                    _speedFrameCounter = 4;
                }
            }
           
            if (jumping)
            {
                _charPos.Y += jumpspeed;
                jumpspeed += 1;
                if (_charPos.Y >= startY)

                {
                    _charPos.Y = startY;
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
        private bool IsCollidingRight()
        {
            return DestinationRectangle().X + 100 >= GraphicsViewport.Width;
        }
        private bool IsCollidingLeft()
        {
            return DestinationRectangle().X <= 0;
        }

        public void DrawPlayer(SpriteBatch spriteBatch)
        {
            Vector2 up = new Vector2(0, 60);
            Vector2 charPosHead = _charPos- up;
            spriteBatch.Draw(_dinoPlaceHolder, DestinationRectangle(), SourceRectangle(), Color.White, 0f, new Vector2(0, 0), spriteEffect, 0.0f);
            ///spriteBatch.Draw(_dinoHead, charPosHead, Color.White);


        }

        public void DrawTest(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(_runningTexture, new Rectangle(0, 0, SpriteWidth(), SpriteHeight()), SourceRectangle(0,0), Color.White);
            // spriteBatch.Draw(_runningTexture, DestinationRectangle(), SourceRectangle(), Color.White);


        }
        private int SpriteWidth() // 1 column pakke van de sprites
        {
            return _dinoPlaceHolder.Width / _spriteSheetColumns;
        }
        private int SpriteHeight() // 1 row pakken van de sprites
        {
            return _dinoPlaceHolder.Height / _spriteSheetRows;
        }
        private Rectangle SourceRectangle(int row, int col) // om de sprite te pakken die we willen
        {
            int x = col * SpriteWidth();
            int y = row * SpriteHeight();
            return new Rectangle(x, y, SpriteWidth(), SpriteHeight());
        }

        private Rectangle DestinationRectangle() // waar dat de sprite getekent word
        {
            Vector2 currentDrawingSize = CurrentDrawingSize();
            Vector2 topLeft = _charPos - currentDrawingSize / 2;
            return new Rectangle((int)topLeft.X, (int)topLeft.Y,
                (int)currentDrawingSize.X, (int)currentDrawingSize.Y
                );
        }
        private Vector2 CurrentDrawingSize() // maakt de sprite groter of kleiner met de zoom
        {
            return _initialDrawingSize;
        }
        private Rectangle SourceRectangle()
        {
            int indexRow = _spriteSheetIndex / _spriteSheetColumns;
            int indexColumn = _spriteSheetIndex % _spriteSheetColumns;
            return SourceRectangle(indexRow, indexColumn);
        }
        public void UpdateSpriteSheetIndex() // update called deze functie every frame waardoor de framecounter increased
        {
            _frameCounter++;
            if (_frameCounter >= _speedFrameCounter)
            {
                _frameCounter = 0;
                _spriteSheetIndex++;
                if (_spriteSheetIndex >= 10)
                {
                    _spriteSheetIndex = 0;
                }
            }
        }

    }
}