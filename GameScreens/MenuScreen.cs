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
    internal class MenuScreen : GameScreen
    {
        private Pong Pong => (Pong)base.Game;
        public MenuScreen(Game game) : base(game) { }
        
        private Texture2D _background;

        public List<Component> Components { get; private set; }

        public override void Initialize()
        {
            base.Initialize();

            // Создаем кнопки
            Components = new List<Component> {
                new Button(
                    Pong, 
                    Content.Load<Texture2D>(@"Buttons\Menu\b_NewGame"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Menu\b_NewGame"),
                    new Vector2(528, 263)),
                new Button(
                    Pong, 
                    Content.Load<Texture2D>(@"Buttons\Menu\b_Settings"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Menu\b_Settings"),
                    new Vector2(540, 312)),
               new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\Menu\b_Rules"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Menu\b_Rules"),
                    new Vector2(564, 361)),
                new Button(
                    Pong, 
                    Content.Load<Texture2D>(@"Buttons\Menu\b_Exit"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Menu\b_Exit"),
                    new Vector2(588, 425))
            };

            // Обрабатываем нажатия на кнопки
            ((Button)Components[0]).Click += (object sender, EventArgs e) => {
                Pong.ScreenManager.LoadScreen(new NewGameScreen(Pong), new FadeTransition(Pong.GraphicsDevice, Color.Black));
            };

            ((Button)Components[1]).Click += (object sender, EventArgs e) => {
                Pong.ScreenManager.LoadScreen(new SettingsScreen(Pong), new FadeTransition(Pong.GraphicsDevice, Color.Black));
            };

            ((Button)Components[2]).Click += (object sender, EventArgs e) => {
                Pong.ScreenManager.LoadScreen(new RulesScreen(Pong), new FadeTransition(Pong.GraphicsDevice, Color.Black));
            };

            ((Button)Components[3]).Click += (object sender, EventArgs e) => {
                Pong.Exit();
            };
        }

        public override void LoadContent()
        {
            base.LoadContent();

            _background = Content.Load<Texture2D>(@"GameScreens\gs_MenuScreen");
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Component component in Components)
                component.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
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
    }
}
