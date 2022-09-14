using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using System;
using System.Collections.Generic;

namespace MadPongMonoGame.GameScreens
{
    internal class NewGameScreen : GameScreen
    {
        public NewGameScreen(Game game) : base(game){}
        public Pong Pong => (Pong)base.Game;

        private Texture2D _background;

        public List<Component> Components { get; private set; }

        public override void Initialize()
        {
            base.Initialize();

            // Добавляем кнопки
            Components = new List<Component> {
                new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\NewGame\b_OnePlayer"),
                    Content.Load<Texture2D>(@"Buttons_Hover\NewGame\b_OnePlayer"),
                    new Vector2(278, 217)),
                new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\NewGame\b_TwoPlayers"),
                    Content.Load<Texture2D>(@"Buttons_Hover\NewGame\b_TwoPlayers"),
                    new Vector2(278, 306)),
                new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\NewGame\b_Back"),
                    Content.Load<Texture2D>(@"Buttons_Hover\NewGame\b_Back"),
                    new Vector2(328, 395))
            };

            // Обрабатываем нажатия на кнопки
            ((Button)Components[0]).Click += (object sender, EventArgs e) => {
                Pong.ScreenManager.LoadScreen(new PlayScreen(Pong, "sp"), new FadeTransition(Pong.GraphicsDevice, Color.Black));
            };

            ((Button)Components[1]).Click += (object sender, EventArgs e) => {
                Pong.ScreenManager.LoadScreen(new PlayScreen(Pong, "mp"), new FadeTransition(Pong.GraphicsDevice, Color.Black));
            };

            ((Button)Components[2]).Click += (object sender, EventArgs e) => {
                Pong.ScreenManager.LoadScreen(new MenuScreen(Pong), new FadeTransition(Pong.GraphicsDevice, Color.Black));
            };
        }

        public override void LoadContent()
        {
            base.LoadContent();

            _background = Content.Load<Texture2D>(@"GameScreens\gs_NewGameScreen");
        }

        public override void Draw(GameTime gameTime)
        {
            Pong.GraphicsDevice.Clear(Color.Black);

            Pong.SpriteBatch.Begin();

            Pong.SpriteBatch.Draw(_background, Vector2.Zero, Color.White);

            foreach (Component component in Components)
                component.Draw();

            Pong.SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Component component in Components)
                component.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
