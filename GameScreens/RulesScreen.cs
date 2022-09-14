using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadPongMonoGame.GameScreens
{
    internal class RulesScreen : GameScreen
    {
        public RulesScreen(Game game) : base(game){}
        private Pong Pong => (Pong)base.Game;

        private Texture2D _background;

        public List<Component> Components { get; private set; }

        public override void LoadContent()
        {
            base.LoadContent();

            _background = Content.Load<Texture2D>(@"GameScreens\gs_RulesScreen");
        }

        public override void Initialize()
        {
            base.Initialize();

            Components = new List<Component> {
                new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\Rules\b_Ok"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Rules\b_Ok"),
                    new Vector2(330, 530)),
            };

            ((Button)Components[0]).Click += (object sender, EventArgs e) => {
                Pong.ScreenManager.LoadScreen(new MenuScreen(Pong), new FadeTransition(Pong.GraphicsDevice, Color.Black));
            };
        }

        public override void Draw(GameTime gameTime)
        {
            Pong.GraphicsDevice.Clear(Color.Black);

            Pong.SpriteBatch.Begin();

            Pong.SpriteBatch.Draw(_background, Vector2.Zero, Color.White);

            // Отрисовка компонентов
            foreach (Component component in Components)
            {
                component.Draw();
            }

            Pong.SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Component component in Components)
                component.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
