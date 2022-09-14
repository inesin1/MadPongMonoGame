using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadPongMonoGame.GameScreens
{
    internal class SplashScreen : GameScreen
    {
        public SplashScreen(Pong game) : base(game){}
        private Pong Pong => (Pong)base.Game;

        private Texture2D _background;

        public override void LoadContent()
        {
            base.LoadContent();

            _background = Content.Load<Texture2D>(@"GameScreens\gs_SplashScreen");
        }

        public override void Draw(GameTime gameTime)
        {
            Pong.GraphicsDevice.Clear(Color.Black);

            Pong.SpriteBatch.Begin();

            Pong.SpriteBatch.Draw(_background, Vector2.Zero, Color.White);

            Pong.SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                Pong.ScreenManager.LoadScreen(new MenuScreen(Pong), new FadeTransition(Pong.GraphicsDevice, Color.Black));
        }
    }
}
