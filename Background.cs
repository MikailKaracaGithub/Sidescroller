using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using GeoSketch;

namespace Side_Scroller
{
    public class Background
    {
        public Texture2D _texture;
        public int _scrollSpeed;

        public Vector2 bgPos1, bgPos2;

        // constructor
        public Background()
        {
            _texture = null;
            bgPos1 = new Vector2(0, 0);
            bgPos2 = new Vector2(2100,0); // Note to self! current placeholder width is 2100 when changing it remember to change this
            _scrollSpeed = 3;
        }

        public void DrawBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, bgPos1, Color.White);
            spriteBatch.Draw(_texture, bgPos2, Color.White);
        }

        public void UpdateBackground()
        {
            bgPos1.X = bgPos1.X - _scrollSpeed;
            bgPos2.X = bgPos2.X - _scrollSpeed;

            // Repeat
            if (bgPos1.X <= -2100)
            {
                bgPos1.X = 0;
                bgPos2.X = 2100;
            }
        }
    }
}
