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
        public Texture2D texture;
        public int speed;

        public Vector2 bgPos1, bgPos2;

        // constructor
        public Background()
        {
            texture = null;
            bgPos1 = new Vector2(0, 0);
            bgPos2 = new Vector2(2100,0);
            speed = 5;
        }

        public void DrawBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bgPos1, Color.White);
            spriteBatch.Draw(texture, bgPos2, Color.White);
        }

        public void UpdateBackground()
        {
            bgPos1.X = bgPos1.X - speed;
            bgPos2.X = bgPos2.X - speed;

            // Repeat
            if (bgPos1.X <= -2100)
            {
                bgPos1.X = 0;
                bgPos2.X = 2100;
            }
        }
    }
}
