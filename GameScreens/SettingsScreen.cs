using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadPongMonoGame.GameScreens
{
    internal class SettingsScreen : GameScreen
    {
        public SettingsScreen(Game game) : base(game)
        {
        }

        private Pong Pong => (Pong)base.Game;

        private Texture2D _background;

        public Dictionary<string, Component> Components { get; private set; }

        public override void LoadContent()
        {
            base.LoadContent();

            _background = Content.Load<Texture2D>(@"GameScreens\gs_SettingsScreen");
        }

        public override void Initialize()
        {
            base.Initialize();

            Components = new Dictionary<string, Component> {
                // Управление
                { "mouse", new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\Settings\b_Mouse"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Settings\b_Mouse"),
                    new Vector2(34, 285)) },
                { "keyboard", new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\Settings\b_Keyboard"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Settings\b_Keyboard"),
                    new Vector2(130, 285)) },
                // Сложность
                {"easy", new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\Settings\b_Easy"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Settings\b_Easy"),
                    new Vector2(34, 365)) },
                {"normal", new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\Settings\b_Midle"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Settings\b_Middle"),
                    new Vector2(110, 365)) },
                {"hard", new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\Settings\b_Hard"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Settings\b_Hard"),
                    new Vector2(266, 365)) },
                // Звук
                {"0", new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\Settings\0"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Settings\0"),
                    new Vector2(34, 445)) },
                {"1", new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\Settings\1"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Settings\1"),
                    new Vector2(70, 445)) },
                {"2", new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\Settings\2"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Settings\2"),
                    new Vector2(106, 445)) },
                {"3", new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\Settings\3"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Settings\3"),
                    new Vector2(142, 445)) },
                {"4", new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\Settings\4"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Settings\4"),
                    new Vector2(178, 445)) },
                {"5", new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\Settings\5"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Settings\5"),
                    new Vector2(214, 445)) },
                {"6", new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\Settings\6"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Settings\6"),
                    new Vector2(250, 445)) },
                {"7", new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\Settings\7"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Settings\7"),
                    new Vector2(286, 445)) },
                {"8", new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\Settings\8"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Settings\8"),
                    new Vector2(322, 445)) },
                // Назад и сброс
                {"back", new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\Settings\b_Back"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Settings\b_Back"),
                    new Vector2(76, 500)) },
                {"reset", new Button(
                    Pong,
                    Content.Load<Texture2D>(@"Buttons\Settings\b_Reset"),
                    Content.Load<Texture2D>(@"Buttons_Hover\Settings\b_Reset"),
                    new Vector2(202, 500)) },
            };

            UpdateButtons();

            // Обработка нажатий
            // Управление
            ((Button)Components["mouse"]).Click += (object sender, EventArgs e) => {
                ((Button)Components["mouse"]).Hold = true;
                ((Button)Components["keyboard"]).Hold = false;

                Pong.Settings["control"] = "mouse";
                File.WriteAllText("settings.json", JsonConvert.SerializeObject(Pong.Settings, Formatting.Indented));
            };
            ((Button)Components["keyboard"]).Click += (object sender, EventArgs e) => {
                ((Button)Components["keyboard"]).Hold = true;
                ((Button)Components["mouse"]).Hold = false;

                Pong.Settings["control"] = "keyboard";
                File.WriteAllText("settings.json", JsonConvert.SerializeObject(Pong.Settings, Formatting.Indented));
            };
            //Сложность
            ((Button)Components["easy"]).Click += (object sender, EventArgs e) => {
                ((Button)Components["easy"]).Hold = true;
                ((Button)Components["normal"]).Hold = false;
                ((Button)Components["hard"]).Hold = false;

                Pong.Settings["complexity"] = "easy";
                File.WriteAllText("settings.json", JsonConvert.SerializeObject(Pong.Settings, Formatting.Indented));
            };
            ((Button)Components["normal"]).Click += (object sender, EventArgs e) => {
                ((Button)Components["easy"]).Hold = false;
                ((Button)Components["normal"]).Hold = true;
                ((Button)Components["hard"]).Hold = false;

                Pong.Settings["complexity"] = "normal";
                File.WriteAllText("settings.json", JsonConvert.SerializeObject(Pong.Settings, Formatting.Indented));
            };
            ((Button)Components["hard"]).Click += (object sender, EventArgs e) => {
                ((Button)Components["easy"]).Hold = false;
                ((Button)Components["normal"]).Hold = false;
                ((Button)Components["hard"]).Hold = true;

                Pong.Settings["complexity"] = "hard";
                File.WriteAllText("settings.json", JsonConvert.SerializeObject(Pong.Settings, Formatting.Indented));
            };
            // Звук
            ((Button)Components["0"]).Click += (object sender, EventArgs e) => {
                UnholdSoundButtons();
                ((Button)sender).Hold = true;

                Pong.Settings["sound"] = "0";
                File.WriteAllText("settings.json", JsonConvert.SerializeObject(Pong.Settings, Formatting.Indented));
            };
            ((Button)Components["1"]).Click += (object sender, EventArgs e) => {
                UnholdSoundButtons();
                ((Button)sender).Hold = true;

                Pong.Settings["sound"] = "1";
                File.WriteAllText("settings.json", JsonConvert.SerializeObject(Pong.Settings, Formatting.Indented));
            };
            ((Button)Components["2"]).Click += (object sender, EventArgs e) => {
                UnholdSoundButtons();
                ((Button)sender).Hold = true;

                Pong.Settings["sound"] = "2";
                File.WriteAllText("settings.json", JsonConvert.SerializeObject(Pong.Settings, Formatting.Indented));
            };
            ((Button)Components["3"]).Click += (object sender, EventArgs e) => {
                Pong.Settings["sound"] = "3";
                File.WriteAllText("settings.json", JsonConvert.SerializeObject(Pong.Settings, Formatting.Indented));
            };
            ((Button)Components["4"]).Click += (object sender, EventArgs e) => {
                UnholdSoundButtons();
                ((Button)sender).Hold = true;

                Pong.Settings["sound"] = "4";
                File.WriteAllText("settings.json", JsonConvert.SerializeObject(Pong.Settings, Formatting.Indented));
            };
            ((Button)Components["5"]).Click += (object sender, EventArgs e) => {
                UnholdSoundButtons();
                ((Button)sender).Hold = true;

                Pong.Settings["sound"] = "5";
                File.WriteAllText("settings.json", JsonConvert.SerializeObject(Pong.Settings, Formatting.Indented));
            };
            ((Button)Components["6"]).Click += (object sender, EventArgs e) => {
                UnholdSoundButtons();
                ((Button)sender).Hold = true;

                Pong.Settings["sound"] = "6";
                File.WriteAllText("settings.json", JsonConvert.SerializeObject(Pong.Settings, Formatting.Indented));
            };
            ((Button)Components["7"]).Click += (object sender, EventArgs e) => {
                UnholdSoundButtons();
                ((Button)sender).Hold = true;

                Pong.Settings["sound"] = "7";
                File.WriteAllText("settings.json", JsonConvert.SerializeObject(Pong.Settings, Formatting.Indented));
            };
            ((Button)Components["8"]).Click += (object sender, EventArgs e) => {
                UnholdSoundButtons();
                ((Button)sender).Hold = true;

                Pong.Settings["sound"] = "8";
                File.WriteAllText("settings.json", JsonConvert.SerializeObject(Pong.Settings, Formatting.Indented));
            };
            // Назад и сброс
            ((Button)Components["back"]).Click += (object sender, EventArgs e) => {
                Pong.ScreenManager.LoadScreen(new MenuScreen(Pong), new FadeTransition(Pong.GraphicsDevice, Color.Black));
            };
            ((Button)Components["reset"]).Click += (object sender, EventArgs e) => {
                Pong.Settings["control"] = "keyboard";
                Pong.Settings["complexity"] = "normal";
                Pong.Settings["sound"] = "6";
                File.WriteAllText("settings.json", JsonConvert.SerializeObject(Pong.Settings, Formatting.Indented));

                UpdateButtons();
            };
        }

        public override void Draw(GameTime gameTime)
        {
            Pong.GraphicsDevice.Clear(Color.Black);

            Pong.SpriteBatch.Begin();

            Pong.SpriteBatch.Draw(_background, Vector2.Zero, Color.White);

            // Отрисовка компонентов
            foreach (Component component in Components.Values)
            {
                component.Draw();
            }

            Pong.SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Component component in Components.Values)
                component.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        /// <summary>
        /// Обновляет выделение выбранных настроек
        /// </summary>
        private void UpdateButtons() {
            UnholdAllButtons();

            ((Button)Components[Pong.Settings["control"]]).Hold = true;
            ((Button)Components[Pong.Settings["complexity"]]).Hold = true;
            ((Button)Components[Pong.Settings["sound"]]).Hold = true;
        }

        /// <summary>
        /// Устанавливает значение false свойства Hold для каждой кнопки
        /// </summary>
        private void UnholdAllButtons() {
            foreach (Component component in Components.Values)
            {
                if (component is Button)
                {
                    ((Button)component).Hold = false;
                }
            }
        }

        /// <summary>
        /// Устанавливает значение false свойства Hold для каждой кнопки настройки звука
        /// </summary>
        private void UnholdSoundButtons() {
            for (int i = 0; i < 9; i++) {
                ((Button)Components[i.ToString()]).Hold = false;
            }
        }
    }
}
