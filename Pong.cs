using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MadPongMonoGame
{
    public class Pong : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch SpriteBatch { get; }
        public ScreenManager ScreenManager { get; }           // Менеджер экранов

        public Dictionary<string, GameObject> GameObjects;    // Список игровых объектов
        public Dictionary<string, string> Settings;           // Настройки

        private bool _isDebug = false;                        // Дебаг вкл/выкл

        public int[] Scores = { 0, 0};                        // Очки игроков
                                                              // [0] - Игрок слева
                                                              // [1] - Игрок справа

        public Pong()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = Variables.WINDOW_WIDTH;
            _graphics.PreferredBackBufferHeight = Variables.WINDOW_HEIGHT;
            _graphics.ApplyChanges();

            SpriteBatch = new SpriteBatch(GraphicsDevice);

            ScreenManager = new ScreenManager();
            Components.Add(ScreenManager);

            GameObjects = new Dictionary<string, GameObject>();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            Settings = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("settings.json"));

            ScreenManager.LoadScreen(new GameScreens.SplashScreen(this), new FadeTransition(GraphicsDevice, Color.Black));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SpriteBatch.Begin();

            // Отрисовка дебага
            if (_isDebug) Debug();

            SpriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Дебаг
        /// </summary>
        private void Debug() {
            //_spriteBatch.DrawString();
        }
    }
}