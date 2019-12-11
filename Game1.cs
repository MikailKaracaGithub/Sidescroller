using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace Side_Scroller
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private TitleScreen _titleScreen = new TitleScreen();

        private const int _screenWidth = 800;
        private const int _screenHeight = 800;

        private Background _bg = new Background();

        private Player _player = new Player();
        private Song bgSong;


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
            _player._dinoPlaceHolder = Content.Load<Texture2D>("DinoPlaceHolder");
            _titleScreen.pickle = Content.Load<Texture2D>("pickle");


            this.bgSong = Content.Load<Song>("stal");
            
            MediaPlayer.Play(bgSong);
            MediaPlayer.Volume = 0.1f;
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            _bg.UpdateBackground();
            _player.PlayerMovement();
            _player.UpdateSpriteSheetIndex();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();

            _titleScreen.DrawTitleScreen(spriteBatch);

            _bg.DrawBackground(spriteBatch); // background
            _player.DrawPlayer(spriteBatch);
            _player.DrawTest(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}