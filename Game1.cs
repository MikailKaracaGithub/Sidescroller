using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using GeoSketch;
namespace Side_Scroller
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        const int _screenWidth = 800;
        const int _screenHeight = 800;

        Texture2D _background;


        Vector2 _backgroundPos = new Vector2(0, 0);
        Vector2 _backgroundReset = new Vector2(-700, 0);

        Player player = new Player();

        Song bgSong;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = _screenWidth;
            graphics.PreferredBackBufferHeight = _screenHeight;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _background = Content.Load<Texture2D>("sky");
            this.bgSong = Content.Load<Song>("stal");
            MediaPlayer.Play(bgSong);

        }
        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            _backgroundPos.X--;
            if (_backgroundPos.X < _backgroundReset.X)
            {
                _backgroundPos.X = 0;
            }
            player.PlayerMovement();
            base.Update(gameTime);

        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            spriteBatch.Draw(_background, _backgroundPos, Color.White); // background
            spriteBatch.DrawRectangle(0, 600, 1600, 200, Color.IndianRed, Color.White, 0);// foreground
            player.DrawPlayer(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        
    }
}
