using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Side_Scroller
{
    class TitleScreen
    {
        public Texture2D pickle;
        Vector2 _pos = new Vector2(0, 0);
        public void DrawTitleScreen(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(pickle,_pos, Color.White); 
        }
    }
}
