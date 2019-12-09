using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
namespace Side_Scroller
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TitleScreen _titleScreen = new TitleScreen();

        const int _screenWidth = 800;
        const int _screenHeight = 800;

        Background _bg = new Background();

        Player _player = new Player();
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
            _bg._textureBG = Content.Load<Texture2D>("newBG");
            _bg._textureMidground = Content.Load<Texture2D>("Midground");
            _player.GraphicsViewport = graphics.GraphicsDevice.Viewport;
            _player._dinoHead = Content.Load<Texture2D>("dinohead");
            _player._dinoBody = Content.Load<Texture2D>("bodydino");
            _titleScreen.pickle = Content.Load<Texture2D>("pickle");

            this.bgSong = Content.Load<Song>("stal");
            MediaPlayer.Play(bgSong);


        }
        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            _bg.UpdateBackground();
            _player.PlayerMovement();

            base.Update(gameTime);

        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            _bg.DrawBackground(spriteBatch); // background
            _player.DrawPlayer(spriteBatch);
            _titleScreen.DrawTitleScreen(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
        
    }
}
